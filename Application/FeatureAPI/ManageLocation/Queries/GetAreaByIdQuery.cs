using MediatR;
using System.Linq;

public record GetAreaByIdQuery(int AreaId) : IRequest<AreaDTO>;

public class GetAreaByIdHandler
    : IRequestHandler<GetAreaByIdQuery, AreaDTO>
{
    private readonly JsonReferenceDataLoader _loader;

    public GetAreaByIdHandler(JsonReferenceDataLoader loader)
    {
        _loader = loader;
    }

    public Task<AreaDTO> Handle(GetAreaByIdQuery request, CancellationToken ct)
    {
        var area = _loader.Data.Emirates
            .SelectMany(e => e.Areas)
            .FirstOrDefault(a => a.Id == request.AreaId);

        if (area == null)
            throw new ApplicationException("Area not found");

        return Task.FromResult(new AreaDTO
        {
            Id = area.Id,
            Name = area.Name,
            Lat = area.Lat,
            Lng = area.Lng
        });
    }
}
