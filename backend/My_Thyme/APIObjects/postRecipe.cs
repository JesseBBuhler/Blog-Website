namespace My_Thyme.APIObjects
{
    public class postRecipe
    {
        public string? Cuisine { get; set; }

        public long? PrepTime { get; set; }

        public long? CookTime { get; set; }

        public double? Servings { get; set; }

        public long AuthorId { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        public string? Title { get; set; }
    }
}
