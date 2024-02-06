using Domain.Enum;

namespace Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
        public List<Apointment>? Apointments { get; set; }
        public List<DocsMeta> Docs { get; set; }
    }
}
