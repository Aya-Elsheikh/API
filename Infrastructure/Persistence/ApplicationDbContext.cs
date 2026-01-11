using Application.Common.Constants;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using System.Security.Claims;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        Database = new(this);
    }

    public DatabaseFacade? Database { get; }
    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Sector> Sectors => Set<Sector>();
    public DbSet<Community> Communities => Set<Community>();
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    entry.Entity.OwnerId = new Guid(_httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);

                    entry.Entity.CreateDate = DateTime.Now;
                    break;

                case EntityState.Modified:
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    entry.Entity.ModifierId = new Guid(_httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                    entry.Entity.ModifyDate = DateTime.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        ConfigureIdentityNameConventions(builder);
    }

    private void ConfigureIdentityNameConventions(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<Guid>>().ToTable(AppConstant.DataBasePrefix + "_UserRole");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable(AppConstant.DataBasePrefix + "_UserClaim");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable(AppConstant.DataBasePrefix + "_RoleClaim");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable(AppConstant.DataBasePrefix + "_UserLogin");
        builder.Entity<IdentityUserToken<Guid>>().ToTable(AppConstant.DataBasePrefix + "_UserToken");
    }
}
