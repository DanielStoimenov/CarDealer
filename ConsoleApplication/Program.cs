using AutoMapper;

using CarDealer.Mapping;
using CarDealer.Persistence;
using CarDealer.Services.Implementations;
using CarDealer.Services.Models.Cars.InputModels;
using CarDealer.Services.Models.Customer.InputModels;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            var context = new CarDealerDbContext();

            var service = new CarService(context, configuration.CreateMapper());
            var custService = new CustomerService(context, configuration.CreateMapper());


            /*
            service.AddCar(new AddCarInputServiceModel
            {
                Make = "Lada",
                Model = "5",
                TravelledDistance = 1423423
            });
            */


            //string modelToRemove = "m3";
            //service.RemoveByModel(modelToRemove);


            //string makeToRemove = "LaDa";
            //service.RemoveByMake(makeToRemove);


            /*
            string carMake = "bmw";
            var cars = service.SearchByMake(carMake);

            foreach (var c in cars)
            {
                Console.WriteLine(c.Make + " " + c.Model + " -> " + c.TravelledDistance + "km");
            }
            */


            /*
            string carModel = "prius";

            foreach (var c in service.SearchByModel(carModel))
            {
                Console.WriteLine(c.Make + " " + c.Model + " -> " + c.TravelledDistance + "km");
            }
            */


            /*
            foreach (var c in service.GetAll())
            {
                Console.WriteLine(c.Make + " " + c.Model + " -> " + c.TravelledDistance + "km");
            }
            */


            /*
            string birthDate = "1989-01-01";
            DateTime convertedDate = DateTime.Parse(birthDate);

            custService.AddCustomer(new AddCustomerInputServiceModel
            {
                Name = "Ivan Ivanov",
                BirthDate = convertedDate,
                IsYoungDriver = true
            });
            */


            /*
            string name = "ivan Ivanov";
            var names = custService.SearchByName(name);

            foreach (var p in names)
            {
                Console.WriteLine($"{p.Name} {p.BirthDate} {p.IsYoungDriver}");
            }
            */


            //custService.RemoveByName("Ivan Ivanov");

            /*
            var customer = custService.GetAll();
            foreach (var c in customer)
            {
                Console.WriteLine(c.Name + " " + c.BirthDate + " " + c.IsYoungDriver);
            }
            */
        }
    }
}