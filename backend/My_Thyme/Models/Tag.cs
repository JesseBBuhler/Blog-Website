using System;
using System.Collections.Generic;

namespace My_Thyme.Models;

public partial class Tag
{
    public long TagId { get; set; }

    public string TagName { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
