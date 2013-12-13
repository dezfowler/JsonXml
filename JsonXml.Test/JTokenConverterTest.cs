using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using JsonXml.Test.POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace JsonXml.Test
{
    [TestClass]
    public class JTokenConverterTest
    {
        [TestMethod]
        public void Roundtrip_WorksGood()
        {
            Player player = PersonFactory.CreatePlayer();

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            };

            var serializer = JsonSerializer.CreateDefault(settings);

            JToken token = JToken.FromObject(player, serializer);

            var converter = new JTokenConverter(JsonXmlSettings.Defaults);

            var xnode = converter.ToXNode(token);

            var actualXml = new XElement(
                XNamespace.None.GetName("wrap"),
                new XAttribute(XNamespace.Xmlns.GetName("jxml"), "http://www.xmlsh.org/jxml"),
                new XAttribute(XNamespace.Xmlns.GetName("jsonx"), "http://www.json.net/xml"),
                xnode);

            var expectedXml = XDocument.Parse(@"<wrap xmlns:jxml=""http://www.xmlsh.org/jxml"" xmlns:jsonx=""http://www.json.net/xml"">
  <jxml:object>
    <jxml:member name=""TelephoneNumbers"">
      <jxml:array>
        <jxml:object>
          <jxml:member name=""Type"">
            <jsonx:integer>0</jsonx:integer>
          </jxml:member>
          <jxml:member name=""CountryCode"">
            <jxml:string>44</jxml:string>
          </jxml:member>
          <jxml:member name=""AreaCode"">
            <jxml:string>151</jxml:string>
          </jxml:member>
          <jxml:member name=""LocalNumber"">
            <jxml:string>123 4567</jxml:string>
          </jxml:member>
          <jxml:member name=""RawNumber"">
            <jxml:null />
          </jxml:member>
        </jxml:object>
        <jxml:object>
          <jxml:member name=""Type"">
            <jsonx:integer>1</jsonx:integer>
          </jxml:member>
          <jxml:member name=""CountryCode"">
            <jxml:null />
          </jxml:member>
          <jxml:member name=""AreaCode"">
            <jxml:null />
          </jxml:member>
          <jxml:member name=""LocalNumber"">
            <jxml:null />
          </jxml:member>
          <jxml:member name=""RawNumber"">
            <jxml:string>+31 (141) 123 4567</jxml:string>
          </jxml:member>
        </jxml:object>
      </jxml:array>
    </jxml:member>
    <jxml:member name=""Addresses"">
      <jxml:array>
        <jxml:object>
          <jxml:member name=""Type"">
            <jsonx:integer>0</jsonx:integer>
          </jxml:member>
          <jxml:member name=""PropertyNumber"">
            <jxml:null />
          </jxml:member>
          <jxml:member name=""PropertyName"">
            <jxml:string>14</jxml:string>
          </jxml:member>
          <jxml:member name=""Street"">
            <jxml:string>Some Road</jxml:string>
          </jxml:member>
          <jxml:member name=""Locality"">
            <jxml:string>Some town</jxml:string>
          </jxml:member>
          <jxml:member name=""Region"">
            <jxml:string>My county</jxml:string>
          </jxml:member>
          <jxml:member name=""Country"">
            <jxml:string>My country</jxml:string>
          </jxml:member>
          <jxml:member name=""PostalCode"">
            <jxml:string>RG5 3AS</jxml:string>
          </jxml:member>
        </jxml:object>
        <jxml:object>
          <jxml:member name=""Type"">
            <jsonx:integer>1</jsonx:integer>
          </jxml:member>
          <jxml:member name=""PropertyNumber"">
            <jsonx:integer>5</jsonx:integer>
          </jxml:member>
          <jxml:member name=""PropertyName"">
            <jxml:null />
          </jxml:member>
          <jxml:member name=""Street"">
            <jxml:string>Some Road</jxml:string>
          </jxml:member>
          <jxml:member name=""Locality"">
            <jxml:string>Some town</jxml:string>
          </jxml:member>
          <jxml:member name=""Region"">
            <jxml:string>My county</jxml:string>
          </jxml:member>
          <jxml:member name=""Country"">
            <jxml:string>My country</jxml:string>
          </jxml:member>
          <jxml:member name=""PostalCode"">
            <jxml:string>RG5 3AS</jxml:string>
          </jxml:member>
        </jxml:object>
      </jxml:array>
    </jxml:member>
    <jxml:member name=""DateOfBirth"">
      <jsonx:dateTime>1965-04-15T00:00:00</jsonx:dateTime>
    </jxml:member>
    <jxml:member name=""Notes"">
      <jxml:array>
        <jxml:object>
          <jxml:member name=""$type"">
            <jxml:string>JsonXml.Test.POCOs.SpecialNote, JsonXml.Test</jxml:string>
          </jxml:member>
          <jxml:member name=""Blah"">
            <jsonx:integer>1</jsonx:integer>
          </jxml:member>
          <jxml:member name=""Note"">
            <jxml:string>This is some note content unicode--&gt;ᶍ&lt;--unicode</jxml:string>
          </jxml:member>
          <jxml:member name=""Recorded"">
            <jsonx:dateTimeOffset>2013-04-06T10:53:28.456+05:00</jsonx:dateTimeOffset>
          </jxml:member>
        </jxml:object>
      </jxml:array>
    </jxml:member>
    <jxml:member name=""Image"">
      <jsonx:bytes>EhUX</jsonx:bytes>
    </jxml:member>
    <jxml:member name=""Website"">
      <jsonx:uri>http://mywebsite.com/</jsonx:uri>
    </jxml:member>
    <jxml:member name=""TimeWithClub"">
      <jsonx:duration>P237DT5H4M17S</jsonx:duration>
    </jxml:member>
    <jxml:member name=""ID"">
      <jsonx:uuid>0d476eb3-0f4d-40ef-81a7-ea9d2bdefc18</jsonx:uuid>
    </jxml:member>
    <jxml:member name=""Name"">
      <jxml:object>
        <jxml:member name=""Title"">
          <jxml:string>Mr</jxml:string>
        </jxml:member>
        <jxml:member name=""FirstName"">
          <jxml:string>Joe</jxml:string>
        </jxml:member>
        <jxml:member name=""LastName"">
          <jxml:string>Bloggs</jxml:string>
        </jxml:member>
      </jxml:object>
    </jxml:member>
  </jxml:object>
</wrap>").FirstNode;

            Assert.IsTrue(XNode.DeepEquals(expectedXml, actualXml), "XNode should be identical");

            var token2 = converter.ToJToken(xnode);

            var player2 = token2.ToObject<Player>(serializer);

            JToken token3 = JToken.FromObject(player2, serializer);

            Assert.IsTrue(JToken.DeepEquals(token, token3), "Tokens should match");
        }

        [TestMethod]
        public void ToXNode_PrimitiveTypes_WorksGood()
        {
            var values = new List<object>
                {
                    null,
                    true,
                    5,
                    4f,
                    7m,
                    13L,
                    "hello",
                    new DateTime(2013, 5, 19, 14, 55, 36, 235, DateTimeKind.Utc),
                    new DateTimeOffset(2013, 5, 19, 14, 55, 36, 235, TimeSpan.FromHours(-5)),
                    TimeSpan.FromMilliseconds(123456789),
                    new byte[] { 0x12, 0x15, 0x17},
                    new Uri("http://www.google.com/things"),
                    Guid.Parse("0d476eb3-0f4d-40ef-81a7-ea9d2bdefc18"),
                };

            var token = JToken.FromObject(values);
            
            var actual = new XElement(
                XNamespace.None.GetName("wrap"),
                new XAttribute(XNamespace.Xmlns.GetName("jxml"), "http://www.xmlsh.org/jxml"),
                new XAttribute(XNamespace.Xmlns.GetName("jsonx"), "http://www.json.net/xml"),
                token.ToXNode());

            var expected = XDocument.Parse(@"<wrap xmlns:jxml=""http://www.xmlsh.org/jxml"" xmlns:jsonx=""http://www.json.net/xml""><jxml:array>
  <jxml:null />
  <jxml:boolean>true</jxml:boolean>
  <jsonx:integer>5</jsonx:integer>
  <jxml:number>4</jxml:number>
  <jxml:number>7</jxml:number>
  <jsonx:integer>13</jsonx:integer>
  <jxml:string>hello</jxml:string>
  <jsonx:dateTime>2013-05-19T14:55:36.235Z</jsonx:dateTime>
  <jsonx:dateTimeOffset>2013-05-19T14:55:36.235-05:00</jsonx:dateTimeOffset>
  <jsonx:duration>P1DT10H17M36.789S</jsonx:duration>
  <jsonx:bytes>EhUX</jsonx:bytes>
  <jsonx:uri>http://www.google.com/things</jsonx:uri>
  <jsonx:uuid>0d476eb3-0f4d-40ef-81a7-ea9d2bdefc18</jsonx:uuid>
</jxml:array></wrap>").FirstNode;

            Assert.IsTrue(XNode.DeepEquals(expected, actual), "XNode should be identical");
        }

        [TestMethod]
        public void ToJToken_PrimitiveTypes_WorksGood()
        {
            var expected = new List<object>
                {
                    null,
                    true,
                    5L, // Integer comes back as long when cast to object
                    4m, // Float comes back a decimal when cast to object
                    7m,
                    13L,
                    "hello",
                    new DateTime(2013, 5, 19, 14, 55, 36, 235, DateTimeKind.Utc),
                    new DateTimeOffset(2013, 5, 19, 14, 55, 36, 235, TimeSpan.FromHours(-5)),
                    TimeSpan.FromMilliseconds(123456789).ToString(), // TimeSpan comes back as a string
                    new byte[] { 0x12, 0x15, 0x17},
                    "http://www.google.com/things", // URI comes back as string
                    "0d476eb3-0f4d-40ef-81a7-ea9d2bdefc18", // GUID comes back as string
                };

            var xnode = XDocument.Parse(@"<wrap xmlns:jxml=""http://www.xmlsh.org/jxml"" xmlns:jsonx=""http://www.json.net/xml""><jxml:array>
  <jxml:null />
  <jxml:boolean>true</jxml:boolean>
  <jsonx:integer>5</jsonx:integer>
  <jxml:number>4</jxml:number>
  <jxml:number>7</jxml:number>
  <jsonx:integer>13</jsonx:integer>
  <jxml:string>hello</jxml:string>
  <jsonx:dateTime>2013-05-19T14:55:36.235Z</jsonx:dateTime>
  <jsonx:dateTimeOffset>2013-05-19T14:55:36.235-05:00</jsonx:dateTimeOffset>
  <jsonx:duration>P1DT10H17M36.789S</jsonx:duration>
  <jsonx:bytes>EhUX</jsonx:bytes>
  <jsonx:uri>http://www.google.com/things</jsonx:uri>
  <jsonx:uuid>0d476eb3-0f4d-40ef-81a7-ea9d2bdefc18</jsonx:uuid>
</jxml:array></wrap>").Element("wrap").FirstNode;

            var token = xnode.ToJToken();

            var actual = token.ToObject<List<object>>();

            CollectionAssert.AreEqual(expected, actual, StructuralComparisons.StructuralComparer,  "Collections should be the same");
        }
    }
}
