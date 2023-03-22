using AutoMapper;
using AutoMapper.Execution;
using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //string json = File.ReadAllText(@"../../../Datasets/sales.json");

            string json = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(json);
            File.WriteAllText(@"../../../Results/toyota-cars.json", json);

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
            ImportPartsDTO[] importParts = JsonConvert.DeserializeObject<ImportPartsDTO[]>(inputJson);
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
            var carsAndPartsDTO = JsonConvert.DeserializeObject<List<ImportCarsDTO>>(inputJson);

            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (var dto in carsAndPartsDTO)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };
                cars.Add(car);

                foreach (var part in dto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part,
                    };
                    parts.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomersDTO[] importCustomersDTOs = JsonConvert.DeserializeObject<ImportCustomersDTO[]>(inputJson);
            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var item in importCustomersDTOs)
            {
                Customer customer = mapper.Map<Customer>(item);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return String.Format($"Successfully imported {customers.Count}.");
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSalesDTO[] importSalesDTOs = JsonConvert.DeserializeObject<ImportSalesDTO[]>(inputJson);
            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var item in importSalesDTOs)
            {
                Sale sale = mapper.Map<Sale>(item);
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return String.Format($"Successfully imported {sales.Count}.");
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver,
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
               .Where(c => c.Make == "Toyota")
               .OrderBy(c => c.Model)
               .ThenByDescending(c => c.TraveledDistance)
               .Select(c => new
               {
                   Id = c.Id,
                   Make = c.Make,
                   Model = c.Model,
                   TraveledDistance = c.TraveledDistance
               })
               .ToArray();

            return JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price))
                })
                .AsNoTracking()
                .ToArray();

            var json = customers.Select(c => new
            {
                fullName = c.fullName,
                boughtCars = c.boughtCars,
                spentMoney = c.spentMoney.Sum(),
            })
            .OrderByDescending(c => c.spentMoney)
            .ThenByDescending(c => c.boughtCars)
            .ToArray();

            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):f2}"
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);

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