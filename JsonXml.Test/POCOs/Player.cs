using System;
using System.Collections.Generic;

namespace JsonXml.Test.POCOs
{
    public class Player : Person, IHasContactInformation, IHasPersonalInformation
    {
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        public List<Address> Addresses { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<NoteBase> Notes { get; set; }

        public byte[] Image { get; set; }

        public Uri Website { get; set; }

        public TimeSpan TimeWithClub { get; set; }
    }
}