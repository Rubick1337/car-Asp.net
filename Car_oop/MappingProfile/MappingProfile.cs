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
                .ForCtorParam("name", opt => opt.MapFrom(g => string.Join(' ', g.name, g.surname)));
            CreateMap<ClientForCreationcs,Client>();
            CreateMap<ClientForUpdateDto, Client>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Car, CarDto>();
            CreateMap<CarCreationWithIdDto, Car>();

            CreateMap<ModelCar, ModelDto>()
                .ForCtorParam("Name", opt => opt.MapFrom(x => string.Join(' ', x.model, x.color, x.firm, x.brand)))
                .ForCtorParam("Description", opt => opt.MapFrom(x => string.Join(x.bodyType, x.driveType, x.fuelType, x.transmissionType)));
            CreateMap<ModelCarCreationDto, ModelCar>();
            CreateMap<ModelCarForUpdateDto, ModelCar>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderForUpdateDto, Order>()
                        .ForAllMembers(opts =>
                        opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<PaymentMethodForCreationDto, PaymentMethod>();
            CreateMap<PaymentForUpdateDto, PaymentMethod>()
                 .ForAllMembers(opts =>
                 opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PersonalForCreationDto, Person>();
            CreateMap<Person, PersonalDto>()
                .ForCtorParam("name", opt => opt.MapFrom(x => string.Join(' ', x.name, x.surname)));
            CreateMap<PersonalForUpdateDto, Person>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<Post, PostDto>();

            CreateMap<PostForCreationDto, Post>();
            CreateMap<PostForUpdateDto, Post>()
                .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
