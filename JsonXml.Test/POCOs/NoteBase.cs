using System;

namespace JsonXml.Test.POCOs
{
    public abstract class NoteBase
    {
        public string Note { get; set; }

        public DateTimeOffset Recorded { get; set; }
    }
}