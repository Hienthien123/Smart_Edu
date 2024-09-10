using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public int ClassSize { get; set; }

    public int Credits { get; set; }

    public int? GradeId { get; set; }

    public int? SubjectId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<EmployeeMapsClass> EmployeeMapsClasses { get; set; } = new List<EmployeeMapsClass>();

    public virtual Grade Grade { get; set; }

    public virtual ICollection<StudentMapsClass> StudentMapsClasses { get; set; } = new List<StudentMapsClass>();

    public virtual ICollection<StudentMapsTuition> StudentMapsTuitions { get; set; } = new List<StudentMapsTuition>();

    public virtual Subject Subject { get; set; }

    public virtual ICollection<TuitionTransaction> TuitionTransactions { get; set; } = new List<TuitionTransaction>();
}
