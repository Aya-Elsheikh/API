using Infrastructure.External;

public class CompetitionService : ICompetitionService
{
    private readonly OverpassClient _overpass;

    public CompetitionService(OverpassClient overpass)
    {
        _overpass = overpass;
    }

    public async Task<int> GetScoreAsync(
        AreaDTO location,
        ConceptDTO concept)
    {
        var competitors = await _overpass.CountCompetitorsAsync(
            location.Lat,
            location.Lng,
            concept.GooglePlaceType);

        if (competitors < 5) return 90;
        if (competitors < 10) return 70;
        if (competitors < 20) return 50;

        return 30;
    }
}
