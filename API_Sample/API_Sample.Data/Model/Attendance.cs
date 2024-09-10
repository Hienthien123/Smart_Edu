using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Attendance
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public DateTime ClassDate { get; set; }

    public int Status { get; set; }

    public string Note { get; set; }

    public virtual Class Class { get; set; }

    public virtual Student Student { get; set; }
}
