namespace CorporationNetworkWPF.Models
{
    public class EventStatus
    {
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
    }

    public class CreateEventStatusDto
    {
        public string StatusName { get; set; }
    }
}