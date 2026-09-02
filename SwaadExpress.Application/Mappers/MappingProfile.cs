using AutoMapper;
using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace SwaadExpress.Application.Mappers
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<UserEntity, RegisterUserDto>().ReverseMap();
        }
    }
}
