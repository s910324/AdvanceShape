using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Ribbon;
using MemoryStream= System.IO.MemoryStream;

using RibbonButton = Microsoft.Office.Tools.Ribbon.RibbonButton;
using RibbonToggleButton = Microsoft.Office.Tools.Ribbon.RibbonToggleButton;
using RibbonControl = Microsoft.Office.Tools.Ribbon.RibbonControl;
using System.Drawing;

namespace AdvShape {
    
    public partial class Ribbon1 {
        private Boolean UI_trigger = true;
        private void Ribbon1_Load(object sender,RibbonUIEventArgs e) {
            this.InitRibbon();
            //WindowSelectionChange
            //SlideSelectionChanged
            Globals.ThisAddIn.Application.AfterShapeSizeChange += (o) => {
                this.SelectionRibbonUpdate();
                this.ShapeRibbonSetValue();
            };
            Globals.ThisAddIn.Application.WindowSelectionChange += (o) => {
                this.SelectionRibbonUpdate();
                this.ShapeRibbonSetValue();
            };


            Texture texture = DefaultTexture.TextureDict[35];
            this.button1.Image = texture.RenderBitmap(32, 32, 1, Color.White, Color.Red, Color.Black);

        }

        private ShapeRange GetSelectedShapes() {
            var ActiveSlide = (Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            var CurrentSelection = (Selection)Globals.ThisAddIn.Application.ActiveWindow.Selection;
            return CurrentSelection.Type == 0 ? ActiveSlide.Shapes.Range(0) : CurrentSelection.ShapeRange;
        }

        private void InitRibbon() {
            
            this.ShapeAlignDialog_RBPB.Click  += (o,i) => { this.ShowShapeAlignDialig(); };
            this.ShapeArrayDialog_RBPB.Click  += (o,i) => { this.ShowShapeArrayDialig(); };
            this.ShapeTransDialog_RBPB.Click  += (o,i) => { this.ShowShapeTransDialig(); };

            this.AlignLeft_RBPB.Click         += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft); };
            this.AlignCent_RBPB.Click         += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter); };
            this.AlignRight_RBPB.Click        += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignRight); };

            this.AlignTop_RBPB.Click          += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTop); };
            this.AlignMid_RBPB.Click          += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMid); };
            this.AlignBottom_RBPB.Click       += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom); };

            this.AlignTopLeft_RBPB.Click      += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft); };
            this.AlignTopCent_RBPB.Click      += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter); };
            this.AlignTopRight_RBPB.Click     += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight); };

            this.AlignMidLeft_RBPB.Click      += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft); };
            this.AlignMidCent_RBPB.Click      += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter); };
            this.AlignMidRight_RBPB.Click     += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight); };

            this.AlignBottomLeft_RBPB.Click   += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft); };
            this.AlignBottomCent_RBPB.Click   += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter); };
            this.AlignBottomRight_RBPB.Click  += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight); };

            this.ShapeWidth_RBET.TextChanged  += (o,i) => { if(this.UI_trigger) { this.SetShapeWidth();}};
            this.ShapeHeight_RBET.TextChanged += (o,i) => { if(this.UI_trigger) { this.SetShapeHeight();}};
            this.ShapeAngle_RBET.TextChanged  += (o,i) => { if(this.UI_trigger) { this.SetShapeAngle();}};

            this.ShapeZTop_RBPB.Click         += (o,i) => { ShapeOrder.ShapeZTop(); };
            this.ShapeZbottom_RBPB.Click      += (o,i) => { ShapeOrder.ShapeZBottom(); };
            this.ShapeZUp_RBPB.Click          += (o,i) => { ShapeOrder.ShapeZUp(); };
            this.ShapeZDown_RBPB.Click        += (o,i) => { ShapeOrder.ShapeZDown(); };
            this.ShapeZAbove_RBPB.Click       += (o,i) => { ShapeOrder.ShapeZMoveRelative(1); };
            this.ShapeZBelow_RBPB.Click       += (o,i) => { ShapeOrder.ShapeZMoveRelative(-1); };
        }
        private void ShowShapeAlignDialig() {
            var app = new WPF_ShapeAlign();
/*            app.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            double w = System.Windows.SystemParameters.WorkArea.Width;
            double h = System.Windows.SystemParameters.WorkArea.Height;

            app.Left = ((w * 0.1) < 100) ? 100 : (w * 0.1);
            app.Top = ((h * 0.1) < 100) ? (h - 100 + app.Height) : (h * 0.9 + app.Height);
            app.Topmost = true;*/
            app.Show();
        }

        private void ShowShapeArrayDialig() {
            ShapeRange iRange = Misc.SelectedShapes();
            if(iRange.Count > 0) {
                var app = new WPF_ShapeArray();
/*                app.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
                double w    = System.Windows.SystemParameters.WorkArea.Width;
                double h    = System.Windows.SystemParameters.WorkArea.Height;
                
                app.Left    = ((w * 0.1) < 100) ?       100 : (w * 0.1);
                app.Top     = ((h * 0.1) < 100) ? (h - 100 + app.Height) : (h * 0.9 + app.Height);
                app.Topmost = true;*/
                app.Show();
            }
        }
        private void ShowShapeTransDialig() {
            ShapeRange iRange = Misc.SelectedShapes();
            if(iRange.Count > 0) {
                var app = new WPF_ShapeTranslation();
 /*               app.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
                double w = System.Windows.SystemParameters.WorkArea.Width;
                double h = System.Windows.SystemParameters.WorkArea.Height;

                app.Left = ((w * 0.1) < 100) ? 100 : (w * 0.1);
                app.Top = ((h * 0.1) < 100) ? (h - 100 + app.Height) : (h * 0.9 + app.Height);
                app.Topmost = true;*/
                app.Show();
            }
        }

        private void button3_Click(object sender,RibbonControlEventArgs e) {
            ShapeRange iRange = Misc.SelectedShapes();
            LineBoundBox lbb = new LineBoundBox(iRange[1]);
        }



        private void SetShapeWidth(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeWidth_RBET.Text) : parse;
            if(parse != null && parse >= 0) {
                foreach(Shape ishape in Misc.SelectedShapes()) { ishape.Width = (float)Misc.CmToPoints((double)parse); }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeHeight(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeHeight_RBET.Text) : parse;
            if(parse != null && parse >= 0) {
                foreach(Shape ishape in Misc.SelectedShapes()) { ishape.Height = (float)Misc.CmToPoints((double)parse); }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeAngle(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeAngle_RBET.Text) : parse;
            if(parse != null ) {
                foreach(Shape ishape in Misc.SelectedShapes()) { ishape.Rotation = (float)parse; }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        protected void ShapeRibbonSetValue() {
            this.UI_trigger = false;
            ShapeRange SelectRange = Misc.SelectedShapes();
            if(SelectRange.Count > 0) {
                List<float> width  = new List<float>();
                List<float> height = new List<float>();
                List<float> angle  = new List<float>();

                foreach(Shape ishape in Misc.SelectedShapes()) {
                    width.Add(ishape.Width);
                    height.Add(ishape.Height);
                    angle.Add(ishape.Rotation);
                }

                HashSet<float> hashWidth   = width.ToHashSet();
                HashSet<float> hashheight  = height.ToHashSet();
                HashSet<float> hashangle   = angle.ToHashSet();
                this.ShapeWidth_RBET.Text  = (hashWidth.Count  == 1) ? Math.Round(Misc.PointsToCm(hashWidth.First()), 3).ToString(): "";
                this.ShapeHeight_RBET.Text = (hashheight.Count == 1) ? Math.Round(Misc.PointsToCm(hashheight.First()),3).ToString(): "";
                this.ShapeAngle_RBET.Text  = (hashangle.Count  == 1) ? Math.Round(hashangle.First(), 3).ToString(): "";
            }
            this.UI_trigger = true;
        }
        protected void SelectionRibbonUpdate() {
            RibbonControl[] UISets1 = new RibbonControl[] {
                this.ShapeWidth_RBET,       this.ShapeHeight_RBET,      this.ShapeAngle_RBET,
                this.ShapeHeight_RBLB,      this.ShapeHeightUnit_RBLB,  this.ShapeWidth_RBLB,
                this.ShapeWidthDec_RBPB,    this.ShapeHeightDec_RBPB,   this.ShapeAngleDec_RBPB,
                this.ShapeWidthInc_RBPB,    this.ShapeHeightInc_RBPB,   this.ShapeAngleInc_RBPB,
                this.ShapeAlignDialog_RBPB, this.ShapeArrayDialog_RBPB, this.ShapeTransDialog_RBPB,
                this.ShapeAlignMenu,
                this.ShapeWidthUnit_RBLB,   this.ShapeAngle_RBLB,       this.ShapeAngleUnit_RBLB,

                this.ShapeZTop_RBPB,        this.ShapeZbottom_RBPB,     this.ShapeZUp_RBPB, 
                this.ShapeZDown_RBPB
            };

            RibbonControl[] UISets2 = new RibbonControl[] {
                this.ShapeZAbove_RBPB, this.ShapeZBelow_RBPB
            };

            ShapeRange SelectRange = Misc.SelectedShapes();
            foreach(RibbonControl UI in UISets1) {
                UI.Enabled = (SelectRange.Count > 0);
            }
            foreach(RibbonControl UI in UISets2) {
                UI.Enabled = (SelectRange.Count > 1);
            }
        }
        private void ShapeWidth_RBET_TextChanged(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeWidth_RBET.Text);
            if(ParseVal != null) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ParseVal != null) { ishape.Width = (float)Misc.CmToPoints((double)ParseVal); }
                }
            }
        }
        private void ShapeHeight_RBET_TextChanged(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeHeight_RBET.Text);
            if(ParseVal != null) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ParseVal != null) { ishape.Height = (float)Misc.CmToPoints((double)ParseVal); }
                }
            }
        }
        private void ShapeAngle_RBET_TextChanged(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeAngle_RBET.Text);
            if(ParseVal != null) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ParseVal != null) { ishape.Rotation = (float)ParseVal; }
                }
            }
        }
        private void ShapeWidthDec_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeWidth_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(ParseVal - 0.1);
                ChangedVal = (double)((ChangedVal < 0) ? 0 : ChangedVal);
                this.ShapeWidth_RBET.Text = (ChangedVal).ToString();
                this.SetShapeWidth(ChangedVal);
            }
        }
        private void ShapeHeightDec_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeHeight_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(ParseVal - 0.1);
                ChangedVal = (double)((ChangedVal < 0) ? 0 : ChangedVal);
                this.ShapeHeight_RBET.Text = (ChangedVal).ToString();
                this.SetShapeHeight(ChangedVal);
            }
        }
        private void ShapeAngleDec_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeAngle_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(ParseVal - 1);
                this.ShapeAngle_RBET.Text = (ChangedVal).ToString();
                this.SetShapeAngle(ChangedVal);
            }
        }
        private void ShapeWidthInc_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeWidth_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(ParseVal + 0.1);
                this.ShapeWidth_RBET.Text = (ChangedVal).ToString();
                this.SetShapeWidth(ChangedVal);
            }
        }
        private void ShapeHeightInc_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeHeight_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(ParseVal + 0.1);
                this.ShapeHeight_RBET.Text = (ChangedVal).ToString();
                this.SetShapeHeight(ChangedVal);
            }
        }
        private void ShapeAngleInc_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeAngle_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(ParseVal + 1.0);
                this.ShapeAngle_RBET.Text = (ChangedVal).ToString();
                this.SetShapeAngle(ChangedVal);
            }
        }


        private void button2_Click(object sender,RibbonControlEventArgs e) {
            Shape i = Misc.SelectedShapes()[1];
            Boundbox b =new Boundbox(i);
            b.DebugMode();


        }

        private void button3_Click_1(object sender,RibbonControlEventArgs e) {
            var w = new WPF_ShapeTranslation();
            w.Show();
        }



        private void button1_Click(object sender,RibbonControlEventArgs e) {

        }

        private void dropDown2_SelectionChanged(object sender,RibbonControlEventArgs e) {

        }
    }
}
