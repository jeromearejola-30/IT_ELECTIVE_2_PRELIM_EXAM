namespace IT_ELECTIVE_2_PRELIM_EXAM.Models
{
    public class Category
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        // EXERCISE 3: Default constructor
        public Category()
        {
            Name = "";
            Description = "";
        }

        // EXERCISE 4: Parameterized constructor
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"Category: {Name} - {Description}";
        }
    }
}