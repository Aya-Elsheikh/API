using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FeatureAPI.ManageAnalyze.Queries.GetAll
{
    public record GetCalculateCostQueryAPI(
        double Area,
        int CommunityId,
        int ActivityId,
        int ActivityCategoryId,
        double AnnualRent
    ) : IRequest<double>;

    public class GetCalculateCostQueryAPIHandler
        : IRequestHandler<GetCalculateCostQueryAPI, double>
    {
        private const double LicenseCost = 30000;
        private const double EmploymentCost = 28000;
        private const double RiskFactor = 1.3;

        private readonly IApplicationDbContext _context;

        public GetCalculateCostQueryAPIHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<double> Handle(
            GetCalculateCostQueryAPI request,
            CancellationToken cancellationToken)
        {
            var sectorFactor = await _context.Communities
                .AsNoTracking()
                .Where(c => c.Id == request.CommunityId)
                .Select(c => c.Sector.Factor)
                .FirstOrDefaultAsync(cancellationToken);

            if (sectorFactor == 0)
                throw new Exception("Sector factor not found");

            var activityFactor = await _context.ActivityCategories
                .AsNoTracking()
                .Where(a => a.Id == request.ActivityCategoryId)
                .Select(a => a.Factor)
                .FirstOrDefaultAsync(cancellationToken);

            if (activityFactor == 0)
                throw new Exception("Activity factor not found");

            double setupCost =
                request.Area * sectorFactor * activityFactor;

            double rentWithExtra =
                request.AnnualRent * 1.2;

            double totalBeforeRisk =
                setupCost
                + rentWithExtra
                + LicenseCost
                + EmploymentCost;

            double totalCost =
                totalBeforeRisk * RiskFactor;

            return Math.Round(totalCost, 2);
        }
    }
}
