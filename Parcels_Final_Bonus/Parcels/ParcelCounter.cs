using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;

namespace Parcels
{
    public class ParcelCounter
    {
        public ParcelSummary Count()
        {
            var summary = new ParcelSummary();
            PromptSelectionResult result = SelectParcels();

            if (result.Status == PromptStatus.OK)
            {
                Active.UsingTransaction(tr =>
                {
                    foreach (var objectId in result.Value.GetObjectIds())
                    {
                        var polyline = (Polyline)tr.GetObject(objectId, OpenMode.ForRead);
                        if (polyline.Closed)
                        {
                            summary.Count++;
                            summary.Area += polyline.Area;
                        }
                    }
                });
            }

            return summary;
        }

        private PromptSelectionResult SelectParcels()
        {
            var options = new PromptSelectionOptions();
            options.MessageForAdding = "Add parcels";
            options.MessageForRemoval = "Remove parcels";

            var filter = new SelectionFilter(new TypedValue[]
            {
                new TypedValue((int)DxfCode.Start, "LWPOLYLINE"),
                new TypedValue((int)DxfCode.LayerName, "Parcels")
            });
            var result = Active.Editor.GetSelection(options, filter);
            return result;
        }
    }
}
