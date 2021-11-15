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
using Bitmap = System.Drawing.Bitmap;
using Color = System.Drawing.Color;
using Image = System.Windows.Controls.Image;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using MsoLineDashStyle = Microsoft.Office.Core.MsoLineDashStyle;
using MsoPatternType = Microsoft.Office.Core.MsoPatternType;
namespace AdvShape {
    abstract public partial class WPF_Tester:Window {
        protected List<TextureWrapper> sourcelist  = new List<TextureWrapper>();
        protected TextureWrapper      CurrentHover = null;
        protected bool                   CloseFlag = true;
        protected bool               StyleSelected = false;

        public WPF_Tester() {
            InitializeComponent();
        
            this.listview.ItemsSource        = sourcelist;
            this.listview.MouseMove         += (o,e) => { this.ItemHovered(o,e); };
            this.listview.MouseLeftButtonUp += (o,e) => { this.ItemClicked(o,e); };
            this.KeyDown                    += (o,e) => { if(e.Key == Key.Escape) { this.TriggerClose(); } };
            this.MouseLeave                 += (o,e) => { this.CancelPreview(); };
            this.Deactivated                += (o,e) => { this.TriggerClose(); };

            this.SetupPayload();
            this.Width  = 250;
            this.Height = 350;
        }
        protected abstract void SetupPayload();
        protected abstract void Preview();
        protected abstract void CollectStyle();
        protected abstract void CancelPreview();
        protected void ItemHovered(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) { dep = VisualTreeHelper.GetParent(dep); }
            if(dep == null) { return; }

            ListViewItem item = (ListViewItem)dep;
            if(this.CurrentHover == null || !(this.CurrentHover.Equals((TextureWrapper)item.Content))) {
                this.CurrentHover = (TextureWrapper)item.Content;
                this.Preview();
            }
        }
        protected void ItemClicked(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) { dep = VisualTreeHelper.GetParent(dep); }
            if(dep == null) { return; }

            this.StyleSelected = true;
            this.TriggerClose();
        }
        protected void TriggerClose() {
            if(this.CloseFlag) {
                this.CloseFlag = false;
                this.Close();
            }
        }
        protected List<Shape> FlatShapeRange(ShapeRange shaperange) {
            List<Shape> flattened = new List<Shape>();
            foreach(Shape shape in shaperange) {
                if(shape.Child > 0) {
                    foreach(Shape sub_shape in shape.GroupItems) {
                        flattened.Add(sub_shape);
                    }
                } else {
                    flattened.Add(shape);
                }
            }
            return flattened;
        }
    }
    public class WPF_LineDashSelector:WPF_Tester{
        List<MsoLineDashStyle?> PreviewStyleList = new List<MsoLineDashStyle?>();
        protected override void SetupPayload() {
            int ImageWidth  = 50;
            int ImageHeight = 12;

            Color fgcolor = Color.Black;
            Color bgcolor = Color.Transparent;
            Color bdcolor = Color.Gray;
            foreach(KeyValuePair<int,Texture> texturePair in DefaultTexture.DashDict) {

                BitmapImage bitmap = texturePair.Value.RenderBitmapImage((int)ImageWidth,(int)ImageHeight,1,1,fgcolor,bgcolor,bdcolor);

                sourcelist.Add(new TextureWrapper {
                    image   = bitmap,
                    fgcolor = fgcolor,
                    bgcolor = bgcolor,
                    bdcolor = bdcolor,
                    texture = texturePair.Value,
                    data    = texturePair.Key,
                    width   = ImageWidth,
                    height  = ImageHeight
                });
            }
        }
        protected override void Preview() {
            this.CollectStyle();
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                foreach(Shape shape in shaperange) {
                    if(shape.Line != null) {
                        shape.Line.DashStyle = (MsoLineDashStyle)this.CurrentHover.data;
                    }
                }
            }
        }
        protected override void CollectStyle() {
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                if(this.PreviewStyleList.Count == 0) {
                    foreach(Shape shape in this.FlatShapeRange(shaperange)) {
                        if(shape.Line != null) {
                            this.PreviewStyleList.Add(shape.Line.DashStyle);
                        } else {
                            this.PreviewStyleList.Add(null);
                        }
                    }
                }
            }
        }
        protected override void CancelPreview() {
            if(Misc.WithActiveSelection() && this.StyleSelected == false) {
                ShapeRange shaperange = Misc.SelectedShapes();
                if(this.PreviewStyleList.Count != 0) {
                    int index = 0;
                    foreach(Shape shape in this.FlatShapeRange(shaperange)) {
                        if(shape.Line != null) {
                            shape.Line.DashStyle = (MsoLineDashStyle)this.PreviewStyleList[index];
                        }
                        index++;
                    }
                }
            }
        }

    }

    public class WPF_FillTextureSelector:WPF_Tester {
        List<FillFormat> PreviewStyleList = new List<FillFormat>();
        protected override void SetupPayload() {
            int ImageWidth  = 32;
            int ImageHeight = 32;

            Color fgcolor = Color.Black;
            Color bgcolor = Color.Transparent;
            Color bdcolor = Color.Gray;
            foreach(KeyValuePair<int,Texture> texturePair in DefaultTexture.TextureDict) {

                BitmapImage bitmap = texturePair.Value.RenderBitmapImage((int)ImageWidth,(int)ImageHeight,1,1,fgcolor,bgcolor,bdcolor);

                sourcelist.Add(new TextureWrapper {
                    image   = bitmap,
                    fgcolor = fgcolor,
                    bgcolor = bgcolor,
                    bdcolor = bdcolor,
                    texture = texturePair.Value,
                    data    = texturePair.Key,
                    width   = ImageWidth,
                    height  = ImageHeight
                });
            }
        }
        protected override void Preview() {
            this.CollectStyle();
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                foreach(Shape shape in shaperange) {
                    if(shape.Fill != null) {
                        shape.Fill.Patterned((MsoPatternType)this.CurrentHover.data);
                    }
                }
            }
        }
        protected override void CollectStyle() {
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                if(this.PreviewStyleList.Count == 0) {
                    foreach(Shape shape in this.FlatShapeRange(shaperange)) {
                        if(shape.Fill != null) {
                            this.PreviewStyleList.Add(shape.Fill);
                        } else {
                            this.PreviewStyleList.Add(null);
                        }
                    }
                }
            }
        }
        protected override void CancelPreview() {
            if(Misc.WithActiveSelection() && this.StyleSelected == false) {
                ShapeRange shaperange = Misc.SelectedShapes();
                if(this.PreviewStyleList.Count != 0) {
                    int index = 0;
                    foreach(Shape shape in this.FlatShapeRange(shaperange)) {
                        FillFormat style = this.PreviewStyleList[index];
                        if(style != null && shape.Fill != null) {
                            if(style.Type == Microsoft.Office.Core.MsoFillType.msoFillPatterned) {
                                shape.Fill.Solid();
                                Misc.print("XX");
                            } else {
                                shape.Fill.Patterned(style.Pattern);
                            }
                        }
                        index++;
                    }
                }
            }
        }
    }

    public class TextureWrapper {
        public BitmapImage image { get; set; }
        public Texture   texture { get; set; }
        public Color     fgcolor { get; set; }
        public Color     bgcolor { get; set; }
        public Color     bdcolor { get; set; }
        public int          data { get; set; }
        public int         width { get; set; }
        public int        height { get; set; }
    }

}