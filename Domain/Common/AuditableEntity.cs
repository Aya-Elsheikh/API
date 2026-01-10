using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public abstract class AuditableEntity
{
    [Column(Order = 1)]
    public Guid OwnerId { get; set; }
    [Column(Order = 2)]
    public Guid? ModifierId { get; set; }
    [Column(Order = 3)]
    public DateTime CreateDate { get; set; }
    [Column(Order = 4)]
    public DateTime? ModifyDate { get; set; }
}
