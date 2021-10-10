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
        private Shape Source = null;
        public double Left    { get; private set; }
        public double Right   { get; private set; }
        public double Top     { get; private set; }
        public double Bottom  { get; private set; }
        public double Width   { get; private set; }
        public double Height  { get; private set; }
        public double Xc      { get; private set; }
        public double Yc      { get; private set; }
        public bool Initiallized { get; private set; }
        public Boundbox() {
        }
        public Boundbox(Shape ishape) {
            this.Source = ishape;
            MsoShapeType     ShapeType     = ishape.Type;
            MsoAutoShapeType ShapeAutoType = ishape.AutoShapeType;
            switch(ShapeType) {
                case MsoShapeType.msoGroup:
                    GroupShapeBoundBox(ishape);
                    break;
                case MsoShapeType.msoLine:
                    NativeShapeBoundbox(ishape);
                    break;
                case MsoShapeType.msoAutoShape:
                    NativeShapeBoundbox(ishape);
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
            bool DebugMode = false;
            if(DebugMode) {this.DebugMode();}
        }
        public Boundbox(double left, double right, double top, double bottom) {
            this.SetParameter( left, right, top, bottom);
        }
        protected void SetParameter(double left,double right,double top,double bottom) {
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
            if(Source != null) {
                Misc.print("Boundbox",Source.Name,Source.Type,Source.AutoShapeType);
            }
            Slide ActiveSlide = Misc.ActiveSlide();
            double R = Math.Pow(Math.Pow(this.Width / 2,2) + Math.Pow(this.Height / 2,2),0.5);
            Shape BoxIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                (float)this.Left,(float)this.Top,(float)this.Width,(float)this.Height);
            Shape TLIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.Left - 2),(float)(this.Top - 2),4,4);
            Shape TRIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.Right - 2),(float)(this.Top - 2),4,4);
            Shape BLIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.Left - 2),(float)(this.Bottom - 2),4,4);
            Shape BRIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.Right - 2),(float)(this.Bottom - 2),4,4);
            Shape RIndicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.Xc - R),(float)(this.Yc - R),(float)R * 2,(float)R * 2);
            BoxIndicator.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(200,200,200).ToArgb();
            TLIndicator.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(200,200,000).ToArgb();
            TRIndicator.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(000,200,200).ToArgb();
            BLIndicator.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(200,000,200).ToArgb();
            BRIndicator.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb(000,200,000).ToArgb();
            RIndicator.Fill.Transparency   = (float)1.0;
            BoxIndicator.Fill.Transparency = (float)0.5;
            TLIndicator.Fill.Transparency  = (float)0.5;
            TRIndicator.Fill.Transparency  = (float)0.5;
            BLIndicator.Fill.Transparency  = (float)0.5;
            BRIndicator.Fill.Transparency  = (float)0.5;
        }

        private void GroupShapeBoundBox(Shape ishape) {
            
            for (int Index = 1; Index <= ishape.GroupItems.Count; Index ++) {
                Boundbox iBox = new Boundbox(ishape.GroupItems[Index]);
                if(Index == 1) {
                    this.SetParameter(iBox.Left,iBox.Right,iBox.Top,iBox.Bottom);
                } else {
                    Boundbox newBox = this + iBox;
                    this.SetParameter(newBox.Left,newBox.Right,newBox.Top,newBox.Bottom);
                }
            }
        }
        private void NotPremitiveShapeBoundbox(Shape ishape) {
            Boundbox iBox = new ShapeData(ishape).Boundbox;
            this.SetParameter(iBox.Left,iBox.Right,iBox.Top,iBox.Bottom);
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

            double xc    = ishape.Left + (ishape.Width  / 2);
            double yc    = ishape.Top  + (ishape.Height / 2);
            double R     = Math.Pow(Math.Pow(ishape.Width / 2,2) + Math.Pow(ishape.Height / 2,2), 0.5);
            double Theta = 90 - Misc.RadToDeg(Math.Atan(ishape.Width / ishape.Height));

            double axis_rotation_tl = AxisRotation + Theta;
            double axis_rotation_tr = Math.Abs(AxisRotation - Theta);

            double[] XArray = new double[4]{
                xc - (R * Math.Cos(Misc.DegToRad(axis_rotation_tl))),
                xc + (R * Math.Cos(Misc.DegToRad(axis_rotation_tr))),
                xc + (R * Math.Cos(Misc.DegToRad(axis_rotation_tl))),
                xc - (R * Math.Cos(Misc.DegToRad(axis_rotation_tr)))};

            double[] YArray = new double[4]{
                yc - (R * Math.Sin(Misc.DegToRad(axis_rotation_tl))),
                yc - (R * Math.Sin(Misc.DegToRad(axis_rotation_tr))),
                yc + (R * Math.Sin(Misc.DegToRad(axis_rotation_tl))),
                yc + (R * Math.Sin(Misc.DegToRad(axis_rotation_tr)))};
            
            this.SetParameter(XArray.Min(),XArray.Max(),YArray.Min(),YArray.Max());
        }
    }

    class LineBoundBox:Boundbox {
        public double X1     { get; private set; }
        public double Y1     { get; private set; }
        public double X2     { get; private set; }
        public double Y2     { get; private set; }
        public double Angle  { get; private set; }
        public double Length { get; private set; }

        public LineBoundBox(){
        }
        public LineBoundBox(Shape Line) {
            Boundbox lBox = new Boundbox(Line);
            this.SetParameter(lBox.Left,lBox.Right,lBox.Top,lBox.Bottom);
            this.Length = Math.Pow(Math.Pow(lBox.Width,2) + Math.Pow(lBox.Height,2),0.5);
            double r = this.Length / 2;
            double BoundboxAngle = Math.Atan(lBox.Height/lBox.Width);
            this.Angle = Line.Rotation + BoundboxAngle;
            double dy = r * Math.Sin(this.Angle);
            double dx = r * Math.Cos(this.Angle);

            double x1 = lBox.Xc - dx;
            double x2 = lBox.Xc + dx;
            double y1 = lBox.Yc - dy;
            double y2 = lBox.Yc + dy;
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = Line.VerticalFlip == MsoTriState.msoTrue ? y2 : y1;
            this.Y2 = Line.VerticalFlip == MsoTriState.msoTrue ? y1 : y2;
            bool DebugMode = true;
            if(DebugMode) { this.DebugMode(Line); }
        }
        public void DebugMode(Shape Line) {
            float TextWidth  = 100;
            float TextHeight = 10;
            float TextSize   = 9;
            float TextOffset = 8;
            float VertexSize = 6;

            Slide ActiveSlide = Misc.ActiveSlide();
            Shape P1Indicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.X1 - VertexSize / 2),(float)(this.Y1 - VertexSize / 2),VertexSize, VertexSize);
            Shape P2Indicator = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                (float)(this.X2 - VertexSize / 2),(float)(this.Y2 - VertexSize / 2),VertexSize, VertexSize);
            Shape TextRectP1 = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                (float)(this.X1 + TextOffset - TextWidth / 2),(float)(this.Y1 - TextOffset - TextHeight / 2),TextWidth,TextHeight);
            Shape TextRectP2 = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                            (float)(this.X2 + TextOffset - TextWidth / 2),(float)(this.Y2 - TextOffset - TextHeight / 2),TextWidth,TextHeight);
            Shape TextRectPc = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                            (float)(this.Xc- TextWidth/2),(float)(this.Top + this.Height + TextOffset + TextHeight / 2),TextWidth,TextHeight);
            TextRectP1.Line.Visible = MsoTriState.msoFalse;
            TextRectP1.Fill.Visible = MsoTriState.msoFalse;
            TextRectP1.TextFrame.TextRange.Font.Size      = TextSize;
            TextRectP1.TextFrame.TextRange.Font.Color.RGB = Misc.ARGB(180,150,5);
            TextRectP1.TextFrame.TextRange.Text           = "P1";
            TextRectP2.Line.Visible = MsoTriState.msoFalse;
            TextRectP2.Fill.Visible = MsoTriState.msoFalse;
            TextRectP2.TextFrame.TextRange.Font.Size      = TextSize;
            TextRectP2.TextFrame.TextRange.Font.Color.RGB = Misc.ARGB(180,150,5);
            TextRectP2.TextFrame.TextRange.Text           = "P2";
            TextRectPc.Line.Visible = MsoTriState.msoFalse;
            TextRectPc.Fill.Visible = MsoTriState.msoFalse;
            TextRectPc.TextFrame.TextRange.Font.Size = TextSize;
            TextRectPc.TextFrame.TextRange.Font.Color.RGB = Misc.ARGB(180,150,5);
            int VFlip = (Line.VerticalFlip   == MsoTriState.msoTrue) ? 1 : 0;
            int HFlip = (Line.HorizontalFlip == MsoTriState.msoTrue) ? 1 : 0;
            TextRectPc.TextFrame.TextRange.Text = String.Format("V{0}_H{1}_R{2}_A{3:F1}", VFlip, HFlip, Line.Rotation, this.Angle);
        }
    }
}
