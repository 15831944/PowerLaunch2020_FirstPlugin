using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.IO;
using System.Linq;

namespace Parcels
{
    public class Commands
    {
        [CommandMethod("PS_HELLO")]
        public void Hello()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var editor = document.Editor;

            editor.WriteMessage("\nHello World!");
        }

        [CommandMethod("PS_CREATELAYER")]
        public void CreateLayer()
        {
            var creator = new ParcelLayer();
            creator.Create();
        }

        [CommandMethod("PS_CountParcels")]
        public void CountParcels()
        {
            var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(myDocuments, "ParcelSummary.txt");

            var acadWriter = new AutocadMessageWriter();
            var textWriter = new TextMessageWriter(filePath);
            var htmlWriter = new HtmlMessageWriter(filePath);

            var cmd = new ParcelCounter();
            var summary = cmd.Count();

            IParcelSummaryWriter summarizer = new ParcelSummaryWriter();
            summarizer.Write(summary, acadWriter);
            summarizer.Write(summary, textWriter);

            summarizer = new HtmlParcelSummaryWriter();
            summarizer.Write(summary, htmlWriter);
        }
    }
}
