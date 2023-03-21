using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string json = File.ReadAllText(@"../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, json));

        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportSuppliersDTO[] suppliersDTOs = JsonConvert.DeserializeObject<ImportSuppliersDTO[]>(inputJson);
            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var item in suppliersDTOs)
            {
                Supplier supplier = mapper.Map<Supplier>(item);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return String.Format($"Successfully imported {suppliers.Count}.");
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportPartsDTO[] importParts= JsonConvert.DeserializeObject<ImportPartsDTO[]>(inputJson);
            ICollection<Part> parts = new HashSet<Part>();

            foreach (var item in importParts)
            {
                if (context.Suppliers.Any(s => s.Id == item.SupplierId))
                {
                    Part part = mapper.Map<Part>(item);
                    parts.Add(part);
                }
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return String.Format($"Successfully imported {parts.Count}.");
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
        }
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}