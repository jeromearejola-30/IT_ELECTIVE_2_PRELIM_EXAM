namespace IT_ELECTIVE_2_PRELIM_EXAM.Interfaces;

public interface IRecipeSearchable
{
    string SearchCriteria { get; }

    bool MatchesSearch(string searchTerm);
}