using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DatabaseFacade? Database { get; }
    DbSet<ApplicationUser> Users { get; }
    DbSet<Sector> Sectors { get; }
    DbSet<Community> Communities { get; }
    DbSet<Activity> Activities { get; }
    DbSet<ActivityCategory> ActivityCategories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
