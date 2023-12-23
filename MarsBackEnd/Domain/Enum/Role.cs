using System.ComponentModel.DataAnnotations;

namespace Domain.Enum
{
    public enum Role
    {
        [Display(Name = "Користувач")]
        User = 0,
        [Display(Name = "Модератор")]
        Moderator = 1,
        [Display(Name = "Адмін")]
        Admin = 2,
    }
}

