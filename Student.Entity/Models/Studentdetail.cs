using Student.ViewModels;
using System;
using System.Collections.Generic;

namespace Student.Entity.Models;

public partial class Studentdetail
{
    public int Id { get; set; }

    public Guid StudentId { get; set; }

    public string Name { get; set; } = null!;

    public byte? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public virtual ICollection<Markdetail> Markdetails { get; set; } = new List<Markdetail>();

  

}
