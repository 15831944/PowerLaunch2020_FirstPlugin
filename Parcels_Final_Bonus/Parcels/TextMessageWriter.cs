using System;
using System.IO;
using System.Linq;

namespace Parcels
{
    public class TextMessageWriter : IMessageWriter
    {
        readonly string _filePath;
        protected bool _shouldAppend;
        public TextMessageWriter(string filePath)
        {
            _filePath = filePath;
            _shouldAppend = true;
        }
        public void WriteMessage(string message)
        {
            _shouldAppend = true;
            using (var streamWriter = new StreamWriter(_filePath, _shouldAppend))
            {
                Before(streamWriter);
                streamWriter.WriteLine(message);
                After(streamWriter);
            }
        }

        protected virtual void Before(StreamWriter streamWriter)
        {
            streamWriter.Write($"{Active.Document.Name}");
        }

        protected virtual void After(StreamWriter streamWriter)
        {
            streamWriter.Write(DateTime.Now.ToString());
        }
    }
}
