using BLL.ModelDTOs.UserDTOs;

namespace MarsBackEnd.Models.UserAPIModeles
{
    public class CommentAPImodel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // Інші властивості для коментаря
        public int UserId { get; set; }
        public UserAPIModel User { get; set; }
    }
}
