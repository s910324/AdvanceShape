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
using MsoLineDashStyle  = Microsoft.Office.Core.MsoLineDashStyle;
using MsoPatternType = Microsoft.Office.Core.MsoPatternType;
namespace AdvShape {
    public partial class WPF_Tester:Window {
        private int ImageWidth;
        private int ImageHeight;
        private Dictionary<int,Texture> TextureDict;

        private bool CLoseFlag              = true;
        private bool StyleSelected          = false;
        private TextureWrapper CurrentHover = null;
        List<int?> PreviewStyleList         = new List<int?>();
        List<MsoLineDashStyle?> PreviewLineStyleList    = new List<MsoLineDashStyle?>();
        List<MsoPatternType?>   PreviewTextureStyleList = new List<MsoPatternType?>();
        
        public WPF_Tester() {
            InitializeComponent();
            
            this.KeyDown     += (o,e) => { if(e.Key == Key.Escape) { this.TriggerClose(); } };
            this.MouseLeave  += (o,e) => { this.CancelPreview(); };
            this.Deactivated += (o,e) => { this.TriggerClose(); };

            this.SetPayload(50,12,DefaultTexture.DashDict);

            FrameworkElementFactory factory  = new FrameworkElementFactory(typeof(Image));
            List<TextureWrapper>  sourcelist = new List<TextureWrapper>();
            ListView     listview = new ListView();
            GridView     gridview = new GridView();
            DataTemplate template = new DataTemplate { VisualTree = factory };
            
            factory.SetValue(Image.SourceProperty, new Binding(nameof(TextureWrapper.image)));
            factory.SetValue(Image.WidthProperty,  (double)this.ImageWidth);
            factory.SetValue(Image.HeightProperty, (double)this.ImageHeight);
            gridview.Columns.Add(new GridViewColumn { Header = "line style", CellTemplate = template });

            foreach(KeyValuePair<int, Texture> texturePair in this.TextureDict) {
                BitmapImage bitmap = texturePair.Value.RenderBitmapImage((int)this.ImageWidth,(int)this.ImageHeight,1,1,Color.Black,Color.Transparent,Color.Gray);
                sourcelist.Add(new TextureWrapper { image = bitmap, texture = texturePair.Value, a = texturePair.Key});
            }
            
            listview.View               = gridview;
            listview.ItemsSource        = sourcelist;
            listview.MouseMove         += (o,e) => { this.ItemHovered(o,e); };
            listview.MouseLeftButtonUp += (o,e) => { this.ItemClicked(o,e); };


            this.AddChild(listview);
            this.Width = this.ImageWidth  * 2.0;
            this.Height= this.ImageHeight *listview.Items.Count * 1.9;
            
        }
        private void SetPayload(int image_width, int image_height,Dictionary<int,Texture> texture_dict) {
            this.ImageWidth  = image_width;
            this.ImageHeight = image_height;
            this.TextureDict = texture_dict;


        }
        private void ItemHovered(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) {dep = VisualTreeHelper.GetParent(dep);}
            if(dep == null) {return;}

            ListViewItem item = (ListViewItem)dep;
            if(this.CurrentHover == null || !(this.CurrentHover.Equals((TextureWrapper)item.Content))) {
                this.CurrentHover = (TextureWrapper)item.Content;
                this.Preview();
                Misc.print("hovered", this.CurrentHover.a);
            }
        }
        private void ItemClicked(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) { dep = VisualTreeHelper.GetParent(dep); }
            if(dep == null) { return; }

            this.StyleSelected = true;
            this.TriggerClose();
        }

        private void Preview() {
            this.CollectStyle();
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                foreach(Shape shape in shaperange) {
                    if(shape.Line != null) {
                        shape.Line.DashStyle = (MsoLineDashStyle)this.CurrentHover.a;
                    }
                }
            }
        }
        private void CollectStyle() {
            if(Misc.WithActiveSelection()) {
                ShapeRange shaperange = Misc.SelectedShapes();
                if(this.PreviewLineStyleList.Count == 0) {
                    foreach(Shape shape in shaperange) {
                        if(shape.Line != null) {
                            this.PreviewLineStyleList.Add(shape.Line.DashStyle);
                        } else {
                            this.PreviewLineStyleList.Add(null);
                        }
                    }
                }
            }
        }

        private void CancelPreview() {
            if(Misc.WithActiveSelection() && this.StyleSelected == false) {
                ShapeRange shaperange = Misc.SelectedShapes();
                if(this.PreviewLineStyleList.Count != 0) {
                    int index = 0;
                    foreach(Shape shape in shaperange) {
                        MsoLineDashStyle? style = this.PreviewLineStyleList[index];
                        if(style != null && shape.Line != null) {
                            shape.Line.DashStyle = (MsoLineDashStyle)style;
                        }
                        index++;
                    }
                }
            }
        }
        private void TriggerClose() {
            if(this.CLoseFlag) {
                this.CLoseFlag = false;
                this.Close();
            }
        }
    }


    class TextureWrapper {
        public BitmapImage image  { get; set; }
        public Texture     texture{ get; set; }
        public int a { get; set; }
    }

}
