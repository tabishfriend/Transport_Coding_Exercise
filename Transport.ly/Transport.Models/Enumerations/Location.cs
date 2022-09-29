using System.ComponentModel;

namespace Transport.Models.Enumerations;

public enum Location
{
    [Description("Montreal")]
    YUL,
    [Description("Toronto")]
    YYZ,
    [Description("Calgary")]
    YYC,
    [Description("Vancouver")]
    YVR,
    [Description("Northern Rockies Regional Airport")]
    YYE
}
