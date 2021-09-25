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
            this.AlignLeft_PB.Click        += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft); };
            this.AlignCent_PB.Click        += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter); };
            this.AlignRight_PB.Click       += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignRight); };

            this.AlignTop_PB.Click         += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTop); };
            this.AlignMid_PB.Click         += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMid); };
            this.AlignBottom_PB.Click      += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom); };

            this.AlignTopLeft_PB.Click     += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft); };
            this.AlignTopCent_PB.Click     += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter); };
            this.AlignTopRight_PB.Click    += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight); };

            this.AlignMidLeft_PB.Click     += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft); };
            this.AlignMidCent_PB.Click     += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter); };
            this.AlignMidRight_PB.Click    += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight); };
            
            this.AlignBottomLeft_PB.Click  += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft); };
            this.AlignBottomCent_PB.Click  += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter); };
            this.AlignBottomRight_PB.Click += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight); };

            this.SnapTop_PB.Click          += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapTop); };
            this.SnapBottom_PB.Click       += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapBottom); };
            this.SnapLeft_PB.Click         += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapLeft); };
            this.SnapRight_PB.Click        += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapRight); };
            
            this.SnapTopLeft_PB.Click      += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapTopLeft); };
            this.SnapTopRight_PB.Click     += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapTopRight); };
            this.SnapBottomLeft_PB.Click   += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomLeft); };
            this.SnapBottomRight_PB.Click  += (o,i) => { AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomRight); };
        }
        private void OnKeyDownHandler(object sender,KeyEventArgs e) {
            switch(e.Key) {
                case Key.Escape:
                    this.Close();
                    break;
                case Key.Q:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft);
                    break;
                case Key.W:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter);
                    break;
                case Key.E:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight);
                    break;
                case Key.A:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft);
                    break;
                case Key.S:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter);
                    break;
                case Key.D:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight);
                    break;
                case Key.Z:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft);
                    break;
                case Key.X:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter);
                    break;
                case Key.C:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight);
                    break;
                case Key.D1:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft);
                    break;
                case Key.D2:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter);
                    break;
                case Key.D3:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignRight);
                    break;
                case Key.R:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignTop);
                    break;
                case Key.F:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignMid);
                    break;
                case Key.V:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom);
                    break;

                case Key.I:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapTopLeft);
                    break;
                case Key.O:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapTop);
                    break;
                case Key.P:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapTopRight);
                    break;
                case Key.K:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapLeft);
                    break;
                case Key.Separator:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapRight);
                    break;
                case Key.OemComma:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomLeft);
                    break;
                case Key.OemPeriod:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapBottom);
                    break;
                case Key.OemQuestion:
                    this.AlighSelectedShapes(ShapeAlign.Mode.ShapeSnapBottomRight);
                    break;
            }

        }

        private void AlighSelectedShapes(ShapeAlign.Mode Mode) {
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
    }
}
