using ShapeRange = Microsoft.Office.Interop.PowerPoint.ShapeRange;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdvShape {
    public partial class WPF_ShapeTranslation:Window {
        RadioButton[] ButtonCollections;
        AdvSpinBox[]  SpinBoxCollections;

        private  int RefX = -1;
        private  int RefY =  1;
        private bool ChangeApplied = false;

        public WPF_ShapeTranslation() {
            InitializeComponent();
            this.Init_UI();
        }

        private void Init_UI() { 

            SpinBoxCollections = new AdvSpinBox[]{
                this.TransX_TB, this.TransY_TB, this.LocationX_TB, this.LocationY_TB};

            ButtonCollections = new RadioButton[] {
                this.TopLeft_RB,    this.TopCent_RB,    this.TopRight_RB,
                this.MidLeft_RB,    this.MidCent_RB,    this.MidRight_RB,
                this.BottomLeft_RB, this.BottomCent_RB, this.BottomRight_RB };

            foreach(AdvSpinBox advSpinBox in SpinBoxCollections) { 
                advSpinBox.setParseProperty(AdvTextBox.ParseDataType.Decimal,null,null); 
            }
            this.Apply_PB.Click         += (o,e) => { this.ApplyTranslation(); };

            this.TopLeft_RB.Checked     += (o,e) => { this.RefX = -1; this.RefY =  1; this.UpdateSpinBox(this.RefX,this.RefY); };
            this.TopCent_RB.Checked     += (o,e) => { this.RefX =  0; this.RefY =  1; this.UpdateSpinBox(this.RefX,this.RefY); };
            this.TopRight_RB.Checked    += (o,e) => { this.RefX =  1; this.RefY =  1; this.UpdateSpinBox(this.RefX,this.RefY); };

            this.MidLeft_RB.Checked     += (o,e) => { this.RefX = -1; this.RefY =  0; this.UpdateSpinBox(this.RefX,this.RefY); };
            this.MidCent_RB.Checked     += (o,e) => { this.RefX =  0; this.RefY =  0; this.UpdateSpinBox(this.RefX,this.RefY); };
            this.MidRight_RB.Checked    += (o,e) => { this.RefX =  1; this.RefY =  0; this.UpdateSpinBox(this.RefX,this.RefY); };

            this.BottomLeft_RB.Checked  += (o,e) => { this.RefX = -1; this.RefY = -1; this.UpdateSpinBox(this.RefX,this.RefY); };
            this.BottomCent_RB.Checked  += (o,e) => { this.RefX =  0; this.RefY = -1; this.UpdateSpinBox(this.RefX,this.RefY); };
            this.BottomRight_RB.Checked += (o,e) => { this.RefX =  1; this.RefY = -1; this.UpdateSpinBox(this.RefX,this.RefY); };

            this.TopLeft_RB.IsChecked    = true;
            this.UpdateSpinBox();
        }

        public void ApplyTranslation() {
            ShapeRange shaperange = Misc.SelectedShapes();

            if(this.TransX_TB.InputValid && this.TransX_TB.InputValid) {
                double dx = (float)Misc.CmToPoints((double)this.TransX_TB.NumericValue);
                double dy = (float)Misc.CmToPoints((double)this.TransY_TB.NumericValue);

                if(dx != 0) {shaperange.Left += (float)dx; this.ChangeApplied = true; }
                if(dy != 0) {shaperange.Top  -= (float)dy; this.ChangeApplied = true; }
                if(dx == 0 && dy == 0 ) {
                    double? x = null;
                    double? y = null;

                    if(this.LocationX_TB.InputValid) { x = Misc.CmToPoints((double)this.LocationX_TB.NumericValue); }
                    if(this.LocationY_TB.InputValid) { y = Misc.CmToPoints((double)this.LocationY_TB.NumericValue); }

                    if(x != null || y != null) {
                        foreach(Shape shape in shaperange) {ShapeShift.ShiftTo(shape,x,y, this.RefX, this.RefY);}
                        this.ChangeApplied = true;
                    }
                }
            }
            if(ChangeApplied) {this.UpdateSpinBox(this.RefX, this.RefY);}
        }

        private void UpdateSpinBox(int OriginX = -1, int OriginY = 1) {
            ShapeRange     shaperange = Misc.SelectedShapes();
            List<Boundbox> boundboxes = new List<Boundbox>();

            foreach(Shape shape in shaperange) {
                boundboxes.Add(new Boundbox(shape));
            }
            HashSet<double> XSet;
            HashSet<double> YSet;
            switch(OriginX) {
                case  1:
                    XSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Right), 3)).ToHashSet();
                    break;
                case  0:
                    XSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Xc),3)).ToHashSet();
                    break;
                case -1:
                    XSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Left),3)).ToHashSet();
                    break;
                default:
                    XSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Left),3)).ToHashSet();
                    break;
            }
            switch(OriginX) {
                case  1:
                     YSet= boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Top),3)).ToHashSet();
                    break;
                case  0:
                    YSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Yc),3)).ToHashSet();
                    break;
                case -1:
                    YSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Bottom),3)).ToHashSet();
                    break;
                default:
                    YSet = boundboxes.Select(box => Math.Round(Misc.PointsToCm(box.Top),3)).ToHashSet();
                    break;
            }
            foreach(double b in XSet) {
                Misc.print(b);
            }
            foreach(double b in YSet) {
                Misc.print(b);
            }
            string Xo = (XSet.Count == 1) ? Math.Round(Misc.PointsToCm(XSet.First()), 3).ToString() : "--";
            string Yo = (YSet.Count == 1) ? Math.Round(Misc.PointsToCm(YSet.First()), 3).ToString() : "--";
            this.LocationX_TB.Text =  Xo;
            this.LocationY_TB.Text =  Yo;
            this.TransX_TB.Text    = "0";
            this.TransY_TB.Text    = "0";
            this.ChangeApplied     = false;

        }

    }


}
