
using System.ComponentModel.DataAnnotations;

namespace API_Sample.Models.Request
{
    public class MReq_Class
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Class size must be between 1 and 100.")]
        public int ClassSize { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Credits size must be between 1 and 100.")]
        public int Credits { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Grade size must be between 1 and 100.")]
        public int? GradeId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Subject size must be between 1 and 100.")]
        public int? SubjectId { get; set; }
    }
}
