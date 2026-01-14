namespace CorporationNetworkWPF.Models
{
    public class Candidate
    {
        public int CandidateNumber { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string SNILS { get; set; }
        public string INN { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class CreateCandidateDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string SNILS { get; set; }
        public string INN { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
    }
}