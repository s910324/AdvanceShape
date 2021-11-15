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
using MsoLineDashStyle = Microsoft.Office.Core.MsoLineDashStyle;
using System.Drawing;

namespace AdvShape {
    
    public partial class Ribbon1 {
        private Boolean UI_trigger = true;
        private Color ShapeForeGroundColor;
        private Color ShapeBackGroundColor;
        private Color ShapeTexture;
        private MsoLineDashStyle LineDashStyle;
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
            Globals.ThisAddIn.Application.PresentationOpen += (o) => {
                this.SetLineStyle(MsoLineDashStyle.msoLineSolid);
            };

            
            //Texture texture = DefaultTexture.TextureDict[(int)Microsoft.Office.Core.MsoPatternType.msoPatternSmallCheckerBoard];
            Texture texture = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineDash];
            this.ShapeFill_RBPB.Image = texture.RenderBitmap(32,32,1,1,Color.White,Color.Red,Color.Black);
            this.comboBox1.Image = texture.RenderBitmap(32,32,1,2,Color.White,Color.Red,Color.Black);
            this.LineDashMenu.Image = texture.RenderBitmap(32,32,1,2,Color.White,Color.Red,Color.Black);
            this.test();
        }

        private void test() {
            Texture texture_solid_line        = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineSolid];
            Texture texture_round_dot         = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineRoundDot];
            Texture texture_square_dot        = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineSquareDot];
            Texture texture_dash              = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineDash];
            Texture texture_dash_dot          = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineDashDot];
            Texture texture_long_dash_dot     = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineLongDashDot];
            Texture texture_long_dash_dot_dot = DefaultTexture.DashDict[(int)MsoLineDashStyle.msoLineLongDashDotDot];

            int ImagwWidth    = 32;
            int ImageHeight   = 32;
            int BorderWidth   = 1;
            int Magnify       = 1;
            Color ForeColor   = Color.Black;
            Color BackColor   = Color.Transparent;
            Color BorderColor = Color.Gray;

            this.LineSolidLine_RBPB.Image      = texture_solid_line.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            this.LineRoundDot_RBPB.Image       = texture_round_dot.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            this.LineSquareDot_RBPB.Image      = texture_square_dot.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            this.LineDash_RBPB.Image           = texture_dash.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            this.LineDashDot_RBPB.Image        = texture_dash_dot.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            this.LineLongDashDot_RBPB.Image    = texture_long_dash_dot.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            this.LineLongDashDotDot_RBPB.Image = texture_long_dash_dot_dot.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            
            this.LineSolidLine_RBPB.Click      += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineSolid);};
            this.LineRoundDot_RBPB.Click       += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineRoundDot);};
            this.LineSquareDot_RBPB.Click      += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineSquareDot);};
            this.LineDash_RBPB.Click           += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineDash);};
            this.LineDashDot_RBPB.Click        += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineDashDot);};
            this.LineLongDashDot_RBPB.Click    += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineLongDashDot);};
            this.LineLongDashDotDot_RBPB.Click += (o,e) => {this.SetLineStyle(MsoLineDashStyle.msoLineLongDashDotDot);};
            this.LineDashStyle_RBPB.Click      += (o,e) => {this.SetLineStyle(this.LineDashStyle);};
            
        }

        private void SetLineStyle(MsoLineDashStyle style) {
            if(this.LineDashStyle != style) {
                this.LineDashStyle = style;
                int ImagwWidth     = 32;
                int ImageHeight    = 32;
                int BorderWidth    = 1;
                int Magnify        = 1;
                Color ForeColor    = Color.Black;
                Color BackColor    = Color.Transparent;
                Color BorderColor  = Color.Gray;

                Texture texture_current_line  = DefaultTexture.DashDict[(int)style];
                this.LineDashStyle_RBPB.Image = texture_current_line.RenderBitmap(ImagwWidth,ImageHeight,BorderWidth,Magnify,ForeColor,BackColor,BorderColor);
            }

            
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                foreach(Shape shape in shaperange) {
                    if(shape.Line != null) { shape.Line.DashStyle = this.LineDashStyle; }
                }
            }
        }

        private void InitRibbon() {
            
            this.ShapeAlignDialog_RBPB.Click       += (o,i) => { this.ShowShapeAlignDialig(); };
            this.ShapeArrayDialog_RBPB.Click       += (o,i) => { this.ShowShapeArrayDialig(); };
            this.ShapeTransDialog_RBPB.Click       += (o,i) => { this.ShowShapeTransDialig(); };

            this.AlignLeft_RBPB.Click              += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignLeft); };
            this.AlignCent_RBPB.Click              += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignCenter); };
            this.AlignRight_RBPB.Click             += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignRight); };

            this.AlignTop_RBPB.Click               += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTop); };
            this.AlignMid_RBPB.Click               += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMid); };
            this.AlignBottom_RBPB.Click            += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottom); };

            this.AlignTopLeft_RBPB.Click           += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopLeft); };
            this.AlignTopCent_RBPB.Click           += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopCenter); };
            this.AlignTopRight_RBPB.Click          += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignTopRight); };

            this.AlignMidLeft_RBPB.Click           += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidLeft); };
            this.AlignMidCent_RBPB.Click           += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidCenter); };
            this.AlignMidRight_RBPB.Click          += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignMidRight); };

            this.AlignBottomLeft_RBPB.Click        += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomLeft); };
            this.AlignBottomCent_RBPB.Click        += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomCenter); };
            this.AlignBottomRight_RBPB.Click       += (o,i) => { ShapeAlign.AlignSelectedShapes(ShapeAlign.Mode.ShapeAlignBottomRight); };

            this.ShapeWidth_RBET.TextChanged       += (o,i) => { if(this.UI_trigger) { this.SetShapeWidth();}};
            this.ShapeHeight_RBET.TextChanged      += (o,i) => { if(this.UI_trigger) { this.SetShapeHeight();}};
            this.ShapeAngle_RBET.TextChanged       += (o,i) => { if(this.UI_trigger) { this.SetShapeAngle();}};

            this.ShapeFillOpacity_RBET.TextChanged += (o,i) => { if(this.UI_trigger) { this.SetShapeFillOpacity(); } };
            this.ShapeLineOpacity_RBET.TextChanged += (o,i) => { if(this.UI_trigger) { this.SetShapeLineOpacity(); } };

            this.ShapeZTop_RBPB.Click              += (o,i) => { ShapeOrder.ShapeZTop(); };
            this.ShapeZbottom_RBPB.Click           += (o,i) => { ShapeOrder.ShapeZBottom(); };
            this.ShapeZUp_RBPB.Click               += (o,i) => { ShapeOrder.ShapeZUp(); };
            this.ShapeZDown_RBPB.Click             += (o,i) => { ShapeOrder.ShapeZDown(); };
            this.ShapeZAbove_RBPB.Click            += (o,i) => { ShapeOrder.ShapeZMoveRelative(1); };
            this.ShapeZBelow_RBPB.Click            += (o,i) => { ShapeOrder.ShapeZMoveRelative(-1); };
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
            
            if(Misc.WithActiveSelection()) {
                ShapeRange iRange = Misc.SelectedShapes();
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
            
            if(Misc.WithActiveSelection()) {
                ShapeRange iRange = Misc.SelectedShapes();
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
            if(Misc.WithActiveSelection()){
                ShapeRange iRange = Misc.SelectedShapes();
                LineBoundBox lbb = new LineBoundBox(iRange[1]);
            }
        }



        private void SetShapeWidth(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeWidth_RBET.Text) : parse;
            if(parse != null && parse >= 0 && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) { ishape.Width = (float)Misc.CmToPoints((double)parse); }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeHeight(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeHeight_RBET.Text) : parse;
            if(parse != null && parse >= 0 && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) { ishape.Height = (float)Misc.CmToPoints((double)parse); }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeAngle(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeAngle_RBET.Text) : parse;
            if(parse != null && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) { ishape.Rotation = (float)parse; }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeFillOpacity(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeFillOpacity_RBET.Text) : parse;
            if(parse != null && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ishape.Fill != null) { ishape.Fill.Transparency = (float)(parse / 100); }
                }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeLineOpacity(double? parse = null) {
            parse = (parse == null) ? Misc.MathParse(this.ShapeLineOpacity_RBET.Text) : parse;
            if(parse != null && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ishape.Line != null) { ishape.Line.Transparency = (float)(parse / 100); }
                }
            } else {
                this.ShapeRibbonSetValue();
            }
        }
        private void SetShapeTexture() { 

        }
        protected void ShapeRibbonSetValue() {
            this.UI_trigger = false;
            
            if(Misc.WithActiveSelection()) {
                List<float> width       = new List<float>();
                List<float> height      = new List<float>();
                List<float> angle       = new List<float>();
                List<float> fillOpacity = new List<float>();
                List<float> lineOpacity = new List<float>();

                foreach(Shape ishape in Misc.SelectedShapes()) {
                    width.Add(ishape.Width);
                    height.Add(ishape.Height);
                    angle.Add(ishape.Rotation);

                    if(ishape.Fill != null) { if(ishape.Fill.Transparency >= 0) { fillOpacity.Add(ishape.Fill.Transparency * 100); } }
                    if(ishape.Line != null) { if(ishape.Line.Transparency >= 0) { lineOpacity.Add(ishape.Line.Transparency * 100); } }
                }

                HashSet<float> hashWidth       = width.ToHashSet();
                HashSet<float> hashheight      = height.ToHashSet();
                HashSet<float> hashangle       = angle.ToHashSet();
                HashSet<float> hashfillOpacity = fillOpacity.ToHashSet();
                HashSet<float> hashlineOpacity = lineOpacity.ToHashSet();

                this.ShapeWidth_RBET.Text       = (hashWidth.Count  == 1)      ? Math.Round(Misc.PointsToCm(hashWidth.First()), 3).ToString(): "--";
                this.ShapeHeight_RBET.Text      = (hashheight.Count == 1)      ? Math.Round(Misc.PointsToCm(hashheight.First()),3).ToString(): "--";
                this.ShapeAngle_RBET.Text       = (hashangle.Count  == 1)      ? Math.Round(hashangle.First(), 3).ToString(): "--";
                this.ShapeFillOpacity_RBET.Text = (hashfillOpacity.Count == 1) ? Math.Round(hashfillOpacity.First(),0).ToString() : "--";
                this.ShapeLineOpacity_RBET.Text = (hashlineOpacity.Count == 1) ? Math.Round(hashlineOpacity.First(),0).ToString() : "--";
            }
            this.UI_trigger = true;
        }
        protected void SelectionRibbonUpdate() {
            RibbonControl[] UISets1 = new RibbonControl[] {
                this.ShapeWidth_RBET,           this.ShapeHeight_RBET,         this.ShapeAngle_RBET,
                this.ShapeHeight_RBLB,          this.ShapeHeightUnit_RBLB,     this.ShapeWidth_RBLB,
                this.ShapeWidthDec_RBPB,        this.ShapeHeightDec_RBPB,      this.ShapeAngleDec_RBPB,
                this.ShapeWidthInc_RBPB,        this.ShapeHeightInc_RBPB,      this.ShapeAngleInc_RBPB,
                this.ShapeAlignDialog_RBPB,     this.ShapeArrayDialog_RBPB,    this.ShapeTransDialog_RBPB,
                this.ShapeAlignMenu,
                this.ShapeWidthUnit_RBLB,       this.ShapeAngle_RBLB,          this.ShapeAngleUnit_RBLB,
                this.ShapeZTop_RBPB,            this.ShapeZbottom_RBPB,        this.ShapeZUp_RBPB,
                this.ShapeZDown_RBPB,

                this.ShapeFillOpacity_RBET,     this.ShapeFillOpacityInc_RBPB, this.ShapeFillOpacityDec_RBPB,
                this.ShapeFillOpacityUnit_RBLB, this.ShapeFill_RBPB,

                this.ShapeLineOpacity_RBET,     this.ShapeLineOpacityInc_RBPB, this.ShapeLineOpacityDec_RBPB,
                this.ShapeLineOpacityUnit_RBLB, this.ShapeLine_RBPB

            };

            RibbonControl[] UISets2 = new RibbonControl[] {
                this.ShapeZAbove_RBPB, this.ShapeZBelow_RBPB
            };
            if(Misc.WithActiveSelection()) {
                ShapeRange SelectRange = Misc.SelectedShapes();
                foreach(RibbonControl UI in UISets1) {
                    UI.Enabled = (SelectRange.Count > 0);
                }
                foreach(RibbonControl UI in UISets2) {
                    UI.Enabled = (SelectRange.Count > 1);
                }
            }
        }
        private void ShapeWidth_RBET_TextChanged(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeWidth_RBET.Text);
            if(ParseVal != null && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ParseVal != null) { ishape.Width = (float)Misc.CmToPoints((double)ParseVal); }
                }
            }
        }
        private void ShapeHeight_RBET_TextChanged(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeHeight_RBET.Text);
            if(ParseVal != null && Misc.WithActiveSelection()) {
                foreach(Shape ishape in Misc.SelectedShapes()) {
                    if(ParseVal != null) { ishape.Height = (float)Misc.CmToPoints((double)ParseVal); }
                }
            }
        }
        private void ShapeAngle_RBET_TextChanged(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeAngle_RBET.Text);
            if(ParseVal != null && Misc.WithActiveSelection()) {
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


        private void ShapeFillOpacityInc_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeFillOpacity_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(((ParseVal + 5)>100) ? 100: (ParseVal + 5));
                this.ShapeFillOpacity_RBET.Text = (ChangedVal).ToString();
                this.SetShapeFillOpacity(ChangedVal);
            } else {
                this.ShapeFillOpacity_RBET.Text = "0";
                this.SetShapeFillOpacity(0);
            }
        }

        

        private void ShapeFillOpacityDec_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeFillOpacity_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(((ParseVal - 5) < 0) ? 0 : (ParseVal - 5));
                this.ShapeFillOpacity_RBET.Text = (ChangedVal).ToString();
                this.SetShapeFillOpacity(ChangedVal);
            } else {
                this.ShapeFillOpacity_RBET.Text = "100";
                this.SetShapeFillOpacity(100);
            }
        }

        private void ShapeLineOpacityInc_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeLineOpacity_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(((ParseVal + 5) > 100) ? 100 : (ParseVal + 5));
                this.ShapeLineOpacity_RBET.Text = (ChangedVal).ToString();
                this.SetShapeLineOpacity(ChangedVal);
            } else {
                this.ShapeLineOpacity_RBET.Text = "0";
                this.SetShapeLineOpacity(0);
            }
        }

        private void ShapeLineOpacityDec_RBPB_Click(object sender,RibbonControlEventArgs e) {
            Double? ParseVal = Misc.MathParse(this.ShapeLineOpacity_RBET.Text);
            if(ParseVal != null) {
                double ChangedVal = (double)(((ParseVal - 5) < 0) ? 0 : (ParseVal - 5));
                this.ShapeLineOpacity_RBET.Text = (ChangedVal).ToString();
                this.SetShapeLineOpacity(ChangedVal);
            } else {
                this.ShapeLineOpacity_RBET.Text = "100";
                this.SetShapeLineOpacity(100);
            }
        }

        
        private void button2_Click(object sender,RibbonControlEventArgs e) {
            Shape i = Misc.SelectedShapes()[1];
            Boundbox b =new Boundbox(i);
            b.DebugMode();


        }

        private void button3_Click_1(object sender,RibbonControlEventArgs e) {
            //var w = new WPF_LineDashSelector();
            var w = new WPF_FillTextureSelector();
            System.Windows.Point p = Misc.GetCursorPosition();
            /*System.Windows.Point pointToWindow = System.Windows.Input.Mouse.GetPosition(this.button3);
            int x = Globals.ThisAddIn.Application.ActiveWindow.PointsToScreenPixelsX((float)pointToWindow.X);
            int y = Globals.ThisAddIn.Application.ActiveWindow.PointsToScreenPixelsY((float)pointToWindow.Y);*/
            w.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            w.Top = p.Y;
            w.Left = p.X;
            w.Show();
        }



        private void dropDown2_SelectionChanged(object sender,RibbonControlEventArgs e) {

        }

        private void comboBox1_TextChanged(object sender,RibbonControlEventArgs e) {

        }
    }
}
