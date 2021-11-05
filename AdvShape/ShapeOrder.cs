using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeRange =  Microsoft.Office.Interop.PowerPoint.ShapeRange;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using MsoZOrderCmd = Microsoft.Office.Core.MsoZOrderCmd;

namespace AdvShape {
    class ShapeOrder {
        static public void ShapeZTop() {
            if(Misc.WithActiveSelection()) {
                ShapeRange Selected = Misc.SelectedShapes();
                Selected.ZOrder(MsoZOrderCmd.msoBringToFront);
            }
        }
        static public void ShapeZBottom() {
            if(Misc.WithActiveSelection()) {
                ShapeRange Selected = Misc.SelectedShapes();
                Selected.ZOrder(MsoZOrderCmd.msoSendToBack);
            }
        }
        static public void ShapeZUp() {
            if(Misc.WithActiveSelection()) {
                ShapeRange Selected = Misc.SelectedShapes();
                Selected.ZOrder(MsoZOrderCmd.msoBringForward);
            }
        }
        static public void ShapeZDown() {
            if(Misc.WithActiveSelection()) {
                ShapeRange Selected = Misc.SelectedShapes();
                Selected.ZOrder(MsoZOrderCmd.msoSendBackward);
            }
        }
        static public void ShapeZMoveRelative(int ReletiveOrder) {
            bool       flag     = true;
            
            List<Shape> iShapes = new List<Shape>();

            if(Misc.WithActiveSelection()) {
                ShapeRange Selected = Misc.SelectedShapes();
                Shape TargetShape = Selected[1];
                for(int i = 2;i <= Selected.Count;i++) {iShapes.Add(Selected[i]);}

                while(flag) {
                    var iOrders      = iShapes.Select(i => i.ZOrderPosition);
                    int TargetOrder  = TargetShape.ZOrderPosition + ReletiveOrder;
                    int HighestOrder = iOrders.Max();
                    int LowestOrder  = iOrders.Min();
                    int moveOrder    = 0;

                    switch(Misc.Sign(ReletiveOrder)) {
                        case (1): // ZAbove
                            moveOrder = Misc.Sign(TargetOrder - LowestOrder);
                            break;
                        case (-1): //ZBelow
                            moveOrder = Misc.Sign(TargetOrder - HighestOrder);
                            break;
                        case (0):
                            flag = false;
                            break;
                    }
                    if(moveOrder != 0) {
                        foreach(Shape iShape in iShapes) { ShapeZMove(iShape,moveOrder); }
                    } else {
                        flag = false;
                    }
                }
            }
        }

        static public void ShapeZMove(Shape shape,int DeltaOrder) {
            if(DeltaOrder != 0) {
                MsoZOrderCmd MoveCMD = (DeltaOrder < 0) ? MsoZOrderCmd.msoSendBackward : MsoZOrderCmd.msoBringForward;
                for(int i = 0;i < Math.Abs(DeltaOrder);i++) {
                    shape.ZOrder(MoveCMD);
                }
            }
        }
    }
}
