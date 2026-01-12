using Application.Common.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Contents
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable(AppConstant.DataBasePrefix + "_Activity",
             b => b.IsTemporal(
             b =>
             {
                 b.HasPeriodStart("ValidFrom");
                 b.HasPeriodEnd("ValidTo");
                 b.UseHistoryTable(AppConstant.DataBasePrefix + "_Activity", "Historical");
             }));
            builder.Property(x => x.NameA).HasMaxLength(255);
            builder.Property(x => x.NameE).HasMaxLength(255);

        }
    }
}