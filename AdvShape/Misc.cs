using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Office.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;
using Color = System.Windows.Media.Color;
using Slide = Microsoft.Office.Interop.PowerPoint.Slide;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using Selection = Microsoft.Office.Interop.PowerPoint.Selection;
using ShapeRange = Microsoft.Office.Interop.PowerPoint.ShapeRange;
using PpSelectionType = Microsoft.Office.Interop.PowerPoint.PpSelectionType;

namespace AdvShape {
    class Misc {

        static public double RadToDeg(double rad )  { return (rad / 3.14159265358979 * 180); }
        static public double DegToRad(double deg )  { return (deg / 180 * 3.14159265358979); }
        static public double PointsToCm(double pt ) { return (pt * 0.03527778); }
        static public double CmToPoints(double cm ) { return (cm * 28.34646); }

        static public Slide ActiveSlide() { return (Slide)Globals.ThisAddIn.Application.ActiveWindow.View.Slide; }
        static public ShapeRange SelectedShapes() {
            Slide ActiveSlide                = Misc.ActiveSlide();
            Selection CurrentSelection       = (Selection)Globals.ThisAddIn.Application.ActiveWindow.Selection;
            PpSelectionType[] validSelection = new PpSelectionType[] { PpSelectionType.ppSelectionText,PpSelectionType.ppSelectionShapes };
            return validSelection.Contains(CurrentSelection.Type) ? CurrentSelection.ShapeRange : ActiveSlide.Shapes.Range(0);
        }
        static public float ActiveSlideWidth() { return Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideWidth; }
        static public float ActiveSlideHeight() {return Globals.ThisAddIn.Application.ActivePresentation.PageSetup.SlideHeight;}

        static public void RenameShapeInSlide(Slide iSlide) {
            foreach(Shape iShape in iSlide.Shapes) {
                iShape.Name = ShapeTypeString(iShape) + iShape.Id;
            }
        }
        static public string ShapeTypeString(Shape iShape) {
            string result = "";
            switch(iShape.AutoShapeType) {
                case MsoAutoShapeType.msoShape10pointStar: result = "10pointStar"; break;
                case MsoAutoShapeType.msoShape12pointStar: result = "12pointStar"; break;
                case MsoAutoShapeType.msoShape16pointStar: result = "16pointStar"; break;
                case MsoAutoShapeType.msoShape24pointStar: result = "24pointStar"; break;
                case MsoAutoShapeType.msoShape32pointStar: result = "32pointStar"; break;
                case MsoAutoShapeType.msoShape4pointStar: result = "4pointStar"; break;
                case MsoAutoShapeType.msoShape5pointStar: result = "5pointStar"; break;
                case MsoAutoShapeType.msoShape6pointStar: result = "6pointStar"; break;
                case MsoAutoShapeType.msoShape7pointStar: result = "7pointStar"; break;
                case MsoAutoShapeType.msoShape8pointStar: result = "8pointStar"; break;
                case MsoAutoShapeType.msoShapeActionButtonBackorPrevious: result = "ActionButtonBackorPrevious"; break;
                case MsoAutoShapeType.msoShapeActionButtonBeginning: result = "ActionButtonBeginning"; break;
                case MsoAutoShapeType.msoShapeActionButtonCustom: result = "ActionButtonCustom"; break;
                case MsoAutoShapeType.msoShapeActionButtonDocument: result = "ActionButtonDocument"; break;
                case MsoAutoShapeType.msoShapeActionButtonEnd: result = "ActionButtonEnd"; break;
                case MsoAutoShapeType.msoShapeActionButtonForwardorNext: result = "ActionButtonForwardorNext"; break;
                case MsoAutoShapeType.msoShapeActionButtonHelp: result = "ActionButtonHelp"; break;
                case MsoAutoShapeType.msoShapeActionButtonHome: result = "ActionButtonHome"; break;
                case MsoAutoShapeType.msoShapeActionButtonInformation: result = "ActionButtonInformation"; break;
                case MsoAutoShapeType.msoShapeActionButtonMovie: result = "ActionButtonMovie"; break;
                case MsoAutoShapeType.msoShapeActionButtonReturn: result = "ActionButtonReturn"; break;
                case MsoAutoShapeType.msoShapeActionButtonSound: result = "ActionButtonSound"; break;
                case MsoAutoShapeType.msoShapeArc: result = "Arc"; break;
                case MsoAutoShapeType.msoShapeBalloon: result = "Balloon"; break;
                case MsoAutoShapeType.msoShapeBentArrow: result = "BentArrow"; break;
                case MsoAutoShapeType.msoShapeBentUpArrow: result = "BentUpArrow"; break;
                case MsoAutoShapeType.msoShapeBevel: result = "Bevel"; break;
                case MsoAutoShapeType.msoShapeBlockArc: result = "BlockArc"; break;
                case MsoAutoShapeType.msoShapeCan: result = "Can"; break;
                case MsoAutoShapeType.msoShapeChartPlus: result = "ChartPlus"; break;
                case MsoAutoShapeType.msoShapeChartStar: result = "ChartStar"; break;
                case MsoAutoShapeType.msoShapeChartX: result = "ChartX"; break;
                case MsoAutoShapeType.msoShapeChevron: result = "Chevron"; break;
                case MsoAutoShapeType.msoShapeChord: result = "Chord"; break;
                case MsoAutoShapeType.msoShapeCircularArrow: result = "CircularArrow"; break;
                case MsoAutoShapeType.msoShapeCloud: result = "Cloud"; break;
                case MsoAutoShapeType.msoShapeCloudCallout: result = "CloudCallout"; break;
                case MsoAutoShapeType.msoShapeCorner: result = "Corner"; break;
                case MsoAutoShapeType.msoShapeCornerTabs: result = "CornerTabs"; break;
                case MsoAutoShapeType.msoShapeCross: result = "Cross"; break;
                case MsoAutoShapeType.msoShapeCube: result = "Cube"; break;
                case MsoAutoShapeType.msoShapeCurvedDownArrow: result = "CurvedDownArrow"; break;
                case MsoAutoShapeType.msoShapeCurvedDownRibbon: result = "CurvedDownRibbon"; break;
                case MsoAutoShapeType.msoShapeCurvedLeftArrow: result = "CurvedLeftArrow"; break;
                case MsoAutoShapeType.msoShapeCurvedRightArrow: result = "CurvedRightArrow"; break;
                case MsoAutoShapeType.msoShapeCurvedUpArrow: result = "CurvedUpArrow"; break;
                case MsoAutoShapeType.msoShapeCurvedUpRibbon: result = "CurvedUpRibbon"; break;
                case MsoAutoShapeType.msoShapeDecagon: result = "Decagon"; break;
                case MsoAutoShapeType.msoShapeDiagonalStripe: result = "DiagonalStripe"; break;
                case MsoAutoShapeType.msoShapeDiamond: result = "Diamond"; break;
                case MsoAutoShapeType.msoShapeDodecagon: result = "Dodecagon"; break;
                case MsoAutoShapeType.msoShapeDonut: result = "Donut"; break;
                case MsoAutoShapeType.msoShapeDoubleBrace: result = "DoubleBrace"; break;
                case MsoAutoShapeType.msoShapeDoubleBracket: result = "DoubleBracket"; break;
                case MsoAutoShapeType.msoShapeDoubleWave: result = "DoubleWave"; break;
                case MsoAutoShapeType.msoShapeDownArrow: result = "DownArrow"; break;
                case MsoAutoShapeType.msoShapeDownArrowCallout: result = "DownArrowCallout"; break;
                case MsoAutoShapeType.msoShapeDownRibbon: result = "DownRibbon"; break;
                case MsoAutoShapeType.msoShapeExplosion1: result = "Explosion1"; break;
                case MsoAutoShapeType.msoShapeExplosion2: result = "Explosion2"; break;
                case MsoAutoShapeType.msoShapeFlowchartAlternateProcess: result = "FlowchartAlternateProcess"; break;
                case MsoAutoShapeType.msoShapeFlowchartCard: result = "FlowchartCard"; break;
                case MsoAutoShapeType.msoShapeFlowchartCollate: result = "FlowchartCollate"; break;
                case MsoAutoShapeType.msoShapeFlowchartConnector: result = "FlowchartConnector"; break;
                case MsoAutoShapeType.msoShapeFlowchartData: result = "FlowchartData"; break;
                case MsoAutoShapeType.msoShapeFlowchartDecision: result = "FlowchartDecision"; break;
                case MsoAutoShapeType.msoShapeFlowchartDelay: result = "FlowchartDelay"; break;
                case MsoAutoShapeType.msoShapeFlowchartDirectAccessStorage: result = "FlowchartDirectAccessStorage"; break;
                case MsoAutoShapeType.msoShapeFlowchartDisplay: result = "FlowchartDisplay"; break;
                case MsoAutoShapeType.msoShapeFlowchartDocument: result = "FlowchartDocument"; break;
                case MsoAutoShapeType.msoShapeFlowchartExtract: result = "FlowchartExtract"; break;
                case MsoAutoShapeType.msoShapeFlowchartInternalStorage: result = "FlowchartInternalStorage"; break;
                case MsoAutoShapeType.msoShapeFlowchartMagneticDisk: result = "FlowchartMagneticDisk"; break;
                case MsoAutoShapeType.msoShapeFlowchartManualInput: result = "FlowchartManualInput"; break;
                case MsoAutoShapeType.msoShapeFlowchartManualOperation: result = "FlowchartManualOperation"; break;
                case MsoAutoShapeType.msoShapeFlowchartMerge: result = "FlowchartMerge"; break;
                case MsoAutoShapeType.msoShapeFlowchartMultidocument: result = "FlowchartMultidocument"; break;
                case MsoAutoShapeType.msoShapeFlowchartOfflineStorage: result = "FlowchartOfflineStorage"; break;
                case MsoAutoShapeType.msoShapeFlowchartOffpageConnector: result = "FlowchartOffpageConnector"; break;
                case MsoAutoShapeType.msoShapeFlowchartOr: result = "FlowchartOr"; break;
                case MsoAutoShapeType.msoShapeFlowchartPredefinedProcess: result = "FlowchartPredefinedProcess"; break;
                case MsoAutoShapeType.msoShapeFlowchartPreparation: result = "FlowchartPreparation"; break;
                case MsoAutoShapeType.msoShapeFlowchartProcess: result = "FlowchartProcess"; break;
                case MsoAutoShapeType.msoShapeFlowchartPunchedTape: result = "FlowchartPunchedTape"; break;
                case MsoAutoShapeType.msoShapeFlowchartSequentialAccessStorage: result = "FlowchartSequentialAccessStorage"; break;
                case MsoAutoShapeType.msoShapeFlowchartSort: result = "FlowchartSort"; break;
                case MsoAutoShapeType.msoShapeFlowchartStoredData: result = "FlowchartStoredData"; break;
                case MsoAutoShapeType.msoShapeFlowchartSummingJunction: result = "FlowchartSummingJunction"; break;
                case MsoAutoShapeType.msoShapeFlowchartTerminator: result = "FlowchartTerminator"; break;
                case MsoAutoShapeType.msoShapeFoldedCorner: result = "FoldedCorner"; break;
                case MsoAutoShapeType.msoShapeFrame: result = "Frame"; break;
                case MsoAutoShapeType.msoShapeFunnel: result = "Funnel"; break;
                case MsoAutoShapeType.msoShapeGear6: result = "Gear6"; break;
                case MsoAutoShapeType.msoShapeGear9: result = "Gear9"; break;
                case MsoAutoShapeType.msoShapeHalfFrame: result = "HalfFrame"; break;
                case MsoAutoShapeType.msoShapeHeart: result = "Heart"; break;
                case MsoAutoShapeType.msoShapeHeptagon: result = "Heptagon"; break;
                case MsoAutoShapeType.msoShapeHexagon: result = "Hexagon"; break;
                case MsoAutoShapeType.msoShapeHorizontalScroll: result = "HorizontalScroll"; break;
                case MsoAutoShapeType.msoShapeIsoscelesTriangle: result = "IsoscelesTriangle"; break;
                case MsoAutoShapeType.msoShapeLeftArrow: result = "LeftArrow"; break;
                case MsoAutoShapeType.msoShapeLeftArrowCallout: result = "LeftArrowCallout"; break;
                case MsoAutoShapeType.msoShapeLeftBrace: result = "LeftBrace"; break;
                case MsoAutoShapeType.msoShapeLeftBracket: result = "LeftBracket"; break;
                case MsoAutoShapeType.msoShapeLeftCircularArrow: result = "LeftCircularArrow"; break;
                case MsoAutoShapeType.msoShapeLeftRightArrow: result = "LeftRightArrow"; break;
                case MsoAutoShapeType.msoShapeLeftRightArrowCallout: result = "LeftRightArrowCallout"; break;
                case MsoAutoShapeType.msoShapeLeftRightCircularArrow: result = "LeftRightCircularArrow"; break;
                case MsoAutoShapeType.msoShapeLeftRightRibbon: result = "LeftRightRibbon"; break;
                case MsoAutoShapeType.msoShapeLeftRightUpArrow: result = "LeftRightUpArrow"; break;
                case MsoAutoShapeType.msoShapeLeftUpArrow: result = "LeftUpArrow"; break;
                case MsoAutoShapeType.msoShapeLightningBolt: result = "LightningBolt"; break;
                case MsoAutoShapeType.msoShapeLineCallout1: result = "LineCallout1"; break;
                case MsoAutoShapeType.msoShapeLineCallout1AccentBar: result = "LineCallout1AccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout1BorderandAccentBar: result = "LineCallout1BorderandAccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout1NoBorder: result = "LineCallout1NoBorder"; break;
                case MsoAutoShapeType.msoShapeLineCallout2: result = "LineCallout2"; break;
                case MsoAutoShapeType.msoShapeLineCallout2AccentBar: result = "LineCallout2AccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout2BorderandAccentBar: result = "LineCallout2BorderandAccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout2NoBorder: result = "LineCallout2NoBorder"; break;
                case MsoAutoShapeType.msoShapeLineCallout3: result = "LineCallout3"; break;
                case MsoAutoShapeType.msoShapeLineCallout3AccentBar: result = "LineCallout3AccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout3BorderandAccentBar: result = "LineCallout3BorderandAccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout3NoBorder: result = "LineCallout3NoBorder"; break;
                case MsoAutoShapeType.msoShapeLineCallout4: result = "LineCallout4"; break;
                case MsoAutoShapeType.msoShapeLineCallout4AccentBar: result = "LineCallout4AccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout4BorderandAccentBar: result = "LineCallout4BorderandAccentBar"; break;
                case MsoAutoShapeType.msoShapeLineCallout4NoBorder: result = "LineCallout4NoBorder"; break;
                case MsoAutoShapeType.msoShapeLineInverse: result = "LineInverse"; break;
                case MsoAutoShapeType.msoShapeMathDivide: result = "MathDivide"; break;
                case MsoAutoShapeType.msoShapeMathEqual: result = "MathEqual"; break;
                case MsoAutoShapeType.msoShapeMathMinus: result = "MathMinus"; break;
                case MsoAutoShapeType.msoShapeMathMultiply: result = "MathMultiply"; break;
                case MsoAutoShapeType.msoShapeMathNotEqual: result = "MathNotEqual"; break;
                case MsoAutoShapeType.msoShapeMathPlus: result = "MathPlus"; break;
                case MsoAutoShapeType.msoShapeMixed: result = "Mixed"; break;
                case MsoAutoShapeType.msoShapeMoon: result = "Moon"; break;
                case MsoAutoShapeType.msoShapeNonIsoscelesTrapezoid: result = "NonIsoscelesTrapezoid"; break;
                case MsoAutoShapeType.msoShapeNoSymbol: result = "NoSymbol"; break;
                case MsoAutoShapeType.msoShapeNotchedRightArrow: result = "NotchedRightArrow"; break;
                case MsoAutoShapeType.msoShapeNotPrimitive: result = "NotPrimitive"; break;
                case MsoAutoShapeType.msoShapeOctagon: result = "Octagon"; break;
                case MsoAutoShapeType.msoShapeOval: result = "Oval"; break;
                case MsoAutoShapeType.msoShapeOvalCallout: result = "OvalCallout"; break;
                case MsoAutoShapeType.msoShapeParallelogram: result = "Parallelogram"; break;
                case MsoAutoShapeType.msoShapePentagon: result = "Pentagon"; break;
                case MsoAutoShapeType.msoShapePie: result = "Pie"; break;
                case MsoAutoShapeType.msoShapePieWedge: result = "PieWedge"; break;
                case MsoAutoShapeType.msoShapePlaque: result = "Plaque"; break;
                case MsoAutoShapeType.msoShapePlaqueTabs: result = "PlaqueTabs"; break;
                case MsoAutoShapeType.msoShapeQuadArrow: result = "QuadArrow"; break;
                case MsoAutoShapeType.msoShapeQuadArrowCallout: result = "QuadArrowCallout"; break;
                case MsoAutoShapeType.msoShapeRectangle: result = "Rectangle"; break;
                case MsoAutoShapeType.msoShapeRectangularCallout: result = "RectangularCallout"; break;
                case MsoAutoShapeType.msoShapeRegularPentagon: result = "RegularPentagon"; break;
                case MsoAutoShapeType.msoShapeRightArrow: result = "RightArrow"; break;
                case MsoAutoShapeType.msoShapeRightArrowCallout: result = "RightArrowCallout"; break;
                case MsoAutoShapeType.msoShapeRightBrace: result = "RightBrace"; break;
                case MsoAutoShapeType.msoShapeRightBracket: result = "RightBracket"; break;
                case MsoAutoShapeType.msoShapeRightTriangle: result = "RightTriangle"; break;
                case MsoAutoShapeType.msoShapeRound1Rectangle: result = "Round1Rectangle"; break;
                case MsoAutoShapeType.msoShapeRound2DiagRectangle: result = "Round2DiagRectangle"; break;
                case MsoAutoShapeType.msoShapeRound2SameRectangle: result = "Round2SameRectangle"; break;
                case MsoAutoShapeType.msoShapeRoundedRectangle: result = "RoundedRectangle"; break;
                case MsoAutoShapeType.msoShapeRoundedRectangularCallout: result = "RoundedRectangularCallout"; break;
                case MsoAutoShapeType.msoShapeSmileyFace: result = "SmileyFace"; break;
                case MsoAutoShapeType.msoShapeSnip1Rectangle: result = "Snip1Rectangle"; break;
                case MsoAutoShapeType.msoShapeSnip2DiagRectangle: result = "Snip2DiagRectangle"; break;
                case MsoAutoShapeType.msoShapeSnip2SameRectangle: result = "Snip2SameRectangle"; break;
                case MsoAutoShapeType.msoShapeSnipRoundRectangle: result = "SnipRoundRectangle"; break;
                case MsoAutoShapeType.msoShapeSquareTabs: result = "SquareTabs"; break;
                case MsoAutoShapeType.msoShapeStripedRightArrow: result = "StripedRightArrow"; break;
                case MsoAutoShapeType.msoShapeSun: result = "Sun"; break;
                case MsoAutoShapeType.msoShapeSwooshArrow: result = "SwooshArrow"; break;
                case MsoAutoShapeType.msoShapeTear: result = "Tear"; break;
                case MsoAutoShapeType.msoShapeTrapezoid: result = "Trapezoid"; break;
                case MsoAutoShapeType.msoShapeUpArrow: result = "UpArrow"; break;
                case MsoAutoShapeType.msoShapeUpArrowCallout: result = "UpArrowCallout"; break;
                case MsoAutoShapeType.msoShapeUpDownArrow: result = "UpDownArrow"; break;
                case MsoAutoShapeType.msoShapeUpDownArrowCallout: result = "UpDownArrowCallout"; break;
                case MsoAutoShapeType.msoShapeUpRibbon: result = "UpRibbon"; break;
                case MsoAutoShapeType.msoShapeUTurnArrow: result = "UTurnArrow"; break;
                case MsoAutoShapeType.msoShapeVerticalScroll: result = "VerticalScroll"; break;
                case MsoAutoShapeType.msoShapeWave: result = "Wave"; break;
            }
            return result;
        }
        static public double UnifiedAngle(double angle) {
            double result;
            result = (angle % 360) % 180;
            return result > 90 ? -(90 - (result % 90)) : result;
        }

        static public int ARGB(int r, int g, int b) {
            return System.Drawing.Color.FromArgb(b,g,r).ToArgb();
        }
        static public Color RGB(int r,int g,int b) {
            byte Byte_r = Convert.ToByte(r);
            byte Byte_g = Convert.ToByte(g);
            byte Byte_b = Convert.ToByte(b);
            return System.Windows.Media.Color.FromRgb(Byte_r, Byte_g, Byte_b);
        }
        static public void print( params dynamic[] values) {
            String Result = "";
            foreach(var v in values) {
                var r = (v is null) ? "null" : v;
                Result += (Result == "") ? r.ToString() : ", " + r.ToString();
            }
            Debug.WriteLine(Result);
        }
        static public double? MathParse(string input) {
            input = (input.Count<char>() > 0) ?
                (input.Last<char>() == '.' ? input + "0" : input) : input;
            Expression e = new Expression(input);
            if(e.checkSyntax()) { return e.calculate(); } else { return null; }
        }
    }
}
 