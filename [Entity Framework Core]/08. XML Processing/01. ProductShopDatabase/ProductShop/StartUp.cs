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
            string xml = File.ReadAllText($"../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(context, xml));
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

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

    }
}