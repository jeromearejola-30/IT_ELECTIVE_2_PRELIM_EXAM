namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class Meal
{
    // Private fields
    private string name;
    private string category;
    private string area;
    private string instructions;
    private string thumbnail;
    private string tags;
    private int prepTimeMinutes;

    // Properties
    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Category
    {
        get => category;
        set => category = value;
    }

    public string Area
    {
        get => area;
        set => area = value;
    }

    public string Instructions
    {
        get => instructions;
        set => instructions = value;
    }

    public string Thumbnail
    {
        get => thumbnail;
        set => thumbnail = value;
    }

    public string Tags
    {
        get => tags;
        set => tags = value;
    }

    public int PrepTimeMinutes
    {
        get => prepTimeMinutes;
        set => prepTimeMinutes = value;
    }

    public Meal()
    {
        name = "";
        category = "";
        area = "";
        instructions = "";
        thumbnail = "";
        tags = "";
        prepTimeMinutes = 0;
    }

    public Meal(string name, string category, string area)
    {
        this.name = name;
        this.category = category;
        this.area = area;
        instructions = "";
        thumbnail = "";
        tags = "";
        prepTimeMinutes = 0;
    }

    public override string ToString()
    {
        return $"Meal: {Name} | Category: {Category} | Area: {Area}";
    }
}