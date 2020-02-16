using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZuzexTestProject.Domain.Model;

namespace ZuzexTestProject.Infrastructure.DTO
{
    public class MapperProfileInfrastructure : Profile
    {
        public MapperProfileInfrastructure()
        {
            CreateMap<CreatePostDTO, Post>();
        }
    }
}
