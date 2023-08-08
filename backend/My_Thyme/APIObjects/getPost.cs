using My_Thyme.Models;

namespace My_Thyme.returnObjects
{
    public class getPost
    {
        public Post post { get; set; } = new Post();
        public List<long> recipes { get; set; }  = new List<long>();
        public List<long> tags { get; set; } = new List<long>();
    }
}
