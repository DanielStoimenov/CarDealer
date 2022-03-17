using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Persistence;
using CarDealer.Services.Interfaces;
using CarDealer.Services.Models.Parts.OutputModels;

namespace CarDealer.Services.Implementations
{
    public class PartService : IPartService
    {
        private readonly CarDealerDbContext _dbContext;
        private readonly IMapper _mapper;

        public PartService(CarDealerDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public ICollection<ListAllPartsServiceModel> GetAll()
        {
            var parts = _dbContext
                .Parts
                .ProjectTo<ListAllPartsServiceModel>(_mapper.ConfigurationProvider)
                .ToList();

            return parts;
        }
    }
}