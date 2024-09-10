using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public bool IsSeniorGrade { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
