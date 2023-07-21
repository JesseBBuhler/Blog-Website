using System;
using System.Collections.Generic;

namespace My_Thyme.Models;

public partial class Recipe
{
    public long RecipeId { get; set; }

    public string? Cuisine { get; set; }

    public long? PrepTime { get; set; }

    public long? CookTime { get; set; }

    public double? Servings { get; set; }

    public long AuthorId { get; set; }

    public string? Ingredients { get; set; }

    public string? Instructions { get; set; }

    public string? Title { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
