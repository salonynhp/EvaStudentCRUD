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
          //  CreateMap<Studentdetail, StudentView>().ForAllMembers(dest => dest.StudentView, opt => opt.MapFrom(SqlRowsCopiedEventArgs => SqlRowsCopiedEventArgs);
        }

    }
}
