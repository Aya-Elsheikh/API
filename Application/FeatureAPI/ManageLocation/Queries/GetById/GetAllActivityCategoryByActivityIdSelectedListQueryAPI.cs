using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ManageGoal.Queries.GetAll
{
    public class GetAllActivityCategoryByActivityIdSelectedListQueryAPI : IRequest<List<SelectedList>>
    {
        public int ActivityId { get; set; }
    }

    public class GetAllActivityCategoryByActivityIdSelectedListQueryAPIHandler : IRequestHandler<GetAllActivityCategoryByActivityIdSelectedListQueryAPI, List<SelectedList>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllActivityCategoryByActivityIdSelectedListQueryAPIHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SelectedList>> Handle(GetAllActivityCategoryByActivityIdSelectedListQueryAPI request, CancellationToken cancellationToken)
        {
            var items = await _context.ActivityCategories.AsNoTracking()
                .Where(x => x.Active && (request.ActivityId == null || request.ActivityId == 0 || x.ActivityId == request.ActivityId))
                .Select(x => new SelectedList { Id = x.Id, NameA = x.NameA, NameE = x.NameE })
                .OrderBy(x => x.NameA)
                .ToListAsync();

            return items;
        }
    }
}
