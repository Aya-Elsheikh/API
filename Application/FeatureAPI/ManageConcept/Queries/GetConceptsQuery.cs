using MediatR;

public record GetConceptsQuery : IRequest<List<ConceptDTO>>;
public class GetConceptsHandler
    : IRequestHandler<GetConceptsQuery, List<ConceptDTO>>
{
    private readonly JsonReferenceDataLoader _loader;

    public GetConceptsHandler(JsonReferenceDataLoader loader)
    {
        _loader = loader;
    }

    public Task<List<ConceptDTO>> Handle(
        GetConceptsQuery request,
        CancellationToken ct)
    {
        var result = _loader.Data.Concepts
            .Select(c => new ConceptDTO { Id = c.Id, Name = c.Name, GooglePlaceType = c.GooglePlaceType })
            .ToList();

        return Task.FromResult(result);
    }
}
