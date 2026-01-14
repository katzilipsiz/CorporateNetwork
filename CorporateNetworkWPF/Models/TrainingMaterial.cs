namespace CorporationNetworkWPF.Models
{
    public class TrainingMaterial
    {
        public int TrainingCode { get; set; }
        public int MaterialCode { get; set; }
    }

    public class CreateTrainingMaterialDto
    {
        public int TrainingCode { get; set; }
        public int MaterialCode { get; set; }
    }
}