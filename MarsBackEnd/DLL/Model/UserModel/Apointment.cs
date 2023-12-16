using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace DLL.Model.UserModel
{
    public class Apointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime time { get; set; }
        // Інші властивості для призначення

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
