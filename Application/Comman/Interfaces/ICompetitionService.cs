
public interface ICompetitionService
{
    Task<int> GetScoreAsync(AreaDTO location, ConceptDTO concept);
}