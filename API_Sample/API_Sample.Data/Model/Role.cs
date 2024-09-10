using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
