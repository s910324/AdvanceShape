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
    public partial class WPF_ShapeArray:Window {
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
    }
}
