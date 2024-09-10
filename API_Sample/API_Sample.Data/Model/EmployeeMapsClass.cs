using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class EmployeeMapsClass
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Class Class { get; set; }

    public virtual Employee Employee { get; set; }
}
