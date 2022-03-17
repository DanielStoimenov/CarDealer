using CarDealer.Services.Models.Parts.OutputModels;

namespace CarDealer.Services.Interfaces
{
    public interface IPartService
    {
        ICollection<ListAllPartsServiceModel> GetAll();
    }
}