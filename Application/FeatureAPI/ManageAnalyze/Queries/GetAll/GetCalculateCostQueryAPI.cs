using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FeatureAPI.ManageAnalyze.Queries.GetAll
{
    public record GetCalculateCostQueryAPI(
        int CommunityId,
        int ActivityId,
        int ActivityCategoryId,
        double Area,
        double AnnualRent
    ) : IRequest<AnalyzeResultDTO>;

    public class GetCalculateCostQueryAPIHandler
        : IRequestHandler<GetCalculateCostQueryAPI, AnalyzeResultDTO>
    {
        private const double LicenseCost = 30000;
        private const double EmploymentCost = 28000;
        private const double RiskFactor = 1.3;
        private const int SuccessfulCaseFactor = 50;

        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        public GetCalculateCostQueryAPIHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<AnalyzeResultDTO> Handle(GetCalculateCostQueryAPI request, CancellationToken cancellationToken)
        {
            var community = await _context.Communities
                .Include(c => c.Sector)
                .AsNoTracking()
                .Where(c => c.Id == request.CommunityId)
                .FirstOrDefaultAsync(cancellationToken);

            if (community == null)
                throw new Exception("community not found");

            var activity = await _context.ActivityCategories
                .AsNoTracking()
                .Where(a => a.Id == request.ActivityCategoryId)
                .FirstOrDefaultAsync(cancellationToken);

            if (activity == null)
                throw new Exception("Activity not found");

            double setupCost = request.Area * community.Sector.Factor * activity.Factor;

            double rentWithExtra = request.AnnualRent * 1.2;

            double totalBeforeRisk = setupCost + rentWithExtra + LicenseCost + EmploymentCost;

            double totalCost = totalBeforeRisk * RiskFactor;

            // Get competitors count
            var competitorsResult = await _mediator.Send(
            new GetCompetitorsQuery { Lat = community.Latitude, Lng = community.Longitude, Category = activity.NameE.ToLower(), Radius = 500 }, cancellationToken);

            int competitorsCount = competitorsResult +1;

            int successfulCases =
                competitorsCount * SuccessfulCaseFactor;

            return new AnalyzeResultDTO
            {
                TotalCost = Math.Round(totalCost, 2),
                SuccessfulCases = successfulCases,
                CompetitorsCount = competitorsCount,
            };
        }
    }
}
