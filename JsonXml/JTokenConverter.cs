using System;
using System.Linq;
using System.Numerics;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace JsonXml
{
    public class JTokenConverter
    {
        private readonly JsonXmlSettings _settings;

        public JTokenConverter(JsonXmlSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            _settings = settings;
        }

        public XNode ToXNode(JToken jtoken)
        {
            switch (jtoken.Type)
            {
                case JTokenType.None:
                    throw new Exception("Can't convert a None token");
                case JTokenType.Object:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Object],
                        ConvertChildren(jtoken)
                        );
                case JTokenType.Array:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Array],
                        ConvertChildren(jtoken)
                        );
                case JTokenType.Constructor:
                    throw new Exception("Can't convert a Constructor token");
                case JTokenType.Property:
                    var jprop = (JProperty)jtoken;
                    return new XElement(
                        _settings.QualifiedNames[Elements.Property],
                        new XAttribute(
                            _settings.QualifiedNames[Elements.PropertyName],
                            jprop.Name
                            ),
                        ToXNode(jprop.Value)
                        );
                case JTokenType.Comment:
                    return new XComment((string)jtoken);
                case JTokenType.Integer:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Integer],
                        (long)jtoken
                        );
                case JTokenType.Float:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Number],
                        (decimal)jtoken
                        );
                case JTokenType.String:
                    return new XElement(
                        _settings.QualifiedNames[Elements.String],
                        (string)jtoken
                        );
                case JTokenType.Boolean:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Boolean],
                        (bool)jtoken
                        );
                case JTokenType.Null:
                    return new XElement(_settings.QualifiedNames[Elements.Null]);
                case JTokenType.Undefined:
                    throw new Exception("Can't convert a Undefined token");
                case JTokenType.Date:
                    return ConvertDate(jtoken);
                case JTokenType.Raw:
                    throw new Exception("Can't convert a Constructor token");
                case JTokenType.Bytes:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Bytes],
                        Convert.ToBase64String((byte[])jtoken)
                        );
                case JTokenType.Guid:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Uuid],
                        (Guid)jtoken
                        );
                case JTokenType.Uri:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Uri],
                        (Uri)jtoken
                        );
                case JTokenType.TimeSpan:
                    return new XElement(
                        _settings.QualifiedNames[Elements.Duration],
                        (TimeSpan)jtoken
                        );

            }

            throw new Exception("Not recognised");
        }

        public JToken ToJToken(XNode xnode)
        {
            if (xnode.NodeType == XmlNodeType.Document)
            {
                return ToJToken(((XDocument)xnode).Root);
            }

            if (xnode.NodeType != XmlNodeType.Element) throw new Exception("Unexpected node type");

            var xelm = (XElement)xnode;
            Elements elmType;

            if (!_settings.QualifiedNamesLookup.TryGetValue(xelm.Name, out elmType))
            {
                throw new Exception("Unrecognised element name");
            }

            switch(elmType)
            {
                case Elements.Object:
                    return new JObject(ConvertXNodeChildren(xelm));

                case Elements.Array:
                    return new JArray(ConvertXNodeChildren(xelm));
        
                case Elements.Property:
                    return new JProperty(
                        xelm.Attribute(_settings.QualifiedNames[Elements.PropertyName]).Value,
                        ToJToken(xelm.Elements().First()));
                        
                case Elements.Number:
                    return new JValue((decimal)xelm);

                case Elements.Integer:
                    return new JValue((long)xelm);
                
                case Elements.String:
                    return new JValue(xelm.Value);

                case Elements.Boolean:
                    return new JValue((bool)xelm);
                
                case Elements.Null:
                    return new JValue((object)null);

                case Elements.Bytes:
                    return new JValue(Convert.FromBase64String(xelm.Value));

                case Elements.DateTime:
                    return new JValue((DateTime)xelm);
                case Elements.DateTimeOffset:
                    return new JValue((DateTimeOffset)xelm);
                case Elements.Duration:
                    return new JValue((TimeSpan)xelm);
                case Elements.Uri:
                    return new JValue(new Uri(xelm.Value));
                case Elements.Uuid:
                    return new JValue((Guid)xelm);
            }

            throw new Exception("Not recognised");
        }

        private object[] ConvertXNodeChildren(XElement xelm)
        {
            return xelm.Elements().Select(ToJToken).Cast<object>().ToArray();
        }

        private XNode ConvertDate(JToken jtoken)
        {
            var jval = (JValue)jtoken;

            if (jval.Value is DateTime)
            {
                return new XElement(
                    _settings.QualifiedNames[Elements.DateTime],
                    XmlConvert.ToString((DateTime)jval.Value, XmlDateTimeSerializationMode.RoundtripKind)
                    );
            }

            if (jval.Value is DateTimeOffset)
            {
                return new XElement(
                    _settings.QualifiedNames[Elements.DateTimeOffset],
                    XmlConvert.ToString(((DateTimeOffset)jval.Value))
                    );
            }

            throw new Exception("Date type not supported");
        }

        private object[] ConvertChildren(JToken jtoken)
        {
            return jtoken.Children().Select(ToXNode).Cast<object>().ToArray();
        }
    }
}