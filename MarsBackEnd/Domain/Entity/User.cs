using Domain.Enum;
using Domain.Entity;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
        public List<Post> Posts { get; set; }
    }
}
