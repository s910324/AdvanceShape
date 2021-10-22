using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Color = System.Windows.Media.Color;
using DataTable = System.Data.DataTable;
using ToolTip = System.Windows.Controls.ToolTip;
using TextBox = System.Windows.Controls.TextBox;
using Grid = System.Windows.Controls.Grid;
using Button = System.Windows.Controls.Button;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;
using GridLength = System.Windows.GridLength;
using GridUnitType = System.Windows.GridUnitType;
using UIElement = System.Windows.UIElement;
using System.Windows.Input;
using System.Windows.Controls;
using VerticalAlignment = System.Windows.VerticalAlignment;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
namespace AdvShape {

    public class UserInterface {




    }
    public class AdvTextBox:TextBox {
        public enum ParseDataType {
            Integer = 1,
            Decimal = 2,
            String  = 3
        }

        public Dictionary<string,Color> Theme = new Dictionary<string,Color>(){
            {"BackgroundColor",        Misc.RGB(255,255,255)},
            {"ForegroundColor",        Misc.RGB(  0,  0,  0)},
            {"BorderColor",            Misc.RGB(171,173,179)},
            {"InvalidBackgroundColor", Misc.RGB(255,230,230)},
            {"InvalidForegroundColor", Misc.RGB( 25,  0,  0)},
            {"InvalidBorderColor",     Misc.RGB(250,173,179)}
        };

        public double? NumericValue { get; private set; }
        public bool    InputValid   { get; private set; }
/*        private string text;
        public new string Text {
            get {return text;}
            set {text = value; this.TextBoxOnChangeFormat();}
        }*/

        public ParseDataType ParseType  = ParseDataType.String;
        public Double?       LowerLimit = null;
        public Double?       UpperLimit = null;


        public AdvTextBox() {
            this.TextBoxOnChangeFormat();
            this.TextChanged += (o,e) => { this.TextBoxOnChangeFormat(); };
            this.Loaded      += (o,e) => { this.TextBoxOnChangeFormat(); };
            this.KeyDown     += (o,e) => { this.OnKeyDownHandler(o,e); };
        }
        
        public AdvTextBox setParseProperty(ParseDataType Type, Double? LowerLimit, Double? UpperLimit) {
            ToolTip ParseToolTip = new ToolTip();
            this.ParseType       = Type;
            this.LowerLimit      = LowerLimit;
            this.UpperLimit      = UpperLimit;
            string TipHint       = "";

            if((this.ParseType != ParseDataType.String) && (this.LowerLimit != null) && (this.UpperLimit != null)) {
                this.ToolTip = ParseToolTip;
                TipHint = String.Format("{0} Range: {1}~{2}",
                    (this.ParseType == ParseDataType.Integer) ? "Integer" : "Decimal",
                    this.LowerLimit,this.UpperLimit);
            }
            if((this.ParseType != ParseDataType.String) && (this.LowerLimit == null) && (this.UpperLimit != null)) {
                this.ToolTip = ParseToolTip;
                TipHint = String.Format("{0} Value ≤ {1}",
                    (this.ParseType == ParseDataType.Integer) ? "Integer" : "Decimal",
                    this.UpperLimit);
            }
            if((this.ParseType != ParseDataType.String) && (this.LowerLimit != null) && (this.UpperLimit == null)) {
                this.ToolTip = ParseToolTip;
                TipHint = String.Format("{0} Value ≥ {1}",
                    (this.ParseType == ParseDataType.Integer) ? "Integer" : "Decimal",
                    this.LowerLimit);
            }
            if(TipHint != "") {((ToolTip)this.ToolTip).Content = TipHint;}
            return this;
        }
        private void OnKeyDownHandler(object sender,KeyEventArgs e) {
            if(e.Key == Key.Return && this.InputValid) { this.Text = NumericValue.ToString(); }
        }

        private void TextBoxOnChangeFormat() {
            Misc.print("textChanged");
            bool RangeValid = false;

            if(this.ParseType != ParseDataType.String) {
                this.NumericValue = Misc.MathParse(this.Text);
                RangeValid        = NumericValue != null &&
                               ((LowerLimit != null) ? (LowerLimit <= NumericValue) : true) &&
                               ((UpperLimit != null) ? (UpperLimit >= NumericValue) : true);
            }

            switch(this.ParseType) {
                case ParseDataType.String:
                    this.InputValid = true;
                    break;
                case ParseDataType.Integer:
                    this.InputValid = (NumericValue != null && (NumericValue == (int)NumericValue) && 
                        RangeValid);
                    break;
                case ParseDataType.Decimal:
                    this.InputValid = (NumericValue != null) && RangeValid;
                    break;
            }

            this.Background  = new SolidColorBrush(this.InputValid ? this.Theme["BackgroundColor"] : this.Theme["InvalidBackgroundColor"]);
            this.Foreground  = new SolidColorBrush(this.InputValid ? this.Theme["ForegroundColor"] : this.Theme["InvalidForegroundColor"]);
            this.BorderBrush = new SolidColorBrush(this.InputValid ? this.Theme["BorderColor"]     : this.Theme["InvalidBorderColor"]);

            if(this.ToolTip != null) {((ToolTip)this.ToolTip).IsOpen = !this.InputValid;}
        }
    }
    public class AdvSpinBox:UserControl {
        private Grid       grid;
        private Button     buttonUp;
        private Button     buttonDown;
        private AdvTextBox advTextBox;
        public  Double     Increment;


        Dictionary<string,Color> Theme { 
            get { return this.advTextBox.Theme; }
            set { this.advTextBox.Theme = value; }
        }
        public String Text {
            get { return this.advTextBox.Text; }
            set { this.advTextBox.Text = value; }
        }
        public Double? NumericValue {
            get { return this.advTextBox.NumericValue; }
        }
        public bool InputValid {
            get { return this.advTextBox.InputValid; }
        }
        public AdvTextBox.ParseDataType ParseType {
            get { return this.advTextBox.ParseType; }
            set { this.advTextBox.ParseType = value; }
        }
        public Double? LowerLimit {
            get { return this.advTextBox.LowerLimit; }
            set { this.advTextBox.LowerLimit = value; }
        }
        public Double? UpperLimit {
            get { return this.advTextBox.LowerLimit; }
            set { this.advTextBox.LowerLimit = value; }
        }

        public AdvSpinBox() {
            this.InitializedComponents();
            /*this.Style.BasedOn = advTextBox.Style;*/
        }
        private void InitializedComponents() {
            
            this.grid       = this.GenerateGrid(new string[] { "*","*" },new string[] { "*","15" });
            this.Increment = 1;
            this.advTextBox = new AdvTextBox();
            this.buttonUp   = new Button();
            this.buttonDown = new Button();
            this.buttonUp.Content    = "▲";
            this.buttonDown.Content  = "▼";
            this.buttonUp.FontSize   = 6;
            this.buttonDown.FontSize = 6;
            this.setRowColumn(grid,advTextBox, 0, 0, 2, 1);
            this.setRowColumn(grid,buttonUp,   0, 1, 1, 1);
            this.setRowColumn(grid,buttonDown, 1, 1, 1, 1);
            this.AddChild(grid);
            this.buttonUp.Click   += (o,i) => { if(this.advTextBox.NumericValue != null) 
                { this.Text = (this.advTextBox.NumericValue + this.Increment).ToString(); }
                Misc.print("clicked",this.advTextBox.NumericValue,this.advTextBox.Text, this.Text, "XX");
            };
            this.buttonDown.Click += (o,i) => { if(this.advTextBox.NumericValue != null) 
                { this.advTextBox.Text = (this.advTextBox.NumericValue - Increment).ToString(); }};
            this.Text = this.Text;
        }


        public AdvSpinBox setParseProperty(AdvTextBox.ParseDataType Type,Double? LowerLimit,Double? UpperLimit) {
            this.advTextBox.setParseProperty(Type,LowerLimit,UpperLimit);
            return this;
        }

        private void setRowColumn(Grid grid, UIElement element,
            int rowIndex,int columnIndex,int rowSpan = 1,int colSpan = 1) {
            Grid.SetRow(element,rowIndex);
            Grid.SetRowSpan(element,rowSpan);
            Grid.SetColumn(element,columnIndex);
            Grid.SetColumnSpan(element,colSpan);
            grid.Children.Add(element);
        }
        private Grid GenerateGrid(string[] RowDimParas,string[] ColDomParas) {
            Grid grid = new Grid();
            foreach(string RowDim in RowDimParas) {
                int Dimension = 1;
                GridUnitType UnitType = GridUnitType.Auto;

                if(RowDim.ToLower() == "auto") {
                    UnitType = GridUnitType.Auto;
                } else if(RowDim == "*") {
                    UnitType = GridUnitType.Star;
                } else if(RowDim.Contains("*")) {
                    UnitType = GridUnitType.Star;
                    Dimension = int.Parse(RowDim.Replace("*",""));
                } else if(int.TryParse(RowDim,out Dimension)) {
                    UnitType = GridUnitType.Pixel;
                }

                RowDefinition RowDef = new RowDefinition();
                RowDef.Height = new GridLength(Dimension,UnitType);
                grid.RowDefinitions.Add(RowDef);
            }
            foreach(string ColDim in ColDomParas) {
                int Dimension = 1;
                GridUnitType UnitType = GridUnitType.Auto;

                if(ColDim.ToLower() == "auto") {
                    UnitType = GridUnitType.Auto;
                } else if(ColDim == "*") {
                    UnitType = GridUnitType.Star;
                } else if(ColDim.Contains("*")) {
                    UnitType = GridUnitType.Star;
                    Dimension = int.Parse(ColDim.Replace("*",""));
                } else if(int.TryParse(ColDim,out Dimension)) {
                    UnitType = GridUnitType.Pixel;
                }

                ColumnDefinition ColDef = new ColumnDefinition();
                ColDef.Width = new GridLength(Dimension,UnitType);
                grid.ColumnDefinitions.Add(ColDef);
            }
            return grid;
        }
    }
}
