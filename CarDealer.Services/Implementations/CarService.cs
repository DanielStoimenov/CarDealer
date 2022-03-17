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
        private readonly CarDealerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarService(CarDealerDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public void AddCar(AddCarInputServiceModel model)
        {
            try
            {
                Car car = _mapper.Map<Car>(model);
                _dbContext.Cars.Add(car);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public ICollection<ListAllCarsServiceModel> GetAll()
        {
            var cars = _dbContext
                .Cars
                .ProjectTo<ListAllCarsServiceModel>(_mapper.ConfigurationProvider)
                .ToList();

            return cars;
        }

        public ICollection<ListAllCarsByMakeServiceModel> SearchByMake(string make)
        {
            var cars = _dbContext
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .ProjectTo<ListAllCarsByMakeServiceModel>(_mapper.ConfigurationProvider)
                .ToList();

            return cars;
        }

        public ICollection<ListAllCarsByModelServiceModel> SearchByModel(string model)
        {
            var cars = _dbContext
                .Cars
                .Where(c => c.Model.ToLower() == model.ToLower())
                .ProjectTo<ListAllCarsByModelServiceModel>(_mapper.ConfigurationProvider)
                .ToList();

            return cars;
        }

        public bool RemoveByModel(string model)
        {
            var cars = _dbContext
                .Cars
                .Where(c => c.Model.ToLower() == model.ToLower());

            if (cars == null)
            {
                throw new ArgumentException("Car not found");
            }

            _dbContext.Cars.RemoveRange(cars);
            var rowsAffected = _dbContext.SaveChanges();

            bool isRemoved = rowsAffected == 1;

            return isRemoved;
        }

        public bool RemoveByMake(string make)
        {
            var cars = _dbContext
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower());

            if (cars == null)
            {
                throw new ArgumentException("Car not found");
            }

            _dbContext.Cars.RemoveRange(cars);
            var rowAffected = _dbContext.SaveChanges();

            bool isRemoved = rowAffected == 1;

            return isRemoved;
        }
    }
}