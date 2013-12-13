using System.Xml.Linq;

using Newtonsoft.Json.Linq;

namespace JsonXml
{
    public static class JTokenExtensions
    {
        public static XNode ToXNode(this JToken token)
        {
            var converter = new JTokenConverter(JsonXmlSettings.Defaults);
            return converter.ToXNode(token);
        }

        public static JToken ToJToken(this XNode node)
        {
            var converter = new JTokenConverter(JsonXmlSettings.Defaults);
            return converter.ToJToken(node);
        }
    }
}