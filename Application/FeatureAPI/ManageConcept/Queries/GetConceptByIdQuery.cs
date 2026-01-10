using MediatR;
using System;

public record GetConceptByIdQuery(int ConceptId) : IRequest<ConceptDTO>;
public class GetConceptByIdHandler
    : IRequestHandler<GetConceptByIdQuery, ConceptDTO>
{
    private readonly JsonReferenceDataLoader _loader;

    public GetConceptByIdHandler(JsonReferenceDataLoader loader)
    {
        _loader = loader;
    }

    public Task<ConceptDTO> Handle(
        GetConceptByIdQuery request,
        CancellationToken ct)
    {
        var c = _loader.Data.Concepts
            .FirstOrDefault(x => x.Id == request.ConceptId);

        if (c == null)
            throw new ApplicationException("Concept not found");

        return Task.FromResult(new ConceptDTO
        {
            Id = c.Id,
            Name = c.Name,
            GooglePlaceType = c.GooglePlaceType
        });
    }
}
