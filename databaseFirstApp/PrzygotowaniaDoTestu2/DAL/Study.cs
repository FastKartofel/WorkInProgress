using System;
using System.Collections.Generic;

namespace PrzygotowaniaDoTestu2.DAL;

public partial class Study
{
    public int IdStudies { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
