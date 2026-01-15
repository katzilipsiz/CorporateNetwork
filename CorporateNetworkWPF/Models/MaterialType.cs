namespace CorporationNetworkWPF.Models
{
    public class MaterialType
    {
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
    }

    public class CreateMaterialTypeDto
    {
        public string TypeName { get; set; }
    }
}