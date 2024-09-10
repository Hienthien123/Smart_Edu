using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_StudentMapsTuition
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Student size must be between 1 and 100.")]
        public int StudentId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Class size must be between 1 and 100.")]
        public int? ClassId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Tuition size must be between 1 and 100.")]
        public int TuitionId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public double DiscountPercentage { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public double DiscountAmount { get; set; }

        [Required]
        [StringLength(100)]
        public string Note { get; set; }

        public DateTime AppliedDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
