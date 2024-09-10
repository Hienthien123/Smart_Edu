using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_StudentMapsTuition
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
    }
}
