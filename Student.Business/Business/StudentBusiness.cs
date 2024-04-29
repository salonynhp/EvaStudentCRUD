using AutoMapper;
using Student.Business.Contract;
namespace Student.Repository.Contract;
using Student.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Repository.Repository;
using Student.ViewModels.ViewModels;
using Microsoft.EntityFrameworkCore;

public class StudentBusiness : IStudentBusiness
{
    //Repository Injected to Business
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    public StudentBusiness(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

   //==================================================

  

     public async Task<List<Studentdetail>> GetList()
    {
        List<Studentdetail> studentlist = new();

        studentlist = await _studentRepository.GetList();

        studentlist = _mapper.Map<List<Studentdetail>>(studentlist);
        return studentlist;
    }

    public async Task<List<Studentdetail>> GetMarks()
    {
        List<Studentdetail> studentMarkData = new();

        studentMarkData = await _studentRepository.GetMarks();
        studentMarkData= _mapper.Map<List<Studentdetail>>(studentMarkData); 
        return studentMarkData;
    }

    
    
    public async Task<Studentdetail> GetStudentById(Guid? ID)
    {
        Studentdetail studentData = new();

        var result = await _studentRepository.GetStudentById(ID);

        studentData = _mapper.Map<Studentdetail>(result);

     
        return studentData;
        
    }

    public async Task AddStu(StudentView payloadstudent)
    {
        
        await _studentRepository.AddStu(payloadstudent);
       
    }



    public async Task UpdateById(StudentView payloadstudent)
    {
        await _studentRepository.UpdateById(payloadstudent);
    }



    public async Task DeleteById(Guid id)
    {   //Studentdetail studentdelete = new();
        await _studentRepository.DeleteById(id);
        return;
    }

    
}
