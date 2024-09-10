using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Subject
{
    public int Id { get; set; }

    public string SubjectName { get; set; }

    public string SubjectCode { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
