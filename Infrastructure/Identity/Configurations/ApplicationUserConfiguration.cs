using Application.Common.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.Configurations
{
  public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
  {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
      builder.ToTable(AppConstant.DataBasePrefix + "_User");
      builder.Property(x => x.Name).HasMaxLength(255);
      builder.Property(x => x.NormalizedName).HasMaxLength(255);
      builder.HasOne(x => x.Owner).WithMany(x => x.InverseOwners).OnDelete(DeleteBehavior.NoAction);
      builder.HasOne(x => x.Modifier).WithMany(x => x.InverseModifiers).OnDelete(DeleteBehavior.NoAction);
    }
  }
}
