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


public class StudentBusiness : IStudentBusiness
{

    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    public StudentBusiness(IStudentRepository employeeRepository, IMapper mapper)
    {
        _studentRepository = employeeRepository;
        _mapper = mapper;
    }

    Task<List<Studentdetail>> IStudentBusiness.Add()
    {

        throw new NotImplementedException();
    }

    Task<Studentdetail> IStudentBusiness.DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<Studentdetail> IStudentBusiness.GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<List<Studentdetail>> IStudentBusiness.GetList()
    {
        List<EmployeModel> employeeList = new();

        var result = await _employeeRepository.GetList();

        employeeList = _mapper.Map<List<EmployeModel>>(result);
        return employeeList;
    }

    Task<Studentdetail> IStudentBusiness.UpdateById(Guid id)
    {
        throw new NotImplementedException();
    }
}
