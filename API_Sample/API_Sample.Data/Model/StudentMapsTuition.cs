using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class StudentMapsTuition
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int? ClassId { get; set; }

    public int TuitionId { get; set; }

    public double DiscountPercentage { get; set; }

    public double DiscountAmount { get; set; }

    public string Note { get; set; }

    public DateTime AppliedDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Class Class { get; set; }

    public virtual Student Student { get; set; }

    public virtual Tuition Tuition { get; set; }
}
