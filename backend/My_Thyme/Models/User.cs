using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    [JsonIgnore]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    [JsonIgnore]
    public virtual Role Role { get; set; } = null!;
}
