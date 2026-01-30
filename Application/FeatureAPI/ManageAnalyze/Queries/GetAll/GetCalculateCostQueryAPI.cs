using Application.Common.Interfaces;
using Application.FeatureAPI.ManageAnalyze.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FeatureAPI.ManageAnalyze.Queries.GetAll
{
    public record GetCalculateCostQueryAPI(
        int CommunityId,
        int ActivityId,
        int ActivityCategoryId,
        int Area
    //double AnnualRent
    ) : IRequest<AnalyzeResultDTO>;

    public class GetCalculateCostQueryAPIHandler
        : IRequestHandler<GetCalculateCostQueryAPI, AnalyzeResultDTO>
    {
        private const double LicenseCost = 30000;
        private const double EmploymentCost = 28000;
        private const double RiskFactor = 1.3;
        private const int SuccessfulCaseFactor = 50;
        private const double AnnualRent = 20000;
        private const double FeetPrice = 200;


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
                .Include(a => a.Activity)
                .AsNoTracking()
                .Where(a => a.Id == request.ActivityCategoryId && a.ActivityId == request.ActivityId)
                .FirstOrDefaultAsync(cancellationToken);

            if (activity == null)
                throw new Exception("Activity not found");

            double setupCost = request.Area * community.Factor * activity.Factor;

            double rentWithExtra = AnnualRent * 1.2;

            double totalBeforeRisk = setupCost + rentWithExtra + LicenseCost + EmploymentCost;

            double totalCost = totalBeforeRisk * RiskFactor;

            // Get competitors count
            var competitorsResult = await _mediator.Send(
            new GetCompetitorsQuery
            {
                Lat = community.Latitude,
                Lng = community.Longitude,
                Category = activity.Activity?.NameE?.ToLower() ?? string.Empty,
                Radius = request.Area
            }
            , cancellationToken);

            int competitorsCount = competitorsResult +1;

            int successfulCases =
                competitorsCount * SuccessfulCaseFactor;

            double populationFactor = community.PopulationTotal;

            if (request.ActivityId == 5)
                populationFactor = community.PopulationMale;
            else if (request.ActivityId == 6)
                populationFactor = community.PopulationFemale;

            double score = (populationFactor * 1.3) * (activity.Activity!.Penetration / 100.0) / successfulCases;

            double ppf = (((activity.Factor * 4) + FeetPrice) * community.Factor) / 1000;

            double raw = ppf * score;

            double prof = raw > 0 ? (raw / (raw + 5)) * 10 : 0;

            LocationHeaderDTO location = new LocationHeaderDTO
            {
                LocationA = community.NameA,
                LocationE = community.NameE,
                SubCategoryA = activity.NameA,
                SubCategoryE = activity.NameE,
                BusinessTypeA = activity.Activity.NameA,
                BusinessTypeE = activity.Activity.NameE,
                AverageRentPerSqFt = AnnualRent,
                ExecutiveSummaryA = "يُظهر الموقع حركة مشاة قوية وتركيبة سكانية مناسبة وظهورًا مميزًا للعلامة التجارية، مما يجعله مناسبًا لمفهوم القهوة المختصة.",
                ExecutiveSummaryE = "The location demonstrates strong pedestrian traffic, favorable demographics, and premium brand visibility suitable for a specialty coffee concept.",
                Lat = community.Latitude,
                Lng = community.Longitude,
            };

            return new AnalyzeResultDTO
            {
                Location = location,
                TotalCost = Math.Round(totalCost, 2),
                SuccessfulCases = successfulCases,
                Score = Math.Round(score, 2),
                PPF = Math.Round(ppf, 2),
                Raw = Math.Round(raw, 2),
                Prof = Math.Round(prof, 2),
                CompetitorsCount = competitorsCount,
            };
        }
    }
}
