using MediatR;
public class AnalyzeLocationCommand : IRequest<AnalyzeResponse>
{
    public int LocationId { get; set; }
    public int AreaId { get; set; }     
    public int ConceptId { get; set; }
    public int SizeSqft { get; set; }
}
public class AnalyzeLocationHandler
    : IRequestHandler<AnalyzeLocationCommand, AnalyzeResponse>
{
    private readonly IMediator _mediator;
    private readonly ICompetitionService _competitionService;
    private readonly IScoringService _scoring;

    public AnalyzeLocationHandler(
        IMediator mediator,
        ICompetitionService competitionService,
        IScoringService scoring)
    {
        _mediator = mediator;
        _competitionService = competitionService;
        _scoring = scoring;
    }

    public async Task<AnalyzeResponse> Handle(
        AnalyzeLocationCommand request,
        CancellationToken ct)
    {
        var area = await _mediator.Send(
            new GetAreaByIdQuery(request.AreaId), ct);

        var concept = await _mediator.Send(
            new GetConceptByIdQuery(request.ConceptId), ct);

        var competitionScore =
            await _competitionService.GetScoreAsync(area, concept);

        var footfallScore = 75;
        var demographicScore = 70;
        var accessibilityScore = 80;
        var rentalScore = 65;

        var totalScore = _scoring.Calculate(
            footfallScore,
            competitionScore,
            demographicScore,
            accessibilityScore,
            rentalScore);

        return new AnalyzeResponse
        {
            Score = totalScore,
            Recommendation = totalScore >= 70 ? "Strong" : "Medium"
        };
    }
}

