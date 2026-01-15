using Domain.Common;

namespace Domain.Entities;
public class Activity : GeneralBase<int>
{
    public double Penetration { get; set; }
}