using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace JsonXml
{
    public class JsonXmlSettings
    {
        public static readonly string JXmlNamespace = @"http://www.xmlsh.org/jxml";

        public static readonly string JsonNetXmlNamespace = @"http://www.json.net/xml";

        public static JsonXmlSettings Defaults
        {
            get 
            {
                var elementDetails = new List<ElementDetails>
                    {
                        new ElementDetails { Element = Elements.Object, LocalName = "object", Namespace = JXmlNamespace },
                        new ElementDetails { Element = Elements.Array, LocalName = "array", Namespace = JXmlNamespace },
                        new ElementDetails { Element = Elements.Property, LocalName = "member", Namespace = JXmlNamespace },
                        new ElementDetails { Element = Elements.PropertyName, LocalName = "name", Namespace = null }, // JXmlNamespace
                        new ElementDetails { Element = Elements.Number, LocalName = "number", Namespace = JXmlNamespace },
                        new ElementDetails { Element = Elements.String, LocalName = "string", Namespace = JXmlNamespace },
                        new ElementDetails { Element = Elements.Boolean, LocalName = "boolean", Namespace = JXmlNamespace },
                        new ElementDetails { Element = Elements.Null, LocalName = "null", Namespace = JXmlNamespace },
                                           
                        new ElementDetails { Element = Elements.Integer, LocalName = "integer", Namespace = JsonNetXmlNamespace },
                        new ElementDetails { Element = Elements.Bytes, LocalName = "bytes", Namespace = JsonNetXmlNamespace },
                        new ElementDetails { Element = Elements.DateTime, LocalName = "dateTime", Namespace = JsonNetXmlNamespace },
                        new ElementDetails { Element = Elements.DateTimeOffset, LocalName = "dateTimeOffset", Namespace = JsonNetXmlNamespace },
                        new ElementDetails { Element = Elements.Duration, LocalName = "duration", Namespace = JsonNetXmlNamespace },
                        new ElementDetails { Element = Elements.Uri, LocalName = "uri", Namespace = JsonNetXmlNamespace },
                        new ElementDetails { Element = Elements.Uuid, LocalName = "uuid", Namespace = JsonNetXmlNamespace },
                    };

                return new JsonXmlSettings(elementDetails);
            }
        }

        public JsonXmlSettings(IEnumerable<ElementDetails> elementDetails)
        {
            LocalNames = elementDetails.ToDictionary(elm => elm.Element, elm => elm.LocalName);
            QualifiedNames = elementDetails.ToDictionary(elm => elm.Element, elm => elm.QualifiedName);
            QualifiedNamesLookup = QualifiedNames.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        public Dictionary<Elements, string> LocalNames { get; private set; }

        public Dictionary<Elements, XName> QualifiedNames { get; private set; }

        public Dictionary<XName, Elements> QualifiedNamesLookup { get; private set; }

        public class ElementDetails
        {
            public Elements Element { get; set; }

            public string LocalName { get; set; }

            public string Namespace { get; set; }

            public XName QualifiedName 
            {
                get 
                {
                    return Namespace == null ? LocalName : XName.Get(LocalName, Namespace); 
                } 
            }
        }
    }
}