using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Tuition
{
    public int Id { get; set; }

    public string Title { get; set; }

    public double AmountOfMoney { get; set; }

    public string Note { get; set; }

    public virtual ICollection<StudentMapsTuition> StudentMapsTuitions { get; set; } = new List<StudentMapsTuition>();
}
