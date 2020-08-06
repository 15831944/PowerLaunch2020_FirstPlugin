using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using System;
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
            var cmd = new ParcelCounter();
            var summary = cmd.Count();

            Active.Editor.WriteMessage($"\nFound {summary.Count} items.");
            Active.Editor.WriteMessage($"\nTotal Area: {summary.Area:N2}");
        }
    }
}
