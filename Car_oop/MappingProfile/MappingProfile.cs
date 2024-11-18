using AutoMapper;
using Car_oop.Models;
using Car_oop.DTO;
namespace Car_oop.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForCtorParam("Name", opt => opt.MapFrom(g => string.Join(' ', g.name, g.surname)));
            CreateMap<Car, CarDto>();
            CreateMap<ModelCar, ModelDto>()
                .ForCtorParam("Name", opt => opt.MapFrom(x => string.Join(' ', x.model, x.color, x.firm, x.brand)))
                .ForCtorParam("Desription",opt => opt.MapFrom(x => string.Join(x.bodyType, x.driveType, x.fuelType, x.transmissionType)));
            CreateMap<Order, OrderDto>();
            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<Person, PersonalDto>()
                .ForCtorParam("Name", opt => opt.MapFrom(x => string.Join(' ', x.name, x.surname)));
            CreateMap<Post, PostDto>();
        }
    }
}
