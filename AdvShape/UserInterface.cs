using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Color = System.Windows.Media.Color;
using DataTable = System.Data.DataTable;
using ToolTip = System.Windows.Controls.ToolTip;
using TextBox = System.Windows.Controls.TextBox;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;
using System.Windows.Input;

namespace AdvShape {

    class UserInterface {




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

}
