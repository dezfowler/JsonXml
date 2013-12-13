using System.Collections.Generic;

namespace JsonXml.Test.POCOs
{
    public class Agent : Person, IHasContactInformation
    {
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        public List<Address> Addresses { get; set; }
    }
}