using Student.Entity.Models;
using Student.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Contract
{
    public interface IStudentBusiness
    {
        
        //GET, R
        Task<List<Studentdetail>> GetList();
        Task<List<Studentdetail>> GetMarks();
        //GET ID, R
        Task<Studentdetail> GetStudentById(Guid? ID);
        //PUT, C
        Task AddStu(StudentView payload);
        //POST, U
        Task UpdateById(StudentView payloadstudent);
        //DELETE, D
        Task DeleteById(Guid id);


    }
}
