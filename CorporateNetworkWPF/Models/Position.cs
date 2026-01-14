namespace CorporationNetworkWPF.Models
{
    public class Position
    {
        public int PositionCode { get; set; }
        public string PositionName { get; set; }
        public decimal Salary { get; set; }
    }

    public class CreatePositionDto
    {
        public string PositionName { get; set; }
        public decimal Salary { get; set; }
    }
}