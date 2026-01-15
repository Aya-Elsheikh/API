using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ManageGoal.Queries.GetAll
{
    public class GetAllActivitySelectedListQueryAPI : IRequest<List<SelectedList>>
    {
    }

    public class GetAllActivitySelectedListQueryAPIHandler : IRequestHandler<GetAllActivitySelectedListQueryAPI, List<SelectedList>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllActivitySelectedListQueryAPIHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SelectedList>> Handle(GetAllActivitySelectedListQueryAPI request, CancellationToken cancellationToken)
        {
            var items = await _context.Activities.AsNoTracking()
                .Where(x => x.Active)
                .Select(x => new SelectedList { Id = x.Id, NameA = x.NameA, NameE = x.NameE })
                .OrderBy(x => x.NameA)
                .ToListAsync();

            return items;
        }
    }
}
