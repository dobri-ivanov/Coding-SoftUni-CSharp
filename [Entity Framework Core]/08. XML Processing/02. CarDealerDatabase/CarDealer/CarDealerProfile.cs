using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSuppliersDto, Supplier>();

            this.CreateMap<ImportPartsDto, Part>()
                .ForMember(d => d.SupplierId,
                opt => opt.MapFrom(s => s.SupplierId.Value));

            this.CreateMap<ImportCarPartDto, Part>();
        }
    }
}
