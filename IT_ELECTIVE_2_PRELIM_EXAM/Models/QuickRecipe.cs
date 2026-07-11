namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class QuickRecipe : RecipeBase
{
    public int MaxMinutes { get; set; }

    public QuickRecipe() : base()
    {
        MaxMinutes = 30;
    }

    public QuickRecipe(string title, int prepTime, string difficulty, int maxMinutes)
        : base(title, prepTime, difficulty)
    {
        MaxMinutes = maxMinutes;
    }

    // EXERCISE 8: Use override instead of new
    public override string GetRecipeInfo()
    {
        return $"{base.GetRecipeInfo()} | Quick: Under {MaxMinutes} min";
    }
}