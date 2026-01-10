using Application.Common.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.Configurations
{
  public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
  {
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
      builder.ToTable(AppConstant.DataBasePrefix + "_Role");
      builder.Property(x => x.Description).HasMaxLength(4000);
      builder.HasOne(x => x.Owner).WithMany(x => x.RoleOwners).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.NoAction); ;
      builder.HasOne(x => x.Modifier).WithMany(x => x.RoleModifiers).HasForeignKey(x => x.ModifierId).OnDelete(DeleteBehavior.NoAction); ;
    }
  }
}
