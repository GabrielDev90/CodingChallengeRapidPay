using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RapidPay.Service.Identity.Models.Dto;

namespace RapidPay.Service.Identity
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateUserDto, IdentityUser>();
            });

            return mappingConfig;
        }
    }
}
