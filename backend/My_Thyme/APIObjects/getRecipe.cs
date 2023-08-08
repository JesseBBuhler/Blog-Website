using My_Thyme.Models;

namespace My_Thyme.returnObjects
{
    public class getRecipe
    {
        public Recipe recipe { get; set; } = new Recipe();
        public List<long> posts { get; set; } = new List<long>();
        public List<long> tags { get; set; } = new List<long>();
        public long rating { get; set; }
    }
}
