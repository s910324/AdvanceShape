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

namespace AdvShape {
    public partial class WPF_Tester:Window {
        private LineDashClass CurrentHover=null;
        public WPF_Tester() {
            InitializeComponent();
            this.KeyDown     += (o,e) => { if(e.Key == Key.Escape) { this.Close(); } };
            this.Deactivated += (o,e) => { this.Close(); };
            
            double h = 12;
            double w = 50;

            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(Image));
            List<LineDashClass>  sourcelist = new List<LineDashClass>();
            ListView     listview = new ListView();
            GridView     gridview = new GridView();
            DataTemplate template = new DataTemplate { VisualTree = factory };
            
            factory.SetValue(Image.SourceProperty, new Binding(nameof(LineDashClass.image)));
            factory.SetValue(Image.WidthProperty,  w);
            factory.SetValue(Image.HeightProperty, h);
            gridview.Columns.Add(new GridViewColumn { Header = "line style", CellTemplate = template });

            foreach(KeyValuePair<int, Texture> texturePair in DefaultTexture.DashDict) {
                BitmapImage bitmap = texturePair.Value.RenderBitmapImage((int)w,(int)h,1,1,Color.Black,Color.Transparent,Color.Gray);
                sourcelist.Add(new LineDashClass { image = bitmap, texture = texturePair.Value, a = texturePair.Key});
            }
            
            listview.View               = gridview;
            listview.ItemsSource        = sourcelist;
            listview.MouseMove         += (o,e) => { this.ItemHovered(o,e); };
            listview.MouseLeftButtonUp += (o,e) => { this.ItemClicked(o,e); };


            this.AddChild(listview);
            this.Width = w * 2.0;
            this.Height= h* listview.Items.Count * 1.9;
            
        }
        private void ItemHovered(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) {dep = VisualTreeHelper.GetParent(dep);}
            if(dep == null) {return;}

            ListViewItem item = (ListViewItem)dep;
            if(this.CurrentHover == null || !(this.CurrentHover.Equals((LineDashClass)item.Content))) {
                this.CurrentHover = (LineDashClass)item.Content;
                Misc.print("hovered", this.CurrentHover.a);
            }
        }
        private void ItemClicked(object sender,RoutedEventArgs e) {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while((dep != null) && !(dep is ListViewItem)) { dep = VisualTreeHelper.GetParent(dep); }
            if(dep == null) { return; }

            ListViewItem item = (ListViewItem)dep;
            Misc.print("clicked",((LineDashClass)item.Content).a);
            this.Close();
        }
 

    }
    class LineDashClass {
        public BitmapImage image  { get; set; }
        public Texture     texture{ get; set; }
        public int a { get; set; }
    }
}
