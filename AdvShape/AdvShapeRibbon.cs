using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Ribbon;
using RibbonButton = Microsoft.Office.Tools.Ribbon.RibbonButton;
using RibbonToggleButton = Microsoft.Office.Tools.Ribbon.RibbonToggleButton;

namespace AdvShape {
    public partial class Ribbon1 {
        private void Ribbon1_Load(object sender,RibbonUIEventArgs e) {
            this.InitRibbon();
            
        }

        private ShapeRange GetSelectedShapes() {
            var ActiveSlide = (Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            var CurrentSelection = (Selection)Globals.ThisAddIn.Application.ActiveWindow.Selection;
            return CurrentSelection.Type == 0 ? ActiveSlide.Shapes.Range(0) : CurrentSelection.ShapeRange;
        }

        private void InitRibbon() {
            this.ShapeAlignDialog_RBPB.Click += (o,i) => { this.ShowShapeAlignDialig(); };
            this.ShapeArrayDialog_RBPB.Click += (o,i) => { this.ShowShapeArrayDialig(); };
            this.AlignLeft_RBPB.Click        += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft); };
            this.AlignCent_RBPB.Click        += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter); };
            this.AlignRight_RBPB.Click       += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignRight); };

            this.AlignTop_RBPB.Click         += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTop); };
            this.AlignMid_RBPB.Click         += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMid); };
            this.AlignBottom_RBPB.Click      += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom); };

            this.AlignTopLeft_RBPB.Click     += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft); };
            this.AlignTopCent_RBPB.Click     += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter); };
            this.AlignTopRight_RBPB.Click    += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight); };

            this.AlignMidLeft_RBPB.Click     += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft); };
            this.AlignMidCent_RBPB.Click     += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter); };
            this.AlignMidRight_RBPB.Click    += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight); };

            this.AlignBottomLeft_RBPB.Click  += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft); };
            this.AlignBottomCent_RBPB.Click  += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter); };
            this.AlignBottomRight_RBPB.Click += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight); };
        }
        private void ShowShapeAlignDialig() {
            var app = new WPF_ShapeAlign();
            app.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            double w = System.Windows.SystemParameters.WorkArea.Width;
            double h = System.Windows.SystemParameters.WorkArea.Height;

            app.Left = ((w * 0.1) < 100) ? 100 : (w * 0.1);
            app.Top = ((h * 0.1) < 100) ? (h - 100 + app.Height) : (h * 0.9 + app.Height);
            app.Topmost = true;
            app.Show();
        }

        private void ShowShapeArrayDialig() {
            ShapeRange iRange = Misc.SelectedShapes();
            if(iRange.Count > 0) {
                var app = new WPF_ShapeArray();
                app.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
                double w    = System.Windows.SystemParameters.WorkArea.Width;
                double h    = System.Windows.SystemParameters.WorkArea.Height;
                
                app.Left    = ((w * 0.1) < 100) ?       100 : (w * 0.1);
                app.Top     = ((h * 0.1) < 100) ? (h - 100 + app.Height) : (h * 0.9 + app.Height);
                app.Topmost = true;
                app.Show();
            }
        }


        private void button3_Click(object sender,RibbonControlEventArgs e) {
            ShapeRange iRange = Misc.SelectedShapes();
            LineBoundBox lbb = new LineBoundBox(iRange[1]);
        }


    }
}
