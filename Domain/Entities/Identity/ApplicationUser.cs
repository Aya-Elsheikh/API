using Microsoft.AspNetCore.Identity;


namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public Guid? OwnerId { get; set; }
    public Guid? ModifierId { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? ModifyDate { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NameE { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;
    public string? JobTitle { get; set; }
    public string? Photo { get; set; }
    public string? Organization { get; set; }
    public int LoginCount { get; set; } = 0;
    public DateTime LastLoginDate { get; set; } = DateTime.Now;
    public DateTime LastLogoutDate { get; set; } = DateTime.Now;
    //public int? EntityId { get; set; }
    public bool Admin { get; set; } = false;
    public bool IsCitizen { get; set; } = false;
    public int SortIndex { get; set; } = 0;
    public bool NewsLetterSubscribe { get; set; } = false;
    public DateTime? NewsLetterSubscribeDate { get; set; }
    public bool Locked { get; set; } = false;
    public bool Focus { get; set; } = false;
    public bool Active { get; set; } = true;
    public int? UserTypeId { get; set; }
    public string? NsdbCode { get; set; }
    //identity  
    public ICollection<ApplicationUserRole>? UserRoles { get; set; }
    public ApplicationUser? Owner { get; set; }
    public ApplicationUser? Modifier { get; set; }
    public ICollection<ApplicationUser>? InverseOwners { get; set; }
    public ICollection<ApplicationUser>? InverseModifiers { get; set; }
    public ICollection<ApplicationRole>? RoleOwners { get; set; }
    public ICollection<ApplicationRole>? RoleModifiers { get; set; }
}