using API_Sample.Models.Common;

using System.ComponentModel.DataAnnotations;


namespace API_Sample.Models.Request
{
    public class MReq_Subject : BaseModel.History
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectCode { get; set; }
    }
}
