using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Slide = Microsoft.Office.Interop.PowerPoint.Slide;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using Selection = Microsoft.Office.Interop.PowerPoint.Selection;
using ShapeRange = Microsoft.Office.Interop.PowerPoint.ShapeRange;
using MsoTriState = Microsoft.Office.Core.MsoTriState;

namespace AdvShape {
    class ShapeArray{
        public enum Mode { 
            Preview = 0,
            Deploy  = 1
        }
        public enum OvalType{ 
            Translation = 0,
            Rotation    = 1
        }

        static public List<ShapeRange> Parallelogram(
            int Row, int Col,float Row_dX,float Row_dY,float Col_dX,float Col_dY, Mode ArrayMode) {
            Slide ActiveSlide           = Misc.ActiveSlide();
            ShapeRange SelectRange      = Misc.SelectedShapes();
            List<ShapeRange> ArrayRange = new List<ShapeRange>();

            float X = SelectRange.Left;
            float Y = SelectRange.Top;
            
            for(int i = 0;i < Row;i++) {
                for(int j = 0;j < Col;j++) {
                    if (!(i == 0 && j == 0)) {
                        ShapeRange iRange = SelectRange.Duplicate();
                        if(ArrayMode == Mode.Preview) {
                            iRange = ShapeArray.PreviewTheme(iRange);
                        }
                        iRange.Left = (float)(X + Misc.CmToPoints(Row_dX) * i + Misc.CmToPoints(Col_dX) * j);
                        iRange.Top  = (float)(Y + Misc.CmToPoints(Row_dY) * i + Misc.CmToPoints(Col_dY) * j);
                        ArrayRange.Add(iRange);
                    }
                }
            }
            return ArrayRange;
        }
        static public List<ShapeRange> Circular(float Radius,int Count, OvalType OType, Mode ArrayMode) {
            Slide ActiveSlide           = Misc.ActiveSlide();
            ShapeRange SelectRange      = Misc.SelectedShapes();
            List<ShapeRange> ArrayRange = new List<ShapeRange>();
            float X       = SelectRange.Left;
            float Y       = SelectRange.Top;
            double dArc   = 2 * Math.PI / Count;
            double dTheta = 2 * 180 / Count;

            for(int i = 0;i < Count;i++) {
                if(i != 0) {
                    ShapeRange iRange = SelectRange.Duplicate();
                    if(ArrayMode == Mode.Preview) {
                        iRange = ShapeArray.PreviewTheme(iRange);
                    }
                    iRange.Left     = (float)(X - Misc.CmToPoints(Radius) * (Math.Cos(dArc * i)-1));
                    iRange.Top      = (float)(Y + Misc.CmToPoints(Radius) * (Math.Sin(dArc * i)));
                    iRange.Rotation = (OType == OvalType.Rotation) ? (float)(iRange.Rotation - dTheta * i): iRange.Rotation;
                    ArrayRange.Add(iRange);
                }
            }
            return ArrayRange;
        }
        static public void Debug() {
            /*Parallelogram(3,6,1,3,5,1,Mode.Preview);*/
            Circular(4,6,OvalType.Rotation, Mode.Preview);
        }

        static private ShapeRange PreviewTheme(ShapeRange iRange) {
            if(iRange.Fill.Visible == MsoTriState.msoTrue) {
                iRange.Fill.ForeColor.RGB = Misc.ARGB(150,150,150);
                iRange.Fill.Transparency = 0.6f;
            }
            if(iRange.Line.Visible == MsoTriState.msoTrue) {
                iRange.Line.ForeColor.RGB = Misc.ARGB(150,150,150);
                iRange.Line.Transparency = 0.6f;
            }
            return iRange;
        }
    }
    
}
