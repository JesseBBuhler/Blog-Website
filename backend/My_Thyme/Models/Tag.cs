using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My_Thyme.Models;

public partial class Tag
{
    public long TagId { get; set; }

    public string TagName { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
