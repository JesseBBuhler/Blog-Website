using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace My_Thyme.Models;

public partial class Post
{
    public long PostId { get; set; }

    public long AuthorId { get; set; }

    public string? PostText { get; set; }

    public string PublishDate { get; set; } = null!;

    public string? PostTitle { get; set; }

    [Column("cover_img")]
    public string? CoverImg { get; set; }
    [JsonIgnore]
    public virtual User Author { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    [JsonIgnore]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
