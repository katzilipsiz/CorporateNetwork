namespace CorporationNetworkWPF.Models
{
    public class Material
    {
        public int MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public int? MaterialTypeCode { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
    }

    public class CreateMaterialDto
    {
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public int? MaterialTypeCode { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
    }
}