using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_StudentMapsClass
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Student size must be between 1 and 100.")]
        public int StudentId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Class size must be between 1 and 100.")]
        public int ClassId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "BehaviorScore size must be between 1 and 100.")]
        public int BehaviorScore { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "AverageTestScore size must be between 1 and 100.")]
        public int AverageTestScore { get; set; }

    }
}
