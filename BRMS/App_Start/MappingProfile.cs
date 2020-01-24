using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BRMS.Models;
using BRMS.Dtos;

namespace BRMS.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // customers 
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap< CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); ;

            //movies 
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()); ;

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Genre, GenreDto>();
            
        }
       
    }
}