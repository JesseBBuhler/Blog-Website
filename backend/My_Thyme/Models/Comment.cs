using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My_Thyme.Models;

public partial class Comment
{
    public long CommentId { get; set; }

    public long PostId { get; set; }

    public long UserId { get; set; }

    public string? CommentText { get; set; }

    public string PublishDate { get; set; } = null!;

    public long? Edited { get; set; }
    [JsonIgnore]
    public virtual Post Post { get; set; } = null!;
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Comment> Originals { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
}
