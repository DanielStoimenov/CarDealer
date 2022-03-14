namespace CarDealer.Services.Models.Cars.OutputModels
{
    public class ListAllCarsByModelServiceModel
    {
        public string? Make { get; set; }

        public string? Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}