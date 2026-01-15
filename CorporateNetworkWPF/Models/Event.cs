using System;

namespace CorporationNetworkWPF.Models
{
    public class Event
    {
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public int StatusCode { get; set; }
        public int TypeCode { get; set; }
        public DateTime EventDateTime { get; set; }
        public string ShortDescription { get; set; }
    }

    public class CreateEventDto
    {
        public string EventName { get; set; }
        public int StatusCode { get; set; }
        public int TypeCode { get; set; }
        public DateTime EventDateTime { get; set; }
        public string ShortDescription { get; set; }
    }
}