using System;

namespace CorporationNetworkWPF.Models
{
    public class Employee
    {
        public int PersonalNumber { get; set; }
        public string FullName { get; set; }
        public int DepartmentCode { get; set; }
        public int PositionCode { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class CreateEmployeeDto
    {
        public string FullName { get; set; }
        public int DepartmentCode { get; set; }
        public int PositionCode { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public string AdditionalInfo { get; set; }
    }
}