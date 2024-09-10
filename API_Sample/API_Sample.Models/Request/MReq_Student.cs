using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Request
{
    public class MReq_Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Gender size must be between 1 and 100.")]
        public int Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^(?:\+84|0)(3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-9])[0-9]{7}$", ErrorMessage = "Invalid Vietnamese phone number format.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Ethnicity { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Status size must be between 1 and 100.")]
        public int Status { get; set; }

        [Required]
        [StringLength(100)]
        public string Religion { get; set; }

        [Required]
        [StringLength(100)]
        public string IdentificationNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string TaxIdentificationNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Nationality { get; set; }

        [Required]
        [StringLength(100)]
        public string EmergencyContactName { get; set; }

        [Required]
        [StringLength(100)]
        public string EmergencyContactJob { get; set; }

        [Required]
        [StringLength(100)]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string EmergencyContactYearOfBirth { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Role size must be between 1 and 100.")]
        public int RoleId { get; set; }
    }
}
