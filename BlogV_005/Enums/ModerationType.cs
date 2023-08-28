using System.ComponentModel;

namespace BlogV_005.Enums
{
    public enum ModerationType
    {
        [Description("Political propaganda")]
        Political,
        [Description("Not appropriate")]
        Language,
        [Description("Drug selling/promoting")]
        Drugs,
        [Description("Threatening to someone")]
        Threatening,
        [Description("Sexual content")]
        Sexual,
        [Description("Public shaming")]
        Shaming
    }
}
