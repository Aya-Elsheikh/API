using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
  public class ApplicationRole : IdentityRole<Guid>
  {
    public Guid OwnerId { get; set; }
    public Guid? ModifierId { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? ModifyDate { get; set; }
    public string? Description { get; set; }
    public int SortIndex { get; set; } = 0;
    public bool Focus { get; set; } = false;
    public bool Active { get; set; } = true;

    public ApplicationUser? Owner { get; set; }
    public ApplicationUser? Modifier { get; set; }
    public ICollection<ApplicationUserRole>? UserRoles { get; set; }
  }
}