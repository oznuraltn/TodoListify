

namespace Core.Entities;

public abstract class BaseEntityWithDates<TId> : Entity<TId>
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
