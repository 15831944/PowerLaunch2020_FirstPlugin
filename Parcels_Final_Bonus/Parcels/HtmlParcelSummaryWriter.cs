using System;
using System.Linq;

namespace Parcels
{
    public class HtmlParcelSummaryWriter : IParcelSummaryWriter
    {
        public void Write(ParcelSummary summary, IMessageWriter writer)
        {
            var message = $@"<!DOCTYPE HTML>
<html>
    <head>
        <title>Parcel Summary</title>
    </head>
    <body>
        <h1>Parcel Summary for {Active.Document.Name}</h1>
        <ul>
            <li>Found {summary.Count} parcels.</li>
            <li>Combined area: {summary.Area:N2}</li>
        </ul>
    </body>
</html>";
            writer.WriteMessage(message);
        }
    }
}
