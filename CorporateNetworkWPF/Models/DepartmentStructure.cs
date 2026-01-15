namespace CorporationNetworkWPF.Models
{
    public class DepartmentStructure
    {
        public int DepartmentCode { get; set; }
        public int PersonalNumber { get; set; }
        public int PositionCode { get; set; }
    }

    public class CreateDepartmentStructureDto
    {
        public int DepartmentCode { get; set; }
        public int PersonalNumber { get; set; }
        public int PositionCode { get; set; }
    }
}