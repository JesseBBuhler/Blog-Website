using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual User Author { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    [JsonIgnore]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    [JsonIgnore]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
