using Newtonsoft.Json;
using TopRatedApp.Enums;

namespace TopRatedApp.Interfaces
{
    [JsonObject(MemberSerialization.OptIn)]
    public interface ILanguage
    {
        [JsonProperty(PropertyName = "name")]
        string Name { get; set; }

        string ApiName { get; set; }

        string EncodedName { get; set; }

        string Color { get; set; }

        string TextColor { get; set; }

        string TextShadowColor { get; set; }
        
        SectionType SectionType { get; set; }
    }
}