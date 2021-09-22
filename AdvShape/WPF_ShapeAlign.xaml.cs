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
