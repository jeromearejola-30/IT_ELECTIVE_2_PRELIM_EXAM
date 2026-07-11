using IT_ELECTIVE_2_PRELIM_EXAM.Interfaces;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class MealRecipe : RecipeBase, IRecipeSearchable
{
    public string Category { get; set; } = "";
    public string Area { get; set; } = "";

    public MealRecipe() : base()
    {
    }

    public MealRecipe(string title, int prepTime, string difficulty)
        : base(title, prepTime, difficulty)
    {
    }

    // EXERCISE 7: Constructor with category and area
    public MealRecipe(string title, int prepTime, string difficulty, string category, string area)
        : base(title, prepTime, difficulty)
    {
        Category = category;
        Area = area;
    }

    // EXERCISE 7: Override GetRecipeInfo()
    public override string GetRecipeInfo()
    {
        return $"{base.GetRecipeInfo()} | Category: {Category} | Area: {Area}";
    }

    // EXERCISE 9: IRecipeSearchable implementation
    public string SearchCriteria => Title;

    public bool MatchesSearch(string searchTerm)
    {
        return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }
}