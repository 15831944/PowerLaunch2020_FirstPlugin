using System;
using System.IO;
using System.Linq;

namespace Parcels
{
    public class ParcelSummaryWriter : IParcelSummaryWriter
    {
        public void Write(ParcelSummary summary, IMessageWriter writer)
        {
            var message = $"Found {summary.Count} parcels.";
            message += $"\nCombined area: {summary.Area:N2}";

            writer.WriteMessage(message);
        }
    }
}
