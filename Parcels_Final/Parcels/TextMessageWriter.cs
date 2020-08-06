using System;
using System.IO;
using System.Linq;

namespace Parcels
{
    public class TextMessageWriter : IMessageWriter
    {
        readonly string _filePath;
        public TextMessageWriter(string filePath)
        {
            _filePath = filePath;
        }
        public void WriteMessage(string message)
        {
            bool shouldAppend = true;
            using (var streamWriter = new StreamWriter(_filePath, shouldAppend))
            {
                streamWriter.Write($"{Active.Document.Name}");
                streamWriter.WriteLine(message);
                streamWriter.Write(DateTime.Now.ToString());
            }
        }
    }
}
