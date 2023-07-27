namespace My_Thyme.returnObjects
{
    public class returnRecipe
    {
        public long recipeId { get; set; }
        public string? cuisine { get; set; }
        public long? prepTime { get; set; }
        public long? cookTime { get; set; }
        public double? servings { get; set; }
        public string? author { get; set; }
        public string? ingredients { get; set; }
        public string? instructions { get; set; }
        public string? title { get; set; }
        public long rating { get; set; }
        public Dictionary<long, string>? posts { get; set; }
        public List<string>? tags { get; set; }
    }
}
