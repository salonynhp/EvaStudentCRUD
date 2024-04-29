using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Student.Entity.Models;
using Student.ViewModels.ViewModels;

namespace Student.Repository.Common
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<StudentView, Studentdetail>();
            CreateMap<MarkView, Markdetail>();

        }

    }
}


/*        public AutoMapperProfiles()
        {
            var config = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Studentdetail, StudentView>();
            });
        }
 * 
 * 
 * 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Studentdetail, StudentView>().ForMember(dest => dest.xyz, act => act.MapFrom(src => src.abc))
                                                  .ForMember(dest.........................MapFrom(src...........))
                                                  .
                                                  .
                                                  .ForMember(....................................................)
            });
            //Syntax to map properties when property names are diff in src[abc] and destDTO[xyz]
            //CreateMap<Source, Destination>().ForMember(dest => dest.xyz, opt => opt.MapFrom(src => src.abc);
            //-----------------------------------------------------------------------------------------------------
            //Syntax to map properties when property names are diff in src[abc] and destDTO[xyz]
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<source, destination>();
            });

            var mapper = new AutoMapperProfiles(config);
            return mapper;
            */