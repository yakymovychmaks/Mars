using Domain.Enum;
using Domain.Entity;

namespace Domain.Entity
{
    public class User
    {
            public long Id { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public Role Role { get; set; }
            public Profiles Profile { get; set; }
            public List<Post>? Posts { get; set; }
    }
}
