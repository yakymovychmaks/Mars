namespace DLL.Models.AdminsModel
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo {  get; set; }
        public DateTime CreateAt { get; set; }
        public Admin Author { get; set; }
    }
    
}
