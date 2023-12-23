using System;
using Domain.Enum;
using Domain.Entity;

namespace Domain.Entity
{
    public class Comment
    {
            public int Id { get; set; }
            public string Description { get; set; }
            public int PostId { get; set; }
            public Post Post { get; set; }

    }
}
