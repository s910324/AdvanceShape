using System;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using MsoMergeCmd = Microsoft.Office.Core.MsoMergeCmd;
using Slide = Microsoft.Office.Interop.PowerPoint.Slide;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using Selection = Microsoft.Office.Interop.PowerPoint.Selection;
using ShapeRange = Microsoft.Office.Interop.PowerPoint.ShapeRange;

namespace AdvShape {
class Boundbox {
        public double Left    { get; private set; }
        public double Right   { get; private set; }
        public double Top     { get; private set; }
        public double Bottom  { get; private set; }
        public double Width   { get; private set; }
        public double Height  { get; private set; }
        public double Xc      { get; private set; }
        public double Yc      { get; private set; }


        public bool Initiallized { get; private set; }

        public Boundbox(Shape ishape) {
            var ShapeType = ishape.Type;
            var ShapeAutoType = ishape.AutoShapeType;
            switch(ShapeType) {
                case MsoShapeType.msoGroup:
                    GroupShapeBoundBox(ishape);
                    break;
                case MsoShapeType.msoLine:
                    NativeShapeBoundbox(ishape);
                    break;
                case MsoShapeType.msoAutoShape:
                    AutoShapeBoundBox(ishape);
                    break;
                default:
                    switch(ShapeAutoType) {
                        case MsoAutoShapeType.msoShapeNotPrimitive:
                            NotPremitiveShapeBoundbox(ishape);
                            break;
                        default:
                            NativeShapeBoundbox(ishape);
                            break;
                    }
                    break;
            }
            bool DebugMode = true;
            if(DebugMode) {
                Slide ActiveSlide  = Misc.ActiveSlide();
                double R = Math.Pow(Math.Pow(ishape.Width / 2,2) + Math.Pow(ishape.Height / 2,2),0.5);
                Shape BoxIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                    (float)this.Left,(float)this.Top,(float)this.Width,(float)this.Height);
                Shape TLIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                    (float)(this.Left-2),(float)(this.Top-2), 4, 4);
                Shape TRIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                    (float)(this.Right-2),(float)(this.Top-2), 4, 4);
                Shape BLIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                    (float)(this.Left-2),(float)(this.Bottom-2), 4, 4);
                Shape BRIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                    (float)(this.Right-2),(float)(this.Bottom-2), 4, 4);
                Shape RIndicator  = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                    (float)(this.Xc-R),(float)(this.Yc-R),(float)R*2,(float)R*2);
                BoxIndicator.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(200,200,200).ToArgb();
                TLIndicator.Fill.ForeColor.RGB  = System.Drawing.Color.FromArgb(200,200,000).ToArgb();
                TRIndicator.Fill.ForeColor.RGB  = System.Drawing.Color.FromArgb(000,200,200).ToArgb();
                BLIndicator.Fill.ForeColor.RGB  = System.Drawing.Color.FromArgb(200,000,200).ToArgb();
                BRIndicator.Fill.ForeColor.RGB  = System.Drawing.Color.FromArgb(000,200,000).ToArgb();
                RIndicator.Fill.Transparency    = (float)1.0;
                BoxIndicator.Fill.Transparency  = (float)0.5;
                TLIndicator.Fill.Transparency   = (float)0.5;
                TRIndicator.Fill.Transparency   = (float)0.5;
                BLIndicator.Fill.Transparency   = (float)0.5;
                BRIndicator.Fill.Transparency   = (float)0.5;
            }
        }

        public Boundbox() {
        }
        public Boundbox(double left, double right, double top, double bottom) {
            this.SetParameter( left, right, top, bottom);
        }
        private void SetParameter(double left,double right,double top,double bottom) {
            this.Left         = left;
            this.Right        = right;
            this.Top          = top;
            this.Bottom       = bottom;
            this.Width        = right  - left;
            this.Height       = bottom - top;
            this.Xc           = left + this.Width  / 2;
            this.Yc           = top  + this.Height / 2;
            this.Initiallized = true;
        }
        public static Boundbox operator +(Boundbox a,Boundbox b) {
            if(a.Initiallized && !b.Initiallized) {
                return new Boundbox(a.Left,a.Right,a.Top,a.Bottom);
            } else if(!a.Initiallized && b.Initiallized) {
                return new Boundbox(b.Left,b.Right,b.Top,b.Bottom);
            } else {
                if(!a.Initiallized && !b.Initiallized) {
                    return new Boundbox();
                } else {
                    return new Boundbox(
                        Math.Min(a.Left,b.Left),Math.Max(a.Right,b.Right),
                        Math.Min(a.Top,b.Top),Math.Max(a.Bottom,b.Bottom));
                }
            }
        }

        public void DebugMode() {
            Slide ActiveSlide = Misc.ActiveSlide();
            Shape ParentRect = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                    (float)(this.Xc - this.Width / 2),(float)(this.Yc - this.Height / 2),
                    (float)this.Width,(float)this.Height);
            ParentRect.Line.ForeColor.RGB = Misc.ARGB(180,120,90);
            ParentRect.Fill.Transparency  = 0.9f;
            ParentRect.Line.Weight        = 0.5f;
        }

        private void GroupShapeBoundBox(Shape ishape) {
            
            for (int Index = 1; Index <= ishape.GroupItems.Count; Index ++) {
                Boundbox iBox = new Boundbox(ishape.GroupItems[Index]);
                if(Index == 1) {
                    this.Left         = iBox.Left;
                    this.Right        = iBox.Right;
                    this.Top          = iBox.Top;
                    this.Bottom       = iBox.Bottom;
                    this.Initiallized = true;
                } else {
                    Boundbox newBox = this + iBox;
                    this.Left         = newBox.Left;
                    this.Right        = newBox.Right;
                    this.Top          = newBox.Top;
                    this.Bottom       = newBox.Bottom;
                    this.Initiallized = true;
                }
            }
        }
        private void NotPremitiveShapeBoundbox(Shape ishape) {
            Boundbox box      = new ShapeData(ishape).Boundbox;
            this.Left         = box.Left;
            this.Right        = box.Right;
            this.Top          = box.Top;
            this.Bottom       = box.Bottom;
            this.Width        = box.Width;
            this.Height       = box.Height;
            this.Xc           = box.Xc;
            this.Yc           = box.Yc;
            this.Initiallized = true;
        }
        private void AutoShapeBoundBox(Shape shape) {
            Slide iSlide      = Misc.ActiveSlide();
            ShapeRange ishape = shape.Duplicate();
            
            ishape.Left = shape.Left;
            ishape.Top  = shape.Top;
            float xc    = shape.Left + shape.Width  / 2;
            float yc    = shape.Top  + shape.Height / 2;
            Shape iRect = iSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,xc,yc,1,1);
            iSlide.Shapes.Range(new int[] { ishape.ZOrderPosition,iRect.ZOrderPosition }).MergeShapes(MsoMergeCmd.msoMergeUnion, iRect);
            ShapeRange mergeShape = iSlide.Shapes.Range(iSlide.Shapes.Count);
            this.SetParameter(
                mergeShape.Left, mergeShape.Left + mergeShape.Width,
                mergeShape.Top,  mergeShape.Top  + mergeShape.Height);
            mergeShape.Delete();
        }
        private void NativeShapeBoundbox(Shape ishape) {
            double ShapeRotation = (double) ishape.Rotation;
            double AxisRotation  = 0;

            if (0 < ShapeRotation && ShapeRotation <= 90) {
                AxisRotation = ShapeRotation;
            } else if (90 < ShapeRotation && ShapeRotation <= 180) {
                AxisRotation = 90 - (ShapeRotation - 90);
            } else if(180 < ShapeRotation && ShapeRotation <= 270) {
                AxisRotation = ShapeRotation - 180;
            } else if (270 < ShapeRotation && ShapeRotation <= 360) {
                AxisRotation = 90 - (ShapeRotation - 270);
            } else {
                AxisRotation = ShapeRotation;
            }

            this.Xc      = ishape.Left + (ishape.Width  / 2);
            this.Yc      = ishape.Top  + (ishape.Height / 2);
            double R     = Math.Pow(Math.Pow(ishape.Width / 2,2) + Math.Pow(ishape.Height / 2,2), 0.5);
            double Theta = 90 - Misc.RadToDeg(Math.Atan(ishape.Width / ishape.Height));

            double axis_rotation_tl = AxisRotation + Theta;
            double axis_rotation_tr = Math.Abs(AxisRotation - Theta);

            double[] XArray = new double[4]{
                this.Xc - (R * Math.Cos(Misc.DegToRad(axis_rotation_tl))),
                this.Xc + (R * Math.Cos(Misc.DegToRad(axis_rotation_tr))),
                this.Xc + (R * Math.Cos(Misc.DegToRad(axis_rotation_tl))),
                this.Xc - (R * Math.Cos(Misc.DegToRad(axis_rotation_tr)))};

            double[] YArray = new double[4]{
                this.Yc - (R * Math.Sin(Misc.DegToRad(axis_rotation_tl))),
                this.Yc - (R * Math.Sin(Misc.DegToRad(axis_rotation_tr))),
                this.Yc + (R * Math.Sin(Misc.DegToRad(axis_rotation_tl))),
                this.Yc + (R * Math.Sin(Misc.DegToRad(axis_rotation_tr)))};
            
            this.Left   = XArray.Min();
            this.Right  = XArray.Max();
            this.Top    = YArray.Min();
            this.Bottom = YArray.Max();
            this.Width  = this.Right  - this.Left;
            this.Height = this.Bottom - this.Top;
            this.Initiallized = true;
        }
    }
}
