using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My_Thyme.Models;

public partial class Role
{
    public long RoleId { get; set; }

    public string RoleName { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
