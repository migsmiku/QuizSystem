namespace OnlineQuiz.Models.Enum
{
    using System.ComponentModel;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;

    public static class EnumExtensions
    {
        public static string ToDescription(this System.Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return "";
            }
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
