using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Office.Interop.PowerPoint;

namespace AdvShape {
    class ShapeShift {

        static public void Shift(Shape ishape, double? X, double? Y) {
            Boundbox Box = new Boundbox(ishape);
            double dX = X is null ? (double)0 : (double)X;
            double dY = Y is null ? (double)0 : (double)Y;
            ishape.Left += (float)dX;
            ishape.Top  += (float)dY;
        }
        static public void ShiftTo(Shape ishape, double? X, double? Y) {
            /*Boundbox Box = new Boundbox(ishape);
            double dX = X is null ? (double) 0 : ((double)X - Box.Left);
            double dY = Y is null ? (double) 0 : ((double)Y - Box.Top);
            ishape.Left += (float) dX;
            ishape.Top  += (float) dY;*/
            ShiftTo(ishape,X,Y,-1,1);
        }

        static public void ShiftTo(Shape ishape,double? X,double? Y, int ReferenceX = -1, int ReferenceY = 1) {
            Boundbox Box = new Boundbox(ishape);
            double OriginX;
            double OriginY;
            switch(ReferenceX) {
                case -1:
                    OriginX = Box.Left;
                    break;
                case  0:
                    OriginX = Box.Xc;
                    break;
                case  1:
                    OriginX = Box.Right;
                    break;
                default:
                    OriginX = Box.Left;
                    break;
            }
            switch(ReferenceY) {
                case  1:
                    OriginY = Box.Top;
                    break;
                case 0:
                    OriginY = Box.Yc;
                    break;
                case -1:
                    OriginY = Box.Bottom;
                    break;
                default:
                    OriginY = Box.Top;
                    break;
            }
            double dX = X is null ? (double)0 : ((double)X - OriginX);
            double dY = Y is null ? (double)0 : ((double)Y - OriginY);
            ishape.Left += (float)dX;
            ishape.Top  += (float)dY;
        }
    }
}
