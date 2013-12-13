using System;
using System.Collections.Generic;

namespace JsonXml.Test.POCOs
{
    public class PersonFactory
    {
        public static Player CreatePlayer()
        {
            return new Player
                       {
                           ID = Guid.Parse("0d476eb3-0f4d-40ef-81a7-ea9d2bdefc18"),
                           Name = new PersonName { Title = "Mr", FirstName = "Joe", LastName = "Bloggs" },
                           DateOfBirth = new DateTime(1965, 4, 15),
                           Image = new byte[]{ 0x12, 0x15, 0x17},
                           Website = new Uri(@"http://mywebsite.com"),
                           TimeWithClub = new TimeSpan(237, 5, 4, 17),
                           Addresses = new List<Address>
                                           {
                                               new Address { PropertyName = "14", Street = "Some Road", Locality = "Some town", Region = "My county", Country = "My country", PostalCode = "RG5 3AS", Type = AddressType.Home },
                                               new Address { PropertyNumber = 5, Street = "Some Road", Locality = "Some town", Region = "My county", Country = "My country", PostalCode = "RG5 3AS", Type = AddressType.Work },
                                           },
                           TelephoneNumbers = new List<TelephoneNumber>
                                                  {
                                                      new TelephoneNumber { Type = TelephoneType.Home, CountryCode = "44", AreaCode = "151", LocalNumber = "123 4567" },
                                                      new TelephoneNumber { Type = TelephoneType.Work, RawNumber= "+31 (141) 123 4567" },
                                                  },
                           Notes = new List<NoteBase>
                                       {
                                           new SpecialNote
                                               {
                                                   Blah = BlahType.Two,
                                                   Note = "This is some note content unicode-->ᶍ<--unicode",
                                                   Recorded = new DateTimeOffset(2013, 4, 6, 10, 53, 28, 456, TimeSpan.FromHours(5)),
                                               }
                                       }
                       };
        }
    }
}