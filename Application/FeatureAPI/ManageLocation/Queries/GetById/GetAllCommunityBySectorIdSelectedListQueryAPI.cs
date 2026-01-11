using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ManageGoal.Queries.GetAll
{
    public class GetAllCommunityBySectorIdSelectedListQueryAPI : IRequest<List<SelectedList>>
    {
        public int SectorId { get; set; }
    }

    public class GetAllCommunityBySectorIdSelectedListQueryAPIHandler : IRequestHandler<GetAllCommunityBySectorIdSelectedListQueryAPI, List<SelectedList>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCommunityBySectorIdSelectedListQueryAPIHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SelectedList>> Handle(GetAllCommunityBySectorIdSelectedListQueryAPI request, CancellationToken cancellationToken)
        {
            var items = await _context.Communities.AsNoTracking()
                .Where(x => x.Active && (request.SectorId == null || request.SectorId == 0 || x.SectorId == request.SectorId))
                .Select(x => new SelectedList { Id = x.Id, NameA = x.NameA, NameE = x.NameE })
                .OrderBy(x => x.NameA)
                .ToListAsync();

            return items;
        }
    }
}
