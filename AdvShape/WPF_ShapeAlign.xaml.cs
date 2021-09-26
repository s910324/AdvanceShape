using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Microsoft.Office.Interop.PowerPoint;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;

namespace AdvShape {
    public partial class WPF_ShapeAlign:Window {
        public WPF_ShapeAlign() {
            InitializeComponent();
            BindButtonClick();
        }
        private void BindButtonClick() {
            this.AlignLeft_PB.Click          += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft); };
            this.AlignCent_PB.Click          += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter); };
            this.AlignRight_PB.Click         += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignRight); };

            this.AlignTop_PB.Click           += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTop); };
            this.AlignMid_PB.Click           += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMid); };
            this.AlignBottom_PB.Click        += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom); };

            this.AlignTopLeft_PB.Click       += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft); };
            this.AlignTopCent_PB.Click       += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter); };
            this.AlignTopRight_PB.Click      += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight); };

            this.AlignMidLeft_PB.Click       += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft); };
            this.AlignMidCent_PB.Click       += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter); };
            this.AlignMidRight_PB.Click      += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight); };
            
            this.AlignBottomLeft_PB.Click    += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft); };
            this.AlignBottomCent_PB.Click    += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter); };
            this.AlignBottomRight_PB.Click   += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight); };

            this.SnapTop_PB.Click            += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapTop); };
            this.SnapBottom_PB.Click         += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapBottom); };
            this.SnapLeft_PB.Click           += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapLeft); };
            this.SnapRight_PB.Click          += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapRight); };
            
            this.SnapTopLeft_PB.Click        += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapTopLeft); };
            this.SnapTopRight_PB.Click       += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapTopRight); };
            this.SnapBottomLeft_PB.Click     += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomLeft); };
            this.SnapBottomRight_PB.Click    += (o,i) => { AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomRight); };

            this.DistributeH_PB.Click        += (o,i) => { ShapeDist(Microsoft.Office.Core.MsoDistributeCmd.msoDistributeHorizontally); };
            this.DistributeV_PB.Click        += (o,i) => { ShapeDist(Microsoft.Office.Core.MsoDistributeCmd.msoDistributeVertically); };

            this.AlignLeft_PB.KeyDown        += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignCent_PB.KeyDown        += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignRight_PB.KeyDown       += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignTop_PB.KeyDown         += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignMid_PB.KeyDown         += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignBottom_PB.KeyDown      += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignTopLeft_PB.KeyDown     += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignTopCent_PB.KeyDown     += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignTopRight_PB.KeyDown    += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignMidLeft_PB.KeyDown     += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignMidCent_PB.KeyDown     += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignMidRight_PB.KeyDown    += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignBottomLeft_PB.KeyDown  += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignBottomCent_PB.KeyDown  += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.AlignBottomRight_PB.KeyDown += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapTop_PB.KeyDown          += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapBottom_PB.KeyDown       += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapLeft_PB.KeyDown         += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapRight_PB.KeyDown        += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapTopLeft_PB.KeyDown      += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapTopRight_PB.KeyDown     += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapBottomLeft_PB.KeyDown   += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.SnapBottomRight_PB.KeyDown  += (o,i) => { this.OnKeyDownHandler(o,i); };
            this.KeyDown                     += (o,i) => { this.OnKeyDownHandler(o,i); };
        }
        private void OnKeyDownHandler(object sender,KeyEventArgs e) {
            switch(e.Key) {
                case Key.Escape:
                    this.Close();
                    break;
                case Key.Q:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft);
                    break;
                case Key.W:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter);
                    break;
                case Key.E:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight);
                    break;
                case Key.A:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft);
                    break;
                case Key.S:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter);
                    break;
                case Key.D:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight);
                    break;
                case Key.Z:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft);
                    break;
                case Key.X:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter);
                    break;
                case Key.C:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight);
                    break;
                case Key.D1:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft);
                    break;
                case Key.D2:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter);
                    break;
                case Key.D3:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignRight);
                    break;
                case Key.D8:
                    this.ShapeDist(Microsoft.Office.Core.MsoDistributeCmd.msoDistributeHorizontally);
                    break;
                case Key.D9:
                    this.ShapeDist(Microsoft.Office.Core.MsoDistributeCmd.msoDistributeVertically);
                    break;
                case Key.R:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTop);
                    break;
                case Key.F:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMid);
                    break;
                case Key.V:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom);
                    break;

                case Key.I:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapTopLeft);
                    break;
                case Key.O:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapTop);
                    break;
                case Key.P:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapTopRight);
                    break;
                case Key.K:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapLeft);
                    break;
                case Key.Separator:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapRight);
                    break;
                case Key.OemComma:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomLeft);
                    break;
                case Key.OemPeriod:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapBottom);
                    break;
                case Key.OemQuestion:
                    this.AlignSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomRight);
                    break;
            }
        }

        private void AlignSelectedShapes(ShapeAlign.Mode Mode) {
            ShapeRange SRange = Misc.SelectedShapes();
            int ShapeCount    = SRange.Count;
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
        private void ShapeDist(Microsoft.Office.Core.MsoDistributeCmd Mode) {
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
    }
}
