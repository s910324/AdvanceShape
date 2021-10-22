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
        bool Location_X_changed;
        bool Location_Y_changed;
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
            foreach(RadioButton button in ButtonCollections) {
                button.Click += (o,e) => { this.test((RadioButton)o); };
            }
            this.UpdateSpinBox();
        }

        public void ApplyTranslation() {
            ShapeRange shaperange = Misc.SelectedShapes();
            bool ChangeApplied    = false;
            if(this.TransX_TB.InputValid && this.TransX_TB.InputValid) {
                double dx = (float)Misc.CmToPoints((double)this.TransX_TB.NumericValue);
                double dy = (float)Misc.CmToPoints((double)this.TransY_TB.NumericValue);

                if(dx != 0) {shaperange.Left += (float)dx; ChangeApplied = true; }
                if(dy != 0) {shaperange.Top  += (float)dy; ChangeApplied = true; }
                if(dx == 0 && dy == 0 && this.LocationX_TB.InputValid && this.LocationY_TB.InputValid) {

                    double? x = Misc.CmToPoints((double)this.LocationX_TB.NumericValue);
                    double? y = Misc.CmToPoints((double)this.LocationY_TB.NumericValue);
                    x = this.Location_X_changed ? x : null;
                    y = this.Location_Y_changed ? y : null;

                    if(x != null || y != null) {
                        foreach(Shape shape in shaperange) {ShapeShift.ShiftTo(shape,x,y);}
                        ChangeApplied = true;
                    }
                }
            }
            if(ChangeApplied) {this.UpdateSpinBox();}
        }

        private void UpdateSpinBox() {
            ShapeRange     shaperange = Misc.SelectedShapes();
            List<Boundbox> boundboxes = new List<Boundbox>();

            foreach(Shape shape in shaperange) {
                boundboxes.Add(new Boundbox(shape));
            }
            HashSet<double> XSet = boundboxes.Select(box => box.Left).ToHashSet();
            HashSet<double> YSet = boundboxes.Select(box =>  box.Top).ToHashSet();
            string Xo = (XSet.Count == 1) ? Math.Round(XSet.First(), 3).ToString() : "";
            string Yo = (YSet.Count == 1) ? Math.Round(YSet.First(), 3).ToString() : "";
            this.LocationX_TB.Text =  Xo;
            this.LocationY_TB.Text =  Yo;
            this.TransX_TB.Text    = "0";
            this.TransY_TB.Text    = "0";
        }

        
        private void test(RadioButton trigger) {
            foreach(RadioButton button in this.ButtonCollections) {
                button.BorderBrush = new SolidColorBrush(Misc.RGB(70, 70, 70));
            }
            trigger.BorderBrush = new SolidColorBrush(Misc.RGB(240,70,70));
            Misc.print("X");
        }
    }


}
