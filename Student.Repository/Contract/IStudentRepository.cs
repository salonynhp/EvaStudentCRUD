using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Entity.Models;
namespace Student.Repository.Contract
{
    public interface IStudentRepository
    {
        Task<List<Studentdetail>> GetList();
        Task<Studentdetail> GetById(Guid id);

        Task<List<Studentdetail>> Add();

        Task<Studentdetail> UpdateById(Guid id);

        Task<Studentdetail> DeleteById(Guid id);
    }
}
