using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LCWProject.Bussiness.DTO.Product;
using LCWProject.Entities.Concrete;

namespace LCWProject.API.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
