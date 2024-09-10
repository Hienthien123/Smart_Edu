using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
