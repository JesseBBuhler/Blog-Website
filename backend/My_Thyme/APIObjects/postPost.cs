namespace My_Thyme.APIObjects
{
    public class postPost
    {
        public long AuthorId { get; set; }
        public string? PostText { get; set; }
        public string? PostTitle { get; set; }
        public string PublishDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public string? CoverImg { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
