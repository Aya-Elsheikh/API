using Application.Common.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Contents
{
    public class ActivityCategoryConfiguration : IEntityTypeConfiguration<ActivityCategory>
    {
        public void Configure(EntityTypeBuilder<ActivityCategory> builder)
        {
            builder.ToTable(AppConstant.DataBasePrefix + "_ActivityCategory",
             b => b.IsTemporal(
             b =>
             {
                 b.HasPeriodStart("ValidFrom");
                 b.HasPeriodEnd("ValidTo");
                 b.UseHistoryTable(AppConstant.DataBasePrefix + "_ActivityCategory", "Historical");
             }));
            builder.Property(x => x.NameA).HasMaxLength(255);
            builder.Property(x => x.NameE).HasMaxLength(255);

        }
    }
}