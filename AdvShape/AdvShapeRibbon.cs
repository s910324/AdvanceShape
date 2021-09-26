using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Ribbon;
using RibbonButton = Microsoft.Office.Tools.Ribbon.RibbonButton;


namespace AdvShape {
    public partial class Ribbon1 {
        private void Ribbon1_Load(object sender,RibbonUIEventArgs e) {

        }



        private ShapeRange GetSelectedShapes() {
            var ActiveSlide = (Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            var CurrentSelection = (Selection)Globals.ThisAddIn.Application.ActiveWindow.Selection;
            return CurrentSelection.Type == 0 ? ActiveSlide.Shapes.Range(0) : CurrentSelection.ShapeRange;
        }
        private Slide GetActiveSlide(){
            return (Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
        }

        private void ShapeAlignTopLeft_Click(object sender,RibbonControlEventArgs e) {
            /*var SelectedShapes = this.GetSelectedShapes();
            ShapeAlign.Align(SelectedShapes[1],SelectedShapes[2],ShapeAlign.Mode.ShapeAlignTopLeft);*/
            WPF_ShapeAlign k = new WPF_ShapeAlign();
            k.Show();
        }

        private void comboBox1_TextChanged(object sender,RibbonControlEventArgs e) {

        }

        private void button7_Click(object sender,RibbonControlEventArgs e) {
            Shape ishape = this.GetSelectedShapes()[1];
            ShapeData iData = new ShapeData(ishape);
            iData.DebugMode();
        }

        private void ShapeAlignMidLeft_Click(object sender,RibbonControlEventArgs e) {
            ShapeArray.Debug();
        }

        private void ShapeAlignBotLeft_Click(object sender,RibbonControlEventArgs e) {
            WPF_ShapeArray k = new WPF_ShapeArray();
            k.Show();
        }

        private void ShapeAlignTopCent_Click(object sender,RibbonControlEventArgs e) {
 
        }

        private void button1_Click(object sender,RibbonControlEventArgs e) {
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

        private void button2_Click(object sender,RibbonControlEventArgs e) {
            var app = new WPF_ShapeAlign();
            app.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            double w    = System.Windows.SystemParameters.WorkArea.Width;
            double h    = System.Windows.SystemParameters.WorkArea.Height;

            app.Left    = ((w * 0.1) < 100) ? 100 : (w * 0.1);
            app.Top     = ((h * 0.1) < 100) ? (h - 100 + app.Height) : (h * 0.9 + app.Height);
            app.Topmost = true;
            app.Show();
        }
    
    }
}
