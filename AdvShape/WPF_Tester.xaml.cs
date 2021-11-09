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
    public partial class WPF_Tester:Window {
        List<MsoLineDashStyle?> PreviewLineStyleList  = new List<MsoLineDashStyle?>();

        private FrameworkElementFactory factory;
        private List<TextureWrapper> sourcelist;
        private ListView               listview;
        private TextureWrapper      CurrentHover = null;
        private bool                   CloseFlag = true;
        private bool               StyleSelected = false;

        public WPF_Tester() {
            InitializeComponent();

            this.factory          = new FrameworkElementFactory(typeof(Image));
            this.sourcelist       = new List<TextureWrapper>();
            this.listview         = new ListView();
            GridView     gridview = new GridView();
            DataTemplate template = new DataTemplate { VisualTree = factory };

            listview.View         = gridview;
            listview.ItemsSource  = sourcelist;

            gridview.Columns.Add(new GridViewColumn { Header = null,CellTemplate = template });
            factory.SetValue(Image.SourceProperty,new Binding(nameof(TextureWrapper.image)));
            this.AddChild(listview);

            listview.MouseMove         += (o,e) => { this.ItemHovered(o,e); };
            listview.MouseLeftButtonUp += (o,e) => { this.ItemClicked(o,e); };
            this.KeyDown               += (o,e) => { if(e.Key == Key.Escape) { this.TriggerClose(); } };
            this.MouseLeave            += (o,e) => { this.CancelPreview(); };
            this.Deactivated           += (o,e) => { this.TriggerClose(); };

            this.SetupPayload();


        }
        private void SetupPayload() {
            int ImageWidth  = 50;
            int ImageHeight = 12;

            factory.SetValue(Image.WidthProperty, (double)ImageWidth);
            factory.SetValue(Image.HeightProperty,(double)ImageHeight);

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
                    data = texturePair.Key
                });
            }

            this.Width = ImageWidth * 2.0;
            this.Height = ImageHeight * listview.Items.Count * 1.9;
        }

        private void Preview() {
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
        private void ItemHovered(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) { dep = VisualTreeHelper.GetParent(dep); }
            if(dep == null) { return; }

            ListViewItem item = (ListViewItem)dep;
            if(this.CurrentHover == null || !(this.CurrentHover.Equals((TextureWrapper)item.Content))) {
                this.CurrentHover = (TextureWrapper)item.Content;
                this.Preview();
            }
        }
        private void ItemClicked(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) { dep = VisualTreeHelper.GetParent(dep); }
            if(dep == null) { return; }

            this.StyleSelected = true;
            this.TriggerClose();
        }
        private void TriggerClose() {
            if(this.CloseFlag) {
                this.CloseFlag = false;
                this.Close();
            }
        }
    }


    class TextureWrapper {
        public BitmapImage image { get; set; }
        public Texture   texture { get; set; }
        public Color     fgcolor { get; set; }
        public Color     bgcolor { get; set; }
        public Color     bdcolor { get; set; }
        public int          data { get; set; }
    }

}