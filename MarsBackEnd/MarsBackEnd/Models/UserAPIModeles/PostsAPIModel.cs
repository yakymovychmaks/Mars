namespace MarsBackEnd.Models.UserAPIModeles
{
    public class PostsAPIModel
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public DateTime CreateAt { get; set; }
 //       public AdminAPIModel Author { get; set; }
    }
}
