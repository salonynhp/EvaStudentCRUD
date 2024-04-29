using Microsoft.AspNetCore.Mvc;
using Student.Business.Contract;
using Student.ViewModels.ViewModels;
using Student.Entity.Models;
using Microsoft.Identity.Client;
using Student.ViewModels;
using Student.Repository.Contract;
using Student.Repository.Repository;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace EvaStudentCRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        //business injected to Controller :constructor Injection
        private readonly IStudentBusiness _studentBusiness;
        private readonly IMapper _mapper;
        public StudentController(IStudentBusiness StudentBusiness, IMapper mapper)
        {
            _studentBusiness = StudentBusiness;
            _mapper = mapper;
        }
        //--------------------------------( ENDPOINTS)------------------------
        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentBusiness.GetList();

            if (!result.Any())
                return BadRequest();

            return Ok(result);
        }
        [HttpGet]
        [Route("GetMarks")]
        public async Task<IActionResult> GetMarks()
        {
            try
            {
                var stumarkdetails = await _studentBusiness.GetMarks();
                if (stumarkdetails == null)
                {
                    return NotFound();
                }

                return Ok(stumarkdetails);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var result = await _studentBusiness.GetStudentById(id);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        [Route("AddStu")]
        public async Task<IActionResult> AddStu([FromBody] StudentView payloadstudent)
        {

            await _studentBusiness.AddStu(payloadstudent);
            // Guid studentId= await _studentBusiness.AddStu(payloadstudent);
            return Created("Added Student with Marks", payloadstudent);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateById([FromBody] StudentView payloadstudent)
        {
            await _studentBusiness.UpdateById(payloadstudent);
            return Ok("Updated Student");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _studentBusiness.DeleteById(id);
            return Ok("DELETED");
            
        }



    }
}
