using Domain.Enum;
using Domain.Entity;

namespace Domain.Entity
{
    public class Post
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
