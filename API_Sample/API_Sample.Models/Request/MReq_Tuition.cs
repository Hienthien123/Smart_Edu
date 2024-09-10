using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_Tuition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(0, 10000000000, ErrorMessage = "Discount percentage must be between 0 and 10000000000.")]
        public double AmountOfMoney { get; set; }

        [Required]
        [StringLength(100)]
        public string Note { get; set; }
    }
}
