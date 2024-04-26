using Microsoft.EntityFrameworkCore;
using Student.Entity;
using Student.Entity.Models;
using Student.Repository.Contract;

namespace Student.Repository.Repository
{
    public class StudentRepository :IStudentRepository
    {
        private readonly StudentCrudContext _dbContext;

        public StudentRepository(StudentCrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        Task<List<Studentdetail>> IStudentRepository.Add()
        {
            throw new NotImplementedException();
        }

        Task<Studentdetail> IStudentRepository.DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<Studentdetail> IStudentRepository.GetById(Guid id)
        {
            Studentdetail student = new();
            try
            {
                student = await _dbContext.Set<Studentdetail>().AsNoTracking()
                                           .Include(x => x.Markdetails)
                                           .FirstOrDefaultAsync(e => e.StudentId == id);
                return student;
            }
            catch (Exception ex)
            {
                return student;
            }
            //throw new NotImplementedException();
        }

        async Task<List<Studentdetail>> IStudentRepository.GetList()
        {
            List<Studentdetail> studentlist = new();
            try
            {
                studentlist = await _dbContext.Set<Studentdetail>().ToListAsync();
                return studentlist;
            }
            catch (Exception ex)
            {
                return studentlist;
            }
            //throw new NotImplementedException();
        }

        Task<Studentdetail> IStudentRepository.UpdateById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
