using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ManageGoal.Queries.GetAll
{
    public class GetAllSectorsSelectedListQueryAPI : IRequest<List<SelectedList>>
    {
    }

    public class GetAllSectorsSelectedListQueryAPIHandler : IRequestHandler<GetAllSectorsSelectedListQueryAPI, List<SelectedList>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSectorsSelectedListQueryAPIHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SelectedList>> Handle(GetAllSectorsSelectedListQueryAPI request, CancellationToken cancellationToken)
        {
            var items = await _context.Sectors.AsNoTracking()
                .Where(x => x.Active)
                .Select(x => new SelectedList { Id = x.Id, NameA = x.NameA, NameE = x.NameE })
                .OrderBy(x => x.NameA)
                .ToListAsync();

            return items;
        }
    }
}
