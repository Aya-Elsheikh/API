namespace Application.FeatureAPI.ManageAnalyze.Models
{
    public class LocationHeaderDTO
    {
        public string LocationA { get; set; } = string.Empty;
        public string LocationE { get; set;} = string.Empty;
        public string SubCategoryA { get; set; } = string.Empty;
        public string SubCategoryE { get; set; } = string.Empty;
        public string BusinessTypeA { get; set; } = string.Empty;
        public string BusinessTypeE { get; set; } = string.Empty;
        public double AverageRentPerSqFt { get; set; } = 0;
        public string ExecutiveSummaryA { get; set; } = string.Empty;
        public string ExecutiveSummaryE { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
