using Domain.Common;

namespace Domain.Entities;

public class Community : GeneralBase<int>
{
    public int Code { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int SectorId { get; set; }
    public int PopulationTotal { get; set; } = 0;
    public int PopulationMale { get; set; } = 0;
    public int PopulationFemale { get; set; } = 0;
    public Sector? Sector { get; set; }
}
