using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext contex = new ProductShopContext();
            string json = File.ReadAllText(@"../../../Datasets/categories-products.json");

            Console.WriteLine(GetUsersWithProducts(contex));
            File.WriteAllText(@"../../../Results/users-and-products.json", GetUsersWithProducts(contex));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUsersDTO[] importUsers = JsonConvert.DeserializeObject<ImportUsersDTO[]>(inputJson);

            ICollection<User> mappedUsers = new HashSet<User>();

            foreach (var item in importUsers)
            {
                User user = mapper.Map<User>(item);

                mappedUsers.Add(user);
            }
            context.AddRange(mappedUsers);
            context.SaveChanges();

            return String.Format($"Successfully imported {mappedUsers.Count}");
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductsDTO[] importProducts = JsonConvert.DeserializeObject<ImportProductsDTO[]>(inputJson);
            ICollection<Product> products = new HashSet<Product>();

            foreach (var item in importProducts)
            {
                Product product = mapper.Map<Product>(item);
                products.Add(product);

            }
            context.AddRange(products);
            context.SaveChanges();

            return String.Format($"Successfully imported {products.Count}");
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoriesDTO[] importCategories = JsonConvert.DeserializeObject<ImportCategoriesDTO[]>(inputJson);
            ICollection<Category> categories = new HashSet<Category>();

            foreach (var item in importCategories)
            {
                if (item.Name != null)
                {
                    Category category = mapper.Map<Category>(item);
                    categories.Add(category);
                }
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return String.Format($"Successfully imported {categories.Count}");
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoriesProductsDTO[] importCategoriesProducts =
                JsonConvert.DeserializeObject<ImportCategoriesProductsDTO[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var item in importCategoriesProducts)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(item);
                categoryProducts.Add(categoryProduct);
            }
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return String.Format($"Successfully imported {categoryProducts.Count}");

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = $"{(c.CategoriesProducts.Sum(cp => cp.Product.Price) / c.CategoriesProducts.Count):f2}",
                    totalRevenue = $"{c.CategoriesProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    // UserDTO
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        // ProductWrapperDTO
                        Count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                // ProductDTO
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users
            };

            IContractResolver contractResolver = ConfigureCamelCaseNaming();
            return JsonConvert.SerializeObject(userWrapperDto,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
    }
}