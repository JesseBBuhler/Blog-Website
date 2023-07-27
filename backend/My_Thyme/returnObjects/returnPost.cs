namespace My_Thyme.returnObjects
{
    public class returnPost
    {
        public long postId { get; set; }
        public string? authorName { get; set; }
        public string? publishDate { get; set; }
        public string? postTitle { get; set; }
        public Dictionary<long, string>? recipes { get; set; }
        public List<string>? tags { get; set; }
        public string? postText { get;set; }
    }
}
