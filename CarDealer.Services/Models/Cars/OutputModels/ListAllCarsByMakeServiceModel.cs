namespace CarDealer.Services.Models.Cars.OutputModels
{
    public class ListAllCarsByMakeServiceModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}