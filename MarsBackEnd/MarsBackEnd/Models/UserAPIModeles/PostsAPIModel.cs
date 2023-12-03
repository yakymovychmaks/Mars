namespace MarsBackEnd.Models.UserAPIModeles
{
    public class PostsAPIModel
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId {  get; set; }
    }
}
