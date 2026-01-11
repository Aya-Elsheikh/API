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
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
