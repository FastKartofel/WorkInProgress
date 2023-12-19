using System;
using System.Collections.Generic;

namespace PrzygotowaniaDoTestu2.DAL;

public partial class Student
{
    public int IdStudent { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? IndexNumber { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? IdStudies { get; set; }

    public virtual Study? Studies { get; set; }

    public virtual ICollection<StudentGroup> StudentGroup { get; set; } = new List<StudentGroup>();
}
