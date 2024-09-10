using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_Attendance
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Student size must be between 1 and 100.")]
        public int StudentId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Class size must be between 1 and 100.")]
        public int ClassId { get; set; }

        public DateTime ClassDate { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Status size must be between 1 and 100.")]
        public int Status { get; set; }

        [Required]
        [StringLength(100)]
        public string Note { get; set; }
    }
}
