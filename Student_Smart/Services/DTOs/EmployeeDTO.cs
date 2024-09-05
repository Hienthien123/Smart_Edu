using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Ethnicity { get; set; }   //Dân tộc
        public int Status { get; set; } = 1;
        public string Religion { get; set; }
        public string IdentificationNumber { get; set; }    //CCCD
        public string TaxIdentificationNumber { get; set; } //Mã số thuế
        public string Nationality { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactJob { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string EmergencyContactYearOfBirth { get; set; }
    }
}
