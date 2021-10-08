using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeRange =  Microsoft.Office.Interop.PowerPoint.ShapeRange;

namespace AdvShape {
    class ShapeOrder {
        public void ShapeZTop() {
            ShapeRange Selected = Misc.SelectedShapes();
            Selected.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoBringToFront);
        }
        public void ShapeZBottom() {
            ShapeRange Selected = Misc.SelectedShapes();
            Selected.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendToBack);
        }
        public void ShapeZUp() {
            ShapeRange Selected = Misc.SelectedShapes();
            Selected.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoBringForward);
        }
        public void ShapeZDown() {
            ShapeRange Selected = Misc.SelectedShapes();
            Selected.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendBackward);
        }
        public void ShapeZAbove() {
            ShapeRange Selected = Misc.SelectedShapes();
            int TargetOrger  = 0;
            int LowestOrder  = Misc.ActiveSlide().Shapes.Count;
            int HighestOrder = 0;
            if(Selected.Count > 1) {
                for(int i = 0; i < Selected.Count; i++) {
                    int CurrentOrder = Selected[i].ZOrderPosition;
                    if(i == 0) {
                        TargetOrger  = CurrentOrder;
                    } else {
                        LowestOrder  = (LowestOrder  < CurrentOrder) ? LowestOrder  : CurrentOrder;
                        HighestOrder = (HighestOrder > CurrentOrder) ? HighestOrder : CurrentOrder;
                    }
                }
/*                int DeltaOrder = (LowestOrder > TargetOrger) ? */
            }
            
        }
    }
}
