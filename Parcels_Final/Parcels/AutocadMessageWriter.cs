using System;
using System.Linq;

namespace Parcels
{
    public class AutocadMessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Active.Editor.WriteMessage(message);
        }
    }
}
