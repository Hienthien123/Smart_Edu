using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class StudentMapsClass
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ClassId { get; set; }

    public int BehaviorScore { get; set; }

    public int AverageTestScore { get; set; }

    public virtual Class Class { get; set; }

    public virtual Student Student { get; set; }
}
