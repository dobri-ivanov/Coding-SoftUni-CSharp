using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string xml = File.ReadAllText($"../../../Datasets/cars.xml");

            Console.WriteLine(ImportCars(context, xml));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSuppliersDto[] importSuppliers = xmlHelper.Deserialize<ImportSuppliersDto[]>(inputXml, "Suppliers");
            ICollection<Supplier> suppliers = new HashSet<Supplier>(); 

            foreach (var item in importSuppliers)
            {
                Supplier supplier = mapper.Map<Supplier>(item);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return String.Format($"Successfully imported {suppliers.Count}");
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartsDto[] importParts = xmlHelper.Deserialize<ImportPartsDto[]>(inputXml, "Parts");
            ICollection<Part> parts = new HashSet<Part>();

            foreach (var item in importParts)
            {

                if (!item.SupplierId.HasValue || !context.Suppliers.Any(s => s.Id == item.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(item);
                parts.Add(part);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return String.Format($"Successfully imported {parts.Count}");
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarsDto[] importCars = xmlHelper.Deserialize<ImportCarsDto[]>(inputXml, "Cars");
            ICollection<Car> cars = new HashSet<Car>();

            foreach (var item in importCars)
            {
                Car car = new Car();

                car.Make = item.Make;
                car.Model = item.Model;
                car.TraveledDistance = item.TraveledDistance;

                foreach (var item2 in item.Parts.DistinctBy(a => a.Id))
                {
                    Part part = mapper.Map<Part>(item2);
                    if (!context.Parts.Any(p => p.Id == part.Id))
                    {
                        continue;
                    }
                    car.PartsCars.Add(new PartCar { Part = new Part { Id = part.Id} });
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return String.Format($"Successfully imported {cars.Count}");



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