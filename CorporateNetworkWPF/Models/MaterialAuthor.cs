namespace CorporationNetworkWPF.Models
{
    public class MaterialAuthor
    {
        public int MaterialCode { get; set; }
        public int EmployeeID { get; set; }
    }

    public class CreateMaterialAuthorDto
    {
        public int MaterialCode { get; set; }
        public int EmployeeID { get; set; }
    }
}