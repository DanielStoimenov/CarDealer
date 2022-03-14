using CarDealer.Services.Models.Cars.InputModels;
using CarDealer.Services.Models.Cars.OutputModels;

namespace CarDealer.Services.Interfaces
{
    public interface ICarService
    {
        ICollection<ListAllCarsServiceModel> GetAll();

        ICollection<ListAllCarsByModelServiceModel> SearchByModel(string model);

        ICollection<ListAllCarsByMakeServiceModel> SearchByMake(string make);

        void AddCar(AddCarInputServiceModel model);

        bool RemoveByModel(string model);

        bool RemoveByMake(string make);
    }
}
