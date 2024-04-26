using Student.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Contract
{
    public interface IStudentBusiness
    {
        Task<List<Studentdetail>> GetList();
        Task<Studentdetail> GetById(Guid id);

        Task<List<Studentdetail>> Add();

        Task<Studentdetail> UpdateById(Guid id);

        Task<Studentdetail> DeleteById(Guid id);
    }
}
