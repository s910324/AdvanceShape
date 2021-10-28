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
        public WPF_Tester() {
            InitializeComponent();
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

            foreach(KeyValuePair<int, Texture> texture in DefaultTexture.DashDict) {
                BitmapImage bitmap = texture.Value.RenderBitmapImage((int)w,(int)h,1,1,Color.Black,Color.Transparent,Color.Gray);
                sourcelist.Add(new LineDashClass { image = bitmap });
            }

            listview.View        = gridview;
            listview.ItemsSource = sourcelist;
/*            foreach(ItemsControl i in listview.Items) {
                i.MouseEnter += (o,e) => { };
            }*/
            this.AddChild(listview);
            this.Width = w * 2.0;
            this.Height= h* listview.Items.Count * 1.9;
        }
    }
    class LineDashClass {public BitmapImage image { get; set; }}
}
