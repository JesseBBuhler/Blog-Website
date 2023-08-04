using System;
using System.Collections.Generic;

namespace My_Thyme.Models;

public partial class Post
{
    public long PostId { get; set; }

    public long AuthorId { get; set; }

    public string? PostText { get; set; }

    public string PublishDate { get; set; } = null!;

    public string? PostTitle { get; set; }

    public string? CoverImg { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
