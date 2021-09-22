using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;
using Color = System.Windows.Media.Color;
using DataTable = System.Data.DataTable;
using TextBox = System.Windows.Controls.TextBox;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;


namespace AdvShape {
    enum TextBoxDataType{ 
        Integer = 1,
        Decimal = 2,
        String  = 3
    }
    class UserInterface {
        static Dictionary<string,Color> DefaultTheme = new Dictionary<string,Color>(){
            {"BackgroundColor",        Misc.RGB(255,255,255)},
            {"ForegroundColor",        Misc.RGB(  0,  0,  0)},
            {"BorderColor",            Misc.RGB(171,173,179)},
            {"InvalidBackgroundColor", Misc.RGB(255,230,230)},
            {"InvalidForegroundColor", Misc.RGB( 25,  0,  0)},
            {"InvalidBorderColor",     Misc.RGB(200,173,179)}
        };
        static public double? MathParser(string input) {
            input = (input.Count<char>() > 0) ?
                (input.Last<char>() == '.' ? input + "0" : input) : input;
            Expression e = new Expression(input);
            if(e.checkSyntax()) { return e.calculate(); } else { return null; }
        }
        static public void TextBoxFormat(TextBox textBox,TextBoxDataType Type,Double? LowerLimit,Double? UpperLimit,
            string ErrorValue = "",dynamic Theme = null) {

            string StringValue   = textBox.Text;
            double? NumericValue = null;
            bool IntegerValid    = false;
            bool DecimalValid    = false;
            bool RangeValid      = false;
            bool InputValid      = false;

            if(Type != TextBoxDataType.String) {
                NumericValue = MathParser(StringValue);
                DecimalValid = NumericValue != null;
                IntegerValid = NumericValue != null && (NumericValue == ((double)(int)NumericValue));
                RangeValid   = NumericValue != null &&
                               ((LowerLimit != null) ? (LowerLimit >= NumericValue) : true) &&
                               ((UpperLimit != null) ? (UpperLimit <= NumericValue) : true);
            }

            switch(Type) {
                case TextBoxDataType.String:
                    InputValid = true;
                    break;
                case TextBoxDataType.Integer:
                    InputValid   = (IntegerValid && RangeValid);
                    textBox.Text = (InputValid) ?
                    NumericValue.ToString() : ((ErrorValue != null) ? ErrorValue : StringValue);
                    break;
                case TextBoxDataType.Decimal:
                    InputValid   = (DecimalValid && RangeValid);
                    textBox.Text = (InputValid) ?
                    NumericValue.ToString() : ((ErrorValue != null) ? ErrorValue : StringValue);
                    break;
            }

            Dictionary<string,Color> ApplyTheme = (Theme == null) ? UserInterface.DefaultTheme : Theme;
            textBox.Background  = new SolidColorBrush(InputValid ? ApplyTheme["BackgroundColor"] : ApplyTheme["InvalidBackgroundColor"]);
            textBox.Foreground  = new SolidColorBrush(InputValid ? ApplyTheme["ForegroundColor"] : ApplyTheme["InvalidForegroundColor"]);
            textBox.BorderBrush = new SolidColorBrush(InputValid ? ApplyTheme["BorderColor"]     : ApplyTheme["InvalidBorderColor"]);
        }

         static public void Debug() {
            Misc.print(MathParser("23"));
            Misc.print(MathParser("23."));
            Misc.print(MathParser("23.0"));
            Misc.print(MathParser(".23"));
            Misc.print(MathParser("asd"));
        }
    }


}
