using MediatR;

public record GetEmiratesQuery : IRequest<List<LocationDTO>>;
public class GetEmiratesHandler
    : IRequestHandler<GetEmiratesQuery, List<LocationDTO>>
{
    private readonly JsonReferenceDataLoader _loader;

    public GetEmiratesHandler(JsonReferenceDataLoader loader)
    {
        _loader = loader;
    }

    public Task<List<LocationDTO>> Handle(
        GetEmiratesQuery request,
        CancellationToken ct)
    {
        var result = _loader.Data.Emirates
            .Select(e => new LocationDTO
            {
                Id = e.Id,
                Name = e.Name,
                Lat = e.Lat,
                Lng = e.Lng,
                Areas = e.Areas.Select(a =>
                    new AreaDTO { Id = a.Id, Name = a.Name , EmirateId = a.EmirateId , Lat = e.Lat , Lng = e.Lng }).ToList()
            })
            .ToList();

        return Task.FromResult(result);
    }
}
