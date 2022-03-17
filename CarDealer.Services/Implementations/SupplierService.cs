using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Persistence;
using CarDealer.Persistence.Entities;
using CarDealer.Services.Interfaces;
using CarDealer.Services.Models.Supplier.OutputModels;

namespace CarDealer.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext _dbContext;
        private readonly IMapper _mapper;

        public SupplierService(CarDealerDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public ICollection<ListAllSupplierPartsServiceModel> GetAllParts(string supplier)
        {
            var parts = _dbContext
                .Parts
                .Where(p => p.Supplier.Name.ToLower() == supplier.ToLower())
                .ProjectTo<ListAllSupplierPartsServiceModel>(_mapper.ConfigurationProvider)
                .ToList();

            return parts;
        }

        public ICollection<ListAllSuppliersViewModel> GetAllSuppliers()
        {
            var suppliers = _dbContext
                .Suppliers
                .ProjectTo<ListAllSuppliersViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return suppliers;
        }
    }
}