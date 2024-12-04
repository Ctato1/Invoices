using AutoMapper;
using Invoice.API.DTOs;
using Invoice.API.Entities;
namespace Invoice.API.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile() {

            CreateMap<InvoiceEntity, InvoiceDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
        }
    }
}
