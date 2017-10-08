using System.Reflection;
using System.ComponentModel;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Summary - Class Provides helper methods for enum classes such as GetDescription() and any other supporting methods/properties required by Enum Classes
    /// </summary>
    public class EnumDescription
    {
        /**
         * Helper method 1 - get Description from Enum class using Reflection class
         */
        public static string GetDescription(object productName)
        {
            string description = "";
            FieldInfo fieldInfo = productName.GetType().GetField(productName.ToString());
            if (fieldInfo != null)
            {
                object[] attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attribute != null && attribute.Length > 0)
                    return ((DescriptionAttribute)attribute[0]).Description;
            }
            return description;
        }
    }
}