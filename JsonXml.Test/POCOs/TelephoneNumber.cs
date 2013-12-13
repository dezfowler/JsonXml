namespace JsonXml.Test.POCOs
{
    public class TelephoneNumber
    {
        public TelephoneType Type { get; set; }

        public string CountryCode { get; set; }

        public string AreaCode { get; set; }

        public string LocalNumber { get; set; }

        public string RawNumber { get; set; }
    }
}