using Application.Common.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.Configurations
{
  public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
  {
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
      builder.ToTable(AppConstant.DataBasePrefix + "_UserRole");

      builder.HasOne(d => d.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

      builder.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
    }
  }
}