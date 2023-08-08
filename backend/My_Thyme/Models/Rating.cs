using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My_Thyme.Models;

public partial class Rating
{
    public long RecipeId { get; set; }

    public long UserId { get; set; }

    public long Rating1 { get; set; }
    [JsonIgnore]
    public virtual Recipe Recipe { get; set; } = null!;
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
