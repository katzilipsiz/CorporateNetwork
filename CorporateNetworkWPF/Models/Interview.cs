using System;

namespace CorporationNetworkWPF.Models
{
    public class Interview
    {
        public int EmployeeID { get; set; }
        public DateTime InterviewDateTime { get; set; }
        public int CandidateNumber { get; set; }
    }

    public class CreateInterviewDto
    {
        public int EmployeeID { get; set; }
        public DateTime InterviewDateTime { get; set; }
        public int CandidateNumber { get; set; }
    }
}