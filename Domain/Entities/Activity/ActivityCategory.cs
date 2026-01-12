using Domain.Common;

namespace Domain.Entities;
public class ActivityCategory : GeneralBase<int>
{
    public double Factor { get; set; }
    public int ActivityId { get; set; }
    public Activity? Activity { get; set; }
}
