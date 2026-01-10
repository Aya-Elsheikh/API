using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public abstract class ObjectBase<T> : AuditableEntity
    {
        [Column(Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public T Id { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Column(Order = 1000)]
        public int SortIndex { get; set; }

        [Column(Order = 1001)]
        public bool Focus { get; set; }

        [Column(Order = 1002)]
        public bool Active { get; set; } = true;
    }
}
