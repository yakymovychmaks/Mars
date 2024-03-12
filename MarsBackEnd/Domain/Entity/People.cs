using Domain.Enum;

namespace Domain.Entity
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MemberRole MemberRole { get; set; }
        public string Description { get; set; }
        public Photo PeoplePhoto { get; set; }
    }
}