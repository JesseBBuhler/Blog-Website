namespace My_Thyme.APIObjects
{
    public class postPost
    {
        public long PostId { get; set; }
        public long AuthorId { get; set; }
        public string? PostText { get; set; }
        public string? PostTitle { get; set; }
        public string? PublishDate { get; set; }
        public string? CoverImg { get; set; }

    }
}
