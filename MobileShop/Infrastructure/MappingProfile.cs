namespace MobileShop.Infrastructure
{
    using AutoMapper;
    using MobileShop.Data.Entities;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Models.Phones;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<PhoneDetailServiceModel, PhoneFormModel>();
            this.CreateMap<Phone, PhoneIndexServiceModel>();

            this.CreateMap<Phone, PhoneDetailServiceModel>()
                .ForMember(p=> p.UserId, cfg=>cfg.MapFrom(p=>p.Dealer.UserId));
        }
    }
}
