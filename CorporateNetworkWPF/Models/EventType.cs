namespace CorporationNetworkWPF.Models
{
    public class EventType
    {
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
    }

    public class CreateEventTypeDto
    {
        public string TypeName { get; set; }
    }
}