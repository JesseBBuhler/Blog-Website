using System;
using System.Collections.Generic;

namespace My_Thyme.Models;

public partial class User
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

    public string UserName { get; set; } = null!;

    public string SignUpDate { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserStanding { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual Role Role { get; set; } = null!;
}
