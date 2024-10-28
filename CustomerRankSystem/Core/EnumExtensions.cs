using System.ComponentModel;
using System.Reflection;

namespace CustomerRankSystem.Core
{
    public static class EnumExtensions
    {
        public static string Description(this Enum val)
        {
            Type type = val.GetType();
            string text = val.ToString();
            FieldInfo field = type.GetField(text);
            if (field == null)
            {
                return val.ToString();
            }

            return (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute) ? descriptionAttribute.Description : text;
        }
    }
}
