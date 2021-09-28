using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Office.Interop.PowerPoint;

namespace AdvShape {

    class ShapeAlign {
        public enum Mode{
        ShapeAlign             = 0b0000000,
        ShapeAlignTop          = 0b0100000,
        ShapeAlignMid          = 0b0010000,
        ShapeAlignBottom       = 0b0001000,
        ShapeAlignLeft         = 0b0000100,
        ShapeAlignCenter       = 0b0000010,
        ShapeAlignRight        = 0b0000001,

        ShapeAlignTopLeft      = 0b0100100,
        ShapeAlignTopCenter    = 0b0100010,
        ShapeAlignTopRight     = 0b0100001,
        ShapeAlignMidLeft      = 0b0010100,
        ShapeAlignMidCenter    = 0b0010010,
        ShapeAlignMidRight     = 0b0010001,
        ShapeAlignBottomLeft   = 0b0001100,
        ShapeAlignBottomCenter = 0b0001010,
        ShapeAlignBottomRight  = 0b0001001,

        ShapeSnap              = 0b1000000,
        ShapeSnapTop           = 0b1100000,
        ShapeSnapBottom        = 0b1001000,
        ShapeSnapLeft          = 0b1000100,
        ShapeSnapRight         = 0b1000001,

        ShapeSnapTopLeft       = 0b1100100,
        ShapeSnapTopRight      = 0b1100001,
        ShapeSnapBottomLeft    = 0b1001100,
        ShapeSnapBottomRight   = 0b1001001
    }
        static public void Align(Shape AnchorShape, Shape FloatShape, Mode AlignMode) {
            Boundbox AnchorBox = new Boundbox(AnchorShape);
            Boundbox FloatBox  = new Boundbox(FloatShape);

            if(ModeContain(AlignMode,Mode.ShapeAlignTop)) {
                ShapeShift.Shift(FloatShape,null,AnchorBox.Top - FloatBox.Top);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignMid)) {
                ShapeShift.Shift(FloatShape,null,AnchorBox.Yc - FloatBox.Yc);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignBottom)) {
                ShapeShift.Shift(FloatShape,null,AnchorBox.Bottom - FloatBox.Bottom);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignLeft)) {
                ShapeShift.Shift(FloatShape,AnchorBox.Left  - FloatBox.Left , null);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignCenter)) {
                ShapeShift.Shift(FloatShape,AnchorBox.Xc    - FloatBox.Xc,    null);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignRight)) {
                ShapeShift.Shift(FloatShape,AnchorBox.Right - FloatBox.Right, null);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapTop)) {
                ShapeShift.Shift(FloatShape,null,AnchorBox.Top - FloatBox.Bottom);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapBottom)) {
                ShapeShift.Shift(FloatShape,null,AnchorBox.Bottom - FloatBox.Top);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapLeft)) {
                ShapeShift.Shift(FloatShape,AnchorBox.Left- FloatBox.Right,null);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapRight)) {
                ShapeShift.Shift(FloatShape,AnchorBox.Right - FloatBox.Left,null);
            }
        }

        static public void Align(Shape FloatShape,Mode AlignMode) {

            float SlideHeight = Misc.ActiveSlideHeight();
            float SlideWidth  = Misc.ActiveSlideWidth();
            Boundbox FloatBox = new Boundbox(FloatShape);

            if(ModeContain(AlignMode,Mode.ShapeAlignTop)) {
                ShapeShift.ShiftTo(FloatShape,null,0);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignMid)) {
                ShapeShift.ShiftTo(FloatShape,null,(double)((SlideHeight-FloatBox.Height)/2));
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignBottom)) {
                ShapeShift.ShiftTo(FloatShape,null,SlideHeight - FloatBox.Height);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignLeft)) {
                ShapeShift.ShiftTo(FloatShape,0,null);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignCenter)) {
                ShapeShift.ShiftTo(FloatShape,(double)((SlideWidth - FloatBox.Width) / 2),null);
            }
            if(ModeContain(AlignMode,Mode.ShapeAlignRight)) {
                ShapeShift.ShiftTo(FloatShape,SlideWidth - FloatBox.Width,null);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapTop)) {
                ShapeShift.ShiftTo(FloatShape,null,- FloatBox.Height);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapBottom)) {
                ShapeShift.ShiftTo(FloatShape,null,SlideHeight + FloatBox.Bottom);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapLeft)) {
                ShapeShift.ShiftTo(FloatShape,- FloatBox.Width,null);
            }
            if(ModeContain(AlignMode,Mode.ShapeSnapRight)) {
                ShapeShift.ShiftTo(FloatShape,SlideWidth,null);
            }
        }
        static public void AlignSelectedShapes(ShapeAlign.Mode Mode) {
            ShapeRange SRange = Misc.SelectedShapes();
            int ShapeCount = SRange.Count;
            switch(ShapeCount) {
                case 0:
                    break;
                case 1:
                    ShapeAlign.Align(SRange[1],Mode);
                    break;
                default:
                    Shape AnchorShape = SRange[1];
                    for(int Index = 2;Index <= ShapeCount;Index++) {
                        Shape FloatShape = SRange[Index];
                        ShapeAlign.Align(AnchorShape,FloatShape,Mode);
                    }
                    break;
            }
        }
        static public void ShapeDist(Microsoft.Office.Core.MsoDistributeCmd Mode) {
            ShapeRange SRange = Misc.SelectedShapes();
            int ShapeCount = SRange.Count;
            switch(ShapeCount) {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    SRange.Distribute(Mode,Microsoft.Office.Core.MsoTriState.msoFalse);
                    break;
            }
        }
        static private bool ModeContain(Mode InputMode,Mode MatchMode) {
            bool SnapType  = (MatchMode & Mode.ShapeSnap) == (InputMode & Mode.ShapeSnap);
            bool AlignType = (MatchMode & InputMode) == MatchMode;
            return (SnapType && AlignType);
        }
    }
}
