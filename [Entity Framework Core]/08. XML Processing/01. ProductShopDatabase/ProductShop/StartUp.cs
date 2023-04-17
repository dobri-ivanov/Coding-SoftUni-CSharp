using AutoMapper;
using CarDealer.Utilities;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string xml = File.ReadAllText($"../../../Datasets/products.xml");

            Console.WriteLine(ImportProducts(context, xml));
        }


        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportUsersDto[] usersDtos = xmlHelper.Deserialize<ImportUsersDto[]>(inputXml, "Users");
            ICollection<User> users = new HashSet<User>();

            foreach (var item in usersDtos)
            {
                User user = mapper.Map<User>(item);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return String.Format($"Successfully imported {users.Count}");


        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductsDto[] productsDtos = xmlHelper.Deserialize<ImportProductsDto[]>(inputXml, "Products");
            ICollection<Product> products = new HashSet<Product>();

            foreach (var item in productsDtos)
            {
                Product product = mapper.Map<Product>(item);
                products.Add(product);
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return String.Format($"Successfully imported {products.Count}");

        }
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

    }
}