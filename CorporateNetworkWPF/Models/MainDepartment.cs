using System;

namespace CorporationNetworkWPF.Models
{
    public class MainDepartment
    {
        public int MainDepartmentCode { get; set; }
        public string MainDepartmentName { get; set; }
    }

    public class CreateMainDepartmentDto
    {
        public string MainDepartmentName { get; set; }
    }

    public class UpdateMainDepartmentDto
    {
        public string MainDepartmentName { get; set; }
    }
}