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
            Boundbox Box = new Boundbox(ishape);
            double dX = X is null ? (double) 0 : ((double)X - Box.Left);
            double dY = Y is null ? (double) 0 : ((double)Y - Box.Top);
            ishape.Left += (float) dX;
            ishape.Top  += (float) dY;
        }
    }
}
