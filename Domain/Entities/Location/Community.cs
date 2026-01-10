using Domain.Common;

namespace Domain.Entities;

public class Community : GeneralBase<int>
{
    public int Code { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int SectorId { get; set; }
    public Sector? Sector { get; set; }
}
