using System.ComponentModel;
using System.Reflection;

namespace Transport.Models.Enumerations;

public static class EnumerationExtension
{
    /// <summary>
    /// Get the Description from the DescriptionAttribute.
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum enumValue)
    {
        return enumValue.GetType()
                   .GetMember(enumValue.ToString())
                   .First()
                   .GetCustomAttribute<DescriptionAttribute>()?
                   .Description ?? string.Empty;
    }
}
