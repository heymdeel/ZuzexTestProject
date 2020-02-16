using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZuzexTestProject.Domain.Model;

namespace ZuzexTestProject.UI.ViewModels
{
    public class MapperProfileVM : Profile
    {
        public MapperProfileVM()
        {
            CreateMap<Post, PostsListVM>();
        }
    }
}
