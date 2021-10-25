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
            int h = 30;
            int w = 96;
            int rowcounts     = DefaultTexture.TextureDict.Count;
            string [] rowconf = Enumerable.Range(0,rowcounts).Select(n => h.ToString()).ToArray();
            Grid grid         = UserInterface.GenerateGrid(rowconf,new string[] { "128", w.ToString() });
            int rowIndex      = 0;
            foreach(KeyValuePair<int,Texture> item in DefaultTexture.TextureDict) { 
                Texture texture = item.Value;
                Image  i = new System.Windows.Controls.Image();
                Label  l = new Label();
                BitmapImage b = texture.RenderBitmapImage(w*2,h*2,1,Color.Black,Color.Red,Color.Black);
                l.Content = (rowIndex + 1).ToString();
                i.Width   = w;
                i.Height  = h;
                i.Source  = b;

                UserInterface.setRowColumn(grid, i, rowIndex, 1);
                UserInterface.setRowColumn(grid, l, rowIndex, 0);
                rowIndex++;

            }
            ScrollViewer sv = new ScrollViewer();
            sv.Content = grid;
            this.AddChild(sv);
        }
    }
}
