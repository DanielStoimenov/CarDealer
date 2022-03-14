using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Persistence;
using CarDealer.Persistence.Entities;
using CarDealer.Services.Interfaces;
using CarDealer.Services.Models.Cars.InputModels;
using CarDealer.Services.Models.Cars.OutputModels;

namespace CarDealer.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext dbContext;
        private readonly IMapper mapper;

        public CarService(CarDealerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddCar(AddCarInputServiceModel model)
        {
            try
            {
                Car car = mapper.Map<Car>(model);
                dbContext.Cars.Add(car);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public ICollection<ListAllCarsServiceModel> GetAll()
        {
            var cars = dbContext
                .Cars
                .ProjectTo<ListAllCarsServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return cars;
        }

        public ICollection<ListAllCarsByMakeServiceModel> SearchByMake(string make)
        {
            var cars = dbContext
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .ProjectTo<ListAllCarsByMakeServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return cars;
        }

        public ICollection<ListAllCarsByModelServiceModel> SearchByModel(string model)
        {
            var cars = dbContext
                .Cars
                .Where(c => c.Model.ToLower() == model.ToLower())
                .ProjectTo<ListAllCarsByModelServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return cars;
        }

        public bool RemoveByModel(string model)
        {
            var cars = dbContext
                .Cars
                .Where(c => c.Model.ToLower() == model.ToLower());

            if (cars == null)
            {
                throw new ArgumentException("Car not found");
            }

            dbContext.Cars.RemoveRange(cars);
            var rowsAffected = dbContext.SaveChanges();

            bool isRemoved = rowsAffected == 1;

            return isRemoved;
        }

        public bool RemoveByMake(string make)
        {
            var cars = dbContext
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower());

            if (cars == null)
            {
                throw new ArgumentException("Car not found");
            }

            dbContext.Cars.RemoveRange(cars);
            var rowAffected = dbContext.SaveChanges();

            bool isRemoved = rowAffected == 1;

            return isRemoved;
        }
    }
}