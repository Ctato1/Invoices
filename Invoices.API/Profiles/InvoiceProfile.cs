using AutoMapper;
using Invoice.API.DTOs;
using Invoice.API.Entities;
namespace Invoice.API.Profiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile() { 
        
            CreateMap<InvoiceEntity, InvoiceDTO>().ReverseMap();
            CreateMap<InvoiceEntity, InvoicesForCreatingDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemDTO>().ReverseMap();
        }
    }
}
