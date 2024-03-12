namespace Domain.Entity
{
    public class PostItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Photo Photo { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
    }
}