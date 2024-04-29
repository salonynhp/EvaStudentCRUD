using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.ViewModels.ViewModels
{
    public class MarkView
    {
        public int Id { get; set; }

        //public Guid SubjectId { get; set; }

        //public Guid StudentId { get; set; }

        public int? TotalMarks { get; set; }

        public int? MarksObtained { get; set; }

        public string? Grade { get; set; }


    // one markdetail can have only one student

       // public  StudentView StudentView { get; set; }
    }
}
