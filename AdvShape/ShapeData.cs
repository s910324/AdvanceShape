using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Slide = Microsoft.Office.Interop.PowerPoint.Slide ;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using Point = Microsoft.Office.Interop.PowerPoint.Point;
using Points = Microsoft.Office.Interop.PowerPoint.Points;
using ShapeNode = Microsoft.Office.Interop.PowerPoint.ShapeNode;
using MsoTriState = Microsoft.Office.Core.MsoTriState;
using MsoEditingType = Microsoft.Office.Core.MsoEditingType;
using MsoSegmentType = Microsoft.Office.Core.MsoSegmentType;
using MsoAutoShapeType = Microsoft.Office.Core.MsoAutoShapeType;

namespace AdvShape {
    enum NodeType { 
        NullType   = -1,
        VertexType =  0,
        EditType   =  1
    }
    enum LineType {
        NullType     = -1,
        StraightType =  0,
        BezierType   =  1
    }

    enum VertexMode { 
        Null   = -1,
        Vertex =  0, 
        Float  =  1
    }
    class ShapeData {
        private List<ShapeDataNode> DataNodeList;
        private List<ShapeDataLine> DataLineList;
        public  Boundbox Boundbox { get; private set; }
        public ShapeData(Shape ishape) {
            this.DataNodeList = new List<ShapeDataNode>() { };
            this.DataLineList = new List<ShapeDataLine>() { };
            this.Boundbox     = new Boundbox();
            VertexMode mode   = VertexMode.Vertex;
            int FloatCount    = 0;

            for(int i = 1;i <= ishape.Nodes.Count;i++) {
                ShapeNode iNode  = ishape.Nodes[i];
                float[,] iPoint  = (float[,]) iNode.Points;
                float x1 = iPoint[1, 1];
                float y1 = iPoint[1, 2];

                if(iNode.SegmentType == MsoSegmentType.msoSegmentLine) { 
                    if((i < ishape.Nodes.Count) && (ishape.Nodes[i + 1].SegmentType == MsoSegmentType.msoSegmentCurve)) {
                        mode = VertexMode.Float;
                        FloatCount = 0;
                    } else {
                        mode = VertexMode.Vertex;
                        FloatCount = 0;
                    }
                }
                if(iNode.SegmentType == MsoSegmentType.msoSegmentCurve) {
                    mode = VertexMode.Float;
                }

                /*Misc.print("[debug]",
                ((i - 1) < 10) ? (" " + (i - 1).ToString()) : (i - 1).ToString(),
                iNode.EditingType.ToString().Replace("mso",""),
                iNode.SegmentType.ToString().Replace("mso",""),
                FloatCount,
                mode);*/

                if((mode == VertexMode.Float && FloatCount % 3 == 0) ||
                     mode == VertexMode.Vertex) {
                    this.AddDataNode(x1, y1, NodeType.VertexType);
                } else {
                    int j = ( FloatCount % 3 ) == 1 ? i - 1: i + 1;
                    ShapeNode jNode = ishape.Nodes[j];
                    float[,] jPoint = (float[,])jNode.Points;
                    float x2 = jPoint[1,1];
                    float y2 = jPoint[1,2];
                    this.AddDataNode(x1,y1,NodeType.EditType, x2, y2);
                }
                if(mode == VertexMode.Float) {
                    FloatCount++;
                }
            }

            int LineStartIndex = -1;
            for(int i = 0;i < this.DataNodeList.Count;i++) {
                if(this.DataNodeList[i].NodeType == NodeType.VertexType) {
                    if(LineStartIndex == -1) {
                        LineStartIndex = i;
                    } else {
                        List<ShapeDataNode> NodeList = Enumerable.Range(LineStartIndex,i - LineStartIndex + 1).Select(x => this.DataNodeList[x]).ToList();
                        ShapeDataLine DataLine = new ShapeDataLine(NodeList);
                        this.DataLineList.Add(DataLine);
                        LineStartIndex = i;
                    }
                }
            }
            this.CalcBoundbox();
        }
        private void AddDataNode(double x,double y,NodeType nodeType,double? parentX = null,double? parentY = null) {
            ShapeDataNode DNode = new ShapeDataNode(x,y,nodeType,parentX,parentY);
            DataNodeList.Add(DNode);
        }

        private void CalcBoundbox() {
            this.Boundbox = new Boundbox();
            foreach(ShapeDataLine sdn in this.DataLineList) {
                this.Boundbox += sdn.Boundbox;
            }
        }
        public List<ShapeDataNode> ShapeVertexList() {
            return this.DataNodeList.Count == 0 ? this.DataNodeList : this.DataNodeList.FindAll(e => e.NodeType == NodeType.VertexType);
        }
        public List<ShapeDataNode> ShapeEditList() {
            return this.DataNodeList.Count == 0 ? this.DataNodeList : this.DataNodeList.FindAll(e => e.NodeType == NodeType.EditType);
        }
        public List<ShapeDataLine> StraightLineList() {
            return this.DataLineList.Count == 0 ? this.DataLineList : this.DataLineList.FindAll(e => e.LineType == LineType.StraightType);
        }
        public List<ShapeDataLine> BezierLineList() {
            return this.DataLineList.Count == 0 ? this.DataLineList : this.DataLineList.FindAll(e => e.LineType == LineType.BezierType);
        }


        public void DebugMode() {
            Slide ActiveSlide   = Misc.ActiveSlide();
            float TextWidth     = 40;
            float TextHeight    = 10;
            float TextSize      = 9;
            float TextOffset    = 8;
            float VertexSize    = 6;
            float EditSize      = 4;
            float LineSegSize   = 2;
            int   SegmentCount  = 20;
            bool  DebugVertex   = true;
            bool  DebugLine     = true;
            bool  DebugBoundbox = false;

            if(DebugVertex) {
                foreach(ShapeDataNode sdn in this.ShapeVertexList()) {
                    Shape VertixRect = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                        (float)(sdn.X - VertexSize / 2),(float)(sdn.Y - VertexSize / 2),VertexSize,VertexSize);
                    VertixRect.Fill.ForeColor.RGB = Misc.ARGB(50,50,50);
                    VertixRect.Line.Visible = MsoTriState.msoFalse;
                }
                foreach(ShapeDataNode sdn in this.ShapeEditList()) {
                    Shape VertixOval = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                        (float)(sdn.X - EditSize / 2),(float)(sdn.Y - EditSize / 2),EditSize,EditSize);
                    Shape EditLine = ActiveSlide.Shapes.AddLine((float)sdn.X,(float)sdn.Y,(float)sdn.ParentX,(float)sdn.ParentY);
                    VertixOval.Line.Visible = MsoTriState.msoFalse;
                    VertixOval.Fill.ForeColor.RGB = Misc.ARGB(250,80,150);
                    EditLine.Line.ForeColor.RGB = Misc.ARGB(100,100,100);
                    EditLine.Line.Weight = 0.5f;
                }

                for(int i = 0;i < this.DataNodeList.Count;i++) {
                    ShapeDataNode sdn = this.DataNodeList[i];
                    Shape TextRect = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                        (float)(sdn.X + TextOffset - TextWidth / 2),(float)(sdn.Y - TextOffset - TextHeight / 2),TextWidth,TextHeight);
                    TextRect.Line.Visible = MsoTriState.msoFalse;
                    TextRect.Fill.Visible = MsoTriState.msoFalse;
                    TextRect.TextFrame.TextRange.Font.Size = TextSize;
                    TextRect.TextFrame.TextRange.Font.Color.RGB = Misc.ARGB(180,150,5);
                    TextRect.TextFrame.TextRange.Text = i.ToString();
                }
            }

            if(DebugLine) {
                foreach(ShapeDataLine sdl in this.StraightLineList()) {
                    foreach(double[] p in sdl.LineSegment(SegmentCount)) {
                        Shape SegmentOval = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                        (float)(p[0] - LineSegSize / 2),(float)(p[1] - LineSegSize / 2),LineSegSize,LineSegSize);
                        SegmentOval.Line.Visible = MsoTriState.msoFalse;
                        SegmentOval.Fill.ForeColor.RGB = Misc.ARGB(80,200,80);
                        SegmentOval.Fill.Transparency = 0.3f;
                    }
                }

                foreach(ShapeDataLine sdl in this.BezierLineList()) {
                    foreach(double[] p in sdl.LineSegment(SegmentCount)) {
                        Shape SegmentOval = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeOval,
                        (float)(p[0] - LineSegSize / 2),(float)(p[1] - LineSegSize / 2),LineSegSize,LineSegSize);
                        SegmentOval.Line.Visible = MsoTriState.msoFalse;
                        SegmentOval.Fill.ForeColor.RGB = Misc.ARGB(80,80,200);
                        SegmentOval.Fill.Transparency = 0.3f;
                    }
                }
            }

            if(DebugBoundbox) {
                foreach(ShapeDataLine sdl in this.DataLineList) {
                    Shape BoundRect = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                            (float)(sdl.Boundbox.Xc - sdl.Boundbox.Width / 2),(float)(sdl.Boundbox.Yc - sdl.Boundbox.Height / 2),
                            (float)sdl.Boundbox.Width,(float)sdl.Boundbox.Height);
                    BoundRect.Fill.Visible = MsoTriState.msoFalse;
                    BoundRect.Line.ForeColor.RGB = Misc.ARGB(120,180,9);
                    BoundRect.Line.Weight = 0.5f;
                }
                Shape ParentRect = ActiveSlide.Shapes.AddShape(MsoAutoShapeType.msoShapeRectangle,
                        (float)(this.Boundbox.Xc - this.Boundbox.Width / 2),(float)(this.Boundbox.Yc - this.Boundbox.Height / 2),
                        (float)this.Boundbox.Width,(float)this.Boundbox.Height);
                ParentRect.Fill.Visible = MsoTriState.msoFalse;
                ParentRect.Line.ForeColor.RGB = Misc.ARGB(180,120,90);
                ParentRect.Line.Weight = 0.5f;
            }
        }
    }
    class ShapeDataLine {
        public LineType LineType { get; private set; }
        public List<ShapeDataNode> NodeList { get; private set; }
        public Boundbox Boundbox { get; private set;  }

        public ShapeDataLine(List<ShapeDataNode> nodes) {
            
            NodeType[] VertexAttribute   = nodes.Select(node => node.NodeType).ToArray();
            NodeType[] StraightLineAttri = { NodeType.VertexType,NodeType.VertexType };
            NodeType[] BezierLineAttri   = { NodeType.VertexType,NodeType.EditType,NodeType.EditType,NodeType.VertexType };

            if(Enumerable.SequenceEqual(VertexAttribute,StraightLineAttri)) {
                this.LineType = LineType.StraightType;
                this.NodeList = nodes;
                this.Boundbox = this.StraightBoundBox();
                
            } else if(Enumerable.SequenceEqual(VertexAttribute,BezierLineAttri)) {
                this.LineType = LineType.BezierType;
                this.NodeList = nodes;
                this.Boundbox = BezierBoundBox();
            } else {
                LineType = LineType.NullType;
            }
        }

        private double EvalBez(double[] poly,double t) {
            double q = 1 - t;
            return (
                    poly[0] * q * q * q +
                3 * poly[1] * q * q * t +
                3 * poly[2] * q * t * t +
                    poly[3] * t * t * t);
        }
        public double[][] LineSegment(int Steps = 12) {
            List<double[]> result = new List<double[]> { };

            if(this.LineType == LineType.StraightType) {
                double x0 = this.NodeList[0].X;
                double y0 = this.NodeList[0].Y;
                double dx = (this.NodeList[1].X - this.NodeList[0].X) / (Steps -1 );
                double dy = (this.NodeList[1].Y - this.NodeList[0].Y) / (Steps - 1);

                for(var i = 0;i <= Steps - 1;i++) {
                    result.Add(new double[] {x0 + (i * dx), y0 + (i * dy)});
                }
            }
            if(this.LineType == LineType.BezierType) {
                double[] PX = this.NodeList.Select(node => node.X).ToArray();
                double[] PY = this.NodeList.Select(node => node.Y).ToArray();
                for(var i = 0;i <= Steps - 1;i++) {
                    if(i == 0) {
                        result.Add(new double[] { PX[0],PY[0] });
                    } else {
                        double t = ((double)i / (Steps - 1));
                        result.Add(new double[] { this.EvalBez(PX,t),this.EvalBez(PY,t) });
                    }
                }
            }
            return result.ToArray();
        }

        private double[] BezierBoundary(double[] NodeAxialArray) {
            double a     = 3 * NodeAxialArray[3] -  9 * NodeAxialArray[2] + 9 * NodeAxialArray[1] - 3 * NodeAxialArray[0];
            double b     = 6 * NodeAxialArray[0] - 12 * NodeAxialArray[1] + 6 * NodeAxialArray[2];
            double c     = 3 * NodeAxialArray[1] -  3 * NodeAxialArray[0];
            double dis   = b * b - 4 * a * c;
            double min_p = (NodeAxialArray[3] < NodeAxialArray[0]) ? NodeAxialArray[3] : NodeAxialArray[0];
            double max_p = (NodeAxialArray[3] > NodeAxialArray[0]) ? NodeAxialArray[3] : NodeAxialArray[0];
            if(dis >= 0) {
                double t1 = (-b + Math.Sqrt(dis)) / (2 * a);
                if(t1 > 0 && t1 < 1) {
                    double x1 = this.EvalBez(NodeAxialArray,t1);
                    min_p = (x1 < min_p) ? x1 : min_p;
                    max_p = (x1 > max_p) ? x1 : max_p;
                }
                double t2 = (-b - Math.Sqrt(dis)) / (2 * a);
                if(t2 > 0 && t2 < 1) {
                    double x2 = this.EvalBez(NodeAxialArray,t2);
                    min_p = (x2 < min_p) ? x2 : min_p;
                    max_p = (x2 > max_p) ? x2 : max_p;
                }
            }
            return new double[] { min_p,max_p };
        }

        private Boundbox BezierBoundBox() {
            double[] BoundX = this.BezierBoundary(this.NodeList.Select(node => node.X).ToArray());
            double[] BoundY = this.BezierBoundary(this.NodeList.Select(node => node.Y).ToArray());
            return new Boundbox(BoundX[0],BoundX[1],BoundY[0],BoundY[1]);
        }
        private Boundbox StraightBoundBox() {
            double Left   = this.NodeList.Select(node => node.X).Min();
            double Right  = this.NodeList.Select(node => node.X).Max();
            double Top    = this.NodeList.Select(node => node.Y).Min();
            double Bottom = this.NodeList.Select(node => node.Y).Max();
            return new Boundbox(Left,Right,Top,Bottom);
        }

    }
    class ShapeDataNode {
        public double   X         { get; private set; }
        public double   Y         { get; private set; }
        public NodeType NodeType  { get; private set; }
        public double?  ParentX   { get; private set; }
        public double?  ParentY   { get; private set; }
        public bool     HasParent { get; private set; }

        public ShapeDataNode(double x, double y, NodeType nodeType, double? parentX = null, double? parentY = null) {
            this.X = x;
            this.Y = y;
            this.NodeType  = nodeType;
            this.ParentX   = parentX;
            this.ParentY   = parentY;
            this.HasParent = !(this.ParentX == null);
        }
    }
}
