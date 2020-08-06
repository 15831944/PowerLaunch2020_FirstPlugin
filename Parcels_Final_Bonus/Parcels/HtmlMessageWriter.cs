using System;
using System.IO;
using System.Linq;

namespace Parcels
{
    public class HtmlMessageWriter : TextMessageWriter
    {
        public HtmlMessageWriter(string filePath) : base(filePath)
        {
            _shouldAppend = false;
        }

        protected override void Before(StreamWriter streamWriter)
        { }

        protected override void After(StreamWriter streamWriter)
        { }
    }
}
