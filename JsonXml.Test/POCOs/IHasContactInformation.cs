using System.Collections.Generic;

namespace JsonXml.Test.POCOs
{
    public interface IHasContactInformation
    {
        List<TelephoneNumber> TelephoneNumbers { get; set; }

        List<Address> Addresses { get; set; }
    }
}