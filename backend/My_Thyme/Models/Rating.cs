using System;
using System.Collections.Generic;

namespace My_Thyme.Models;

public partial class Rating
{
    public long RecipeId { get; set; }

    public long UserId { get; set; }

    public long Rating1 { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
