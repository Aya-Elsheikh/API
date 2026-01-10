using Domain.Common;

namespace Domain.Entities;

public class Sector : GeneralBase<int>
{
    public int Code { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Factor { get; set; }
    public string? FactorBrief { get; set; }
    public ICollection<Community> Communities { get; set; } = new List<Community>();
}
