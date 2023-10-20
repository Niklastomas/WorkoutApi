namespace Domain.Entities;

public abstract class BaseEntity
{
  public Guid Id { get; protected set; }
  public DateTime CreateDate { get; protected set; }
  public DateTime? ModifiedDate { get; protected set; }
}
