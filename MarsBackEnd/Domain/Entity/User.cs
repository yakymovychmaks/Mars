using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string SureNme { get; set; }
        public Profile Profile { get; set; }
        public List<DocsMeta> Docs { get; set; }
    }
}
