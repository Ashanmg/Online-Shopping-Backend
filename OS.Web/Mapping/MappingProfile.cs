using AutoMapper;
using OS.Entities;
using OS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /************** Api view models to Domain models ****************/
            // Create map for registration 
            CreateMap<UserGeneralModel, AccountUser>()
                .ForMember(au => au.Id, opt => opt.Ignore())
                .ForMember(au => au.HashedPassword, opt => opt.MapFrom(u => u.Password))
                .ForMember(au => au.Address, opt => opt.MapFrom(u => new Address
                {
                    Address1 = u.Address1,
                    Address2 = u.Address2,
                    City = u.City,
                    CountryId = u.CountryId,
                    ZipPostalCode = u.ZipPostalCode,
                    ModifiedOnUTC = DateTime.UtcNow
                }));

            CreateMap<ShoppingCartItemModel, ShoppingCartItem>()
                .ForMember(sci => sci.Id, opt => opt.Ignore())
                .ForMember(sci => sci.AccountUserId, opt => opt.MapFrom(sm => sm.UserId))
                .ForMember(sci => sci.AttributeXml, opt => opt.MapFrom(sm => String.Format("colourId:{0},sizeId:{1}", sm.ColourId, sm.SizeId)))
                .ForMember(sci => sci.Quentity, opt => opt.MapFrom(sm => sm.Quantity));

            /************** Domain model to Api view models ****************/

        }
    }
}
