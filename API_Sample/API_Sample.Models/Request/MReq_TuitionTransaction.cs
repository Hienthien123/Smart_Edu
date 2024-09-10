using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_TuitionTransaction
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Student size must be between 1 and 100.")]
        public int StudentId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Class size must be between 1 and 100.")]
        public int ClassId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "ClassMonth size must be between 1 and 100.")]
        public int ClassMonth { get; set; }

        [Required]
        [Range(1, 5000, ErrorMessage = "ClassYear size must be between 1 and 5000.")]
        public int ClassYear { get; set; }

        [Required]
        [StringLength(100)]
        public string Note { get; set; }

        [Required]
        [Range(0, 10000000000, ErrorMessage = "Discount percentage must be between 0 and 10000000000.")]
        public double AmountOfMoney { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionType { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionCardNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionCardBrand { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionBankCustomer { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
