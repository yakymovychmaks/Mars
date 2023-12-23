using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Domain.Extensions
{
    public static class Enumextention
    {
        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName() ?? "Невідомий";
        }
    }
}
