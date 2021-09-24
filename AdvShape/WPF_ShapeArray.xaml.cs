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
using System.ComponentModel;

namespace AdvShape {
    public partial class WPF_ShapeArray:Window {
        private List<ShapeRange> PreviewShapes = null;
        public WPF_ShapeArray() {
            InitializeComponent();
            TextboxSetup();
        }

        private void TextboxSetup() { 
            this.RowCount_TB.setParseProperty( AdvTextBox.ParseDataType.Integer,    1, null);
            this.RowDx_TB.setParseProperty(    AdvTextBox.ParseDataType.Decimal, null, null);
            this.RowDy_TB.setParseProperty(    AdvTextBox.ParseDataType.Decimal, null, null);
            this.ColCount_TB.setParseProperty( AdvTextBox.ParseDataType.Integer,    1, null);
            this.ColDx_TB.setParseProperty(    AdvTextBox.ParseDataType.Decimal, null, null);
            this.ColDy_TB.setParseProperty(    AdvTextBox.ParseDataType.Decimal, null, null);
            this.CirCount_TB.setParseProperty( AdvTextBox.ParseDataType.Integer,    1, null);
            this.Radius_TB.setParseProperty(   AdvTextBox.ParseDataType.Decimal, null, null);
        }

        private void ParaSubmin_PB_Click(object sender,RoutedEventArgs e) {
            this.test(ShapeArray.Mode.Deploy);
        }

        private void CirSubmin_PB_Click(object sender,RoutedEventArgs e) {
            this.test(ShapeArray.Mode.Deploy);
        }
        private void test(ShapeArray.Mode mode) {
            this.RemovePreview();
            ShapeRange Selection = Misc.SelectedShapes();
            if(Selection.Count > 0) {
                string Header = ((TabItem)this.Tab.SelectedItem).Header.ToString();
                switch(Header) {
                    case "Parallelogram":
                        AdvTextBox[] RowColTextBox = new AdvTextBox[] { 
                            this.RowCount_TB,this.RowDx_TB,this.RowDy_TB,
                            this.ColCount_TB,this.ColDx_TB,this.ColDy_TB};

                        if(RowColTextBox.All(iTextBox => iTextBox.InputValid)) {
                            ShapeArray.Parallelogram(
                                (int)  this.RowCount_TB.NumericValue,(int)  this.ColCount_TB.NumericValue,
                                (float)this.RowDx_TB.NumericValue,   (float)this.RowDy_TB.NumericValue,
                                (float)this.ColDx_TB.NumericValue,   (float)this.ColDy_TB.NumericValue, mode);
                        }
                        break;

                    case "Circular":
                        AdvTextBox[] CircularTextBox = new AdvTextBox[] {this.CirCount_TB,this.Radius_TB};

                        ShapeArray.OvalType type = (this.Mode_CB.SelectedIndex == 0) ? 
                            ShapeArray.OvalType.Translation : ShapeArray.OvalType.Rotation;

                        if(CircularTextBox.All(iTextBox => iTextBox.InputValid)) {
                            ShapeArray.Circular((float)Radius_TB.NumericValue, (int)CirCount_TB.NumericValue,type, mode);
                        }
                        break;
                }
            }
        }
        private void RemovePreview() {
            if(this.PreviewShapes != null) {
                foreach(Shape iShape in this.PreviewShapes) { iShape.Delete(); }
                this.PreviewShapes = null;
            }
        }
        void WPF_ShapeArray_Closing(object sender,CancelEventArgs e) {
            this.RemovePreview();
            e.Cancel = true;
        }
    }
}
