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
        Button[] ButtonCollections;
        AdvSpinBox[] SpinBoxCollections;
        public WPF_ShapeTranslation() {
            InitializeComponent();
            this.Init_UI();
        }

        private void Init_UI() { 

            SpinBoxCollections = new AdvSpinBox[]{
                this.TransX_TB, this.TransY_TB, this.LocationX_TB, this.LocationY_TB};

            ButtonCollections = new Button[] {
                this.TopLeft_PB,    this.TopCent_PB,    this.TopRight_PB,
                this.MidLeft_PB,    this.MidCent_PB,    this.MidRight_PB,
                this.BottomLeft_PB, this.BottomCent_PB, this.BottomRight_PB };

            foreach(AdvSpinBox advSpinBox in SpinBoxCollections) { 
                advSpinBox.setParseProperty(AdvTextBox.ParseDataType.Decimal,null,null); 
            }
            foreach(Button button in ButtonCollections) {
                button.Click += (o,e) => { this.test((Button)o); };
            }


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

        
        private void test(Button trigger) {
            foreach(Button button in this.ButtonCollections) {
                button.BorderBrush = new SolidColorBrush(Misc.RGB(70, 70, 70));
            }
            trigger.BorderBrush = new SolidColorBrush(Misc.RGB(240,70,70));
            Misc.print("X");
        }
    }


}
