using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_EmployeeMapsClass
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Class size must be between 1 and 100.")]
        public int ClassId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Employee size must be between 1 and 100.")]
        public int EmployeeId { get; set; }
    }
}
