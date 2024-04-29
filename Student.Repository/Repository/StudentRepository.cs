using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Student.Entity;
using Student.Entity.Models;
using Student.Repository.Contract;
using Student.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace Student.Repository.Repository
{

    //DbContext injected to Repository
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentCrudContext _dbContext;
        private readonly IMapper _mapper;

        public StudentRepository(StudentCrudContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        //========================================
        public async Task<List<Studentdetail>> GetList()
        {
            List<Studentdetail> studentlist = new();
            try
            {
                studentlist = await _dbContext.Set<Studentdetail>().ToListAsync();
                return studentlist;
            }
            catch (Exception)
            {
                return studentlist;
            }

        }


         //Left Joint : to display student with matching markdetails
        public async Task<List<Studentdetail>> GetMarks()
        {
             List<Studentdetail> displaymarks= new();

             displaymarks = await _dbContext.Studentdetails //select * from studentdetails
                .Include(_ => _.Markdetails).ToListAsync();

            return displaymarks;
 
        }
         
        
        public async Task<Studentdetail> GetStudentById(Guid? ID)
        {
            Studentdetail std = new();
            var s = await _dbContext.Studentdetails
                .Where(_ => _.StudentId == ID).FirstOrDefaultAsync();
            if (s == null)
                return std;
            return s;

                     
        }
       
        //POSTi
        public async Task AddStu(StudentView payloadstudent)
        {    
            var newmark = _mapper.Map<Studentdetail>(payloadstudent);
            _dbContext.Studentdetails.Add(newmark);
            await _dbContext.SaveChangesAsync();
            //return Created("/Studentdetails/{newmark.StudentId}", newmark);    


        }

        //PUT
        public async Task UpdateById(StudentView payloadstudent)
        {
            var updateStudent = _mapper.Map<Studentdetail>(payloadstudent);
            _dbContext.Studentdetails.Add(updateStudent);
            await _dbContext.SaveChangesAsync();
        }

        //DELETE

        public async Task DeleteById(Guid id)
        {
            try
            {

                var studentdelete = await _dbContext
                    .Studentdetails.Include(_ => _.Markdetails)
                    .FirstOrDefaultAsync();


                _dbContext.Studentdetails.Remove(studentdelete);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return;

            }
        }
        
    }
}
//============================================

//==============================================

/*
       //Manual Mapping

       private Studentdetail MapObject(StudentView payload)
       {
           Studentdetail stu = new();

           //stu.Id = pl.Id;
           stu.Name = payload.Name;
           stu.Gender = payload.Gender;
           stu.Dob = payload.Dob;
           stu.Markdetails = new List<Markdetail>();
           foreach (var item in payload.Markdetail)
           {
               var newmark = new Markdetail();
               newmark.TotalMarks = item.TotalMarks;
               newmark.MarksObtained = item.MarksObtained;
               newmark.Grade = item.Grade;
               stu.Markdetails.Add(newmark);
           }
           return stu;
       }
       */
/*
            Studentdetail s = new();
          
                 var std = await _dbContext.Studentdetails
                     .Include(s => s.StudentId)
                     .Where(s => s.StudentId == StudentId)
                     .Select(s => new StudentView
                     {
                         StudentId = s.StudentId,
                         Name = s.Name,
                         Gender = s.Gender,
                         Dob = s.Dob
                     })
                     .FirstOrDefaultAsync();
                return s; //?????????
            */