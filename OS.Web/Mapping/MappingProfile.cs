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
            // Api view models to Domain model
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
        }
    }
}
