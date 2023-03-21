﻿using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs;
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
            string json = File.ReadAllText(@"../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(context, json));

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
            var carsAndPartsDTO = JsonConvert.DeserializeObject<List<ImportCarsDTO>>(inputJson);

            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (var dto in carsAndPartsDTO)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
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
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}