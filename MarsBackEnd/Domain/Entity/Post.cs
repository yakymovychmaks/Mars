using Domain.Enum;
using Domain.Entity;

namespace Domain.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Photo Photo { get; set; }
        public string Hrefs { get; set; }
        public int UserId { get; set; }
        public List<PostItem> PpostItem { get; set; }
    }
}
