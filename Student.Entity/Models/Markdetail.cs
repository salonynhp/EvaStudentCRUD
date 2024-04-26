using System;
using System.Collections.Generic;

namespace Student.Entity.Models;

public partial class Markdetail
{
    public int Id { get; set; }

    public Guid SubjectId { get; set; }

    public Guid StudentId { get; set; }

    public int? TotalMarks { get; set; }

    public int? MarksObtained { get; set; }

    public string? Grade { get; set; }

    public virtual Studentdetail Student { get; set; } = null!;
}
