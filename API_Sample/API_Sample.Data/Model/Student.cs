using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class Student
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Code { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public int Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Ethnicity { get; set; }

    public int Status { get; set; }

    public string Religion { get; set; }

    public string IdentificationNumber { get; set; }

    public string TaxIdentificationNumber { get; set; }

    public string Nationality { get; set; }

    public string EmergencyContactName { get; set; }

    public string EmergencyContactJob { get; set; }

    public string EmergencyContactNumber { get; set; }

    public string EmergencyContactYearOfBirth { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Role Role { get; set; }

    public virtual ICollection<StudentMapsClass> StudentMapsClasses { get; set; } = new List<StudentMapsClass>();

    public virtual ICollection<StudentMapsTuition> StudentMapsTuitions { get; set; } = new List<StudentMapsTuition>();

    public virtual ICollection<TuitionTransaction> TuitionTransactions { get; set; } = new List<TuitionTransaction>();
}
