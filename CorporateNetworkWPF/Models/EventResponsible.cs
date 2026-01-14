namespace CorporationNetworkWPF.Models
{
    public class EventResponsible
    {
        public int EventCode { get; set; }
        public int EmployeeID { get; set; }
    }

    public class CreateEventResponsibleDto
    {
        public int EventCode { get; set; }
        public int EmployeeID { get; set; }
    }
}