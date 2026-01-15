namespace CorporationNetworkWPF.Models
{
    public class Department
    {
        public int DepartmentCode { get; set; }
        public int? MainDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }

    public class CreateDepartmentDto
    {
        public int? MainDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}