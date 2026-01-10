using Application.Common.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Contents
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable(AppConstant.DataBasePrefix + "_Sector",
             b => b.IsTemporal(
             b =>
             {
                 b.HasPeriodStart("ValidFrom");
                 b.HasPeriodEnd("ValidTo");
                 b.UseHistoryTable(AppConstant.DataBasePrefix + "_Sector", "Historical");
             }));
            builder.Property(x => x.NameA).HasMaxLength(255);
            builder.Property(x => x.NameE).HasMaxLength(255);
            builder.Property(x => x.FactorBrief).HasMaxLength(1024);

        }
    }
}