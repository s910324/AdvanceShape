using System;
using System.Collections.Generic;
using Graphics=System.Drawing.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitmap = System.Drawing.Bitmap;
using Color  = System.Drawing.Color;
using SolidBrush = System.Drawing.SolidBrush;
using BitmapImage = System.Windows.Media.Imaging.BitmapImage;

namespace AdvShape {
    class ImageGenerate {
        public void Draw() {
            int Width = 32;
            int Height = 32;
            Color ForColor = Color.AliceBlue;
            Color BackColor = Color.White;
            Bitmap bitmap = new Bitmap(Width,Height);

            for(var x = 0;x < bitmap.Width;x++) {
                for(var y = 0;y < bitmap.Height;y++) {
                    bitmap.SetPixel(x,y,Color.BlueViolet);
                }
            }

            bitmap.Save("m.bmp");
			
        }
    }
	
    class DefaultTexture{
		

		static public Dictionary<int,Texture> DashDict = new Dictionary<int,Texture> {
			{ 1, new Texture(1, -1, false, new int[][]{
				new int[]{1, 1, 0, -1}
			})},

			{ 3, new Texture(4, -1, false, new int[][]{
				new int[]{1, 1, 0, -1}
			})},

			{ 2, new Texture(4, -1, false, new int[][]{
				new int[]{2, 2, 0, -1}
			})},

			{ 4, new Texture(12, -1, false, new int[][]{
				new int[]{8, 2, 0, -1}
			})},

			{ 5, new Texture(20, -1, false, new int[][]{
				new int[]{8, 2, 0, -1},new int[]{4, 2, 12, -1}
			})},

			{ 7, new Texture(20, -1, false, new int[][]{
				new int[]{16, 2, 0, -1}
			})},

			{ 8, new Texture(28, -1, false, new int[][]{
				new int[]{16, 2, 0, -1},new int[]{4, 2,20, -1},
			})},

			{ 9, new Texture(36, -1, false, new int[][]{
				new int[]{16, 2, 0, -1},new int[]{4, 2,20, -1},
				new int[]{ 4, 2,28, -1}
			})}
		};

		static public Dictionary<int,Texture> TextureDict = new Dictionary<int,Texture>{
			{1 , new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 4, 4}})},

			{2 , new Texture(6, 3,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 3, 2}})},

			{3 , new Texture(4, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 2}})},

			{4 , new Texture(4, 2,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 1}})},

			{5 , new Texture(4, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 1, 1},new int[]{1, 1, 0, 2},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 3}})},

			{6 , new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 4, 0},new int[]{1, 1, 6, 0},
				new int[]{1, 1, 1, 1},new int[]{1, 1, 3, 1},
				new int[]{1, 1, 5, 1},new int[]{1, 1, 7, 1},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 2, 2},
				new int[]{1, 1, 4, 2},new int[]{1, 1, 1, 3},
				new int[]{1, 1, 3, 3},new int[]{1, 1, 5, 3},
				new int[]{1, 1, 7, 3},new int[]{1, 1, 0, 4},
				new int[]{1, 1, 2, 4},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 6, 4},new int[]{1, 1, 1, 5},
				new int[]{1, 1, 3, 5},new int[]{1, 1, 5, 5},
				new int[]{1, 1, 7, 5},new int[]{1, 1, 0, 6},
				new int[]{1, 1, 4, 6},new int[]{1, 1, 6, 6},
				new int[]{1, 1, 1, 7},new int[]{1, 1, 3, 7},
				new int[]{1, 1, 5, 7},new int[]{1, 1, 7, 7}})},

			{7 , new Texture(2, 2,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 1}})},

			{8 , new Texture(4, 4,  true,  new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 1, 1},new int[]{1, 1, 0, 2},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 3}})},

			{9 , new Texture(4, 2,  true, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 1}})},

			{10, new Texture(4, 4,  true,  new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 2}})},

			{11, new Texture(6, 3,  true,  new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 3, 2}})},

			{12, new Texture(8, 8,  true,  new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 4, 4}})},

			{13, new Texture(1, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 0, 1}})},

			{14, new Texture(4, 1,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 0}})},

			{15, new Texture(4, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 0},
				new int[]{1, 1, 1, 1},new int[]{1, 1, 2, 1},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 2},
				new int[]{1, 1, 3, 3},new int[]{1, 1, 0, 3}})},

			{16, new Texture(4, 4,  false, new int[][]{
				new int[]{1, 1, 3, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 2, 1},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 1, 2},new int[]{1, 1, 0, 2},
				new int[]{1, 1, 0, 3},new int[]{1, 1, 3, 3}})},

			{17, new Texture(4, 4,  false, new int[][]{
				new int[]{2, 2, 0, 0},new int[]{2, 2, 2, 2}})},

			{18, new Texture(4, 4,  false, new int[][]{
				new int[]{4, 1, 0, 0},new int[]{2, 1, 1, 1},
				new int[]{4, 1, 0, 2},new int[]{1, 1, 3, 3},
				new int[]{1, 1, 0, 3}})},

			{19, new Texture(1, 6,  false, new int[][]{
				new int[]{1, 1, 0, 0}})},

			{20, new Texture(6, 1,  false, new int[][]{
				new int[]{1, 1, 0, 0}})},

			{21, new Texture(4, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 3}})},

			{22, new Texture(4, 4,  false, new int[][]{
				new int[]{1, 1, 3, 0},new int[]{1, 1, 2, 1},
				new int[]{1, 1, 1, 2},new int[]{1, 1, 0, 3}})},

			{23, new Texture(4, 4,  false, new int[][]{
				new int[]{4, 1, 0, 0},new int[]{1, 4, 0, 0}})},

			{24, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 2},
				new int[]{1, 1, 6, 2},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 2, 6},new int[]{1, 1, 6, 6}})},

			{25, new Texture(6, 6,  false, new int[][]{
				new int[]{1, 1, 1, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 3, 0},new int[]{1, 1, 2, 1},
				new int[]{1, 1, 3, 1},new int[]{1, 1, 4, 1},
				new int[]{1, 1, 3, 2},new int[]{1, 1, 4, 2},
				new int[]{1, 1, 5, 2},new int[]{1, 1, 0, 3},
				new int[]{1, 1, 4, 3},new int[]{1, 1, 5, 3},
				new int[]{1, 1, 0, 4},new int[]{1, 1, 1, 4},
				new int[]{1, 1, 5, 4},new int[]{1, 1, 0, 5},
				new int[]{1, 1, 1, 5},new int[]{1, 1, 2, 5}})},

			{26, new Texture(6, 6,  false, new int[][]{
				new int[]{1, 1, 2, 0},new int[]{1, 1, 3, 0},
				new int[]{1, 1, 4, 0},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 2, 1},new int[]{1, 1, 3, 1},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 1, 2},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 0, 3},
				new int[]{1, 1, 1, 3},new int[]{1, 1, 5, 3},
				new int[]{1, 1, 0, 4},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 5, 4},new int[]{1, 1, 3, 5},
				new int[]{1, 1, 4, 5},new int[]{1, 1, 5, 5}})},

			{27, new Texture(4, 8,  false, new int[][]{
				new int[]{1, 1, 3, 0},new int[]{1, 1, 2, 1},
				new int[]{1, 1, 1, 2},new int[]{1, 1, 0, 3}})},

			{28, new Texture(4, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 3}})},

			{29, new Texture(4, 1,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 0}})},

			{30, new Texture(1, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 0, 2}})},

			{31, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 0, 1},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 0, 3},
				new int[]{1, 1, 4, 4},new int[]{1, 1, 4, 5},
				new int[]{1, 1, 4, 6},new int[]{1, 1, 4, 7}})},

			{32, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 0},
				new int[]{1, 1, 2, 0},new int[]{1, 1, 3, 0},
				new int[]{1, 1, 4, 4},new int[]{1, 1, 5, 4},
				new int[]{1, 1, 6, 4},new int[]{1, 1, 7, 4}})},

			{33, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 0},
				new int[]{1, 1, 3, 0},new int[]{1, 1, 4, 0},
				new int[]{1, 1, 0, 1},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 4, 2},new int[]{1, 1, 5, 2},
				new int[]{1, 1, 0, 3},new int[]{1, 1, 4, 3},
				new int[]{1, 1, 5, 3},new int[]{1, 1, 7, 3},
				new int[]{1, 1, 0, 4},new int[]{1, 1, 2, 4},
				new int[]{1, 1, 3, 4},new int[]{1, 1, 7, 4},
				new int[]{1, 1, 2, 5},new int[]{1, 1, 3, 5},
				new int[]{1, 1, 6, 6},new int[]{1, 1, 7, 6},
				new int[]{1, 1, 3, 7},new int[]{1, 1, 4, 7},
				new int[]{1, 1, 6, 7},new int[]{1, 1, 7, 7}})},

			{34, new Texture(8, 8,  false, new int[][]{
				new int[]{8, 1, 0, 0},new int[]{1, 8, 0, 0}})},

			{35, new Texture(8, 8,  false, new int[][]{
				new int[]{8, 1, 0, 0},new int[]{1, 5, 0, 0},
				new int[]{8, 1, 0, 4},new int[]{1, 5, 4, 4}})},

			{36, new Texture(8, 8,  false, new int[][]{
				new int[]{4, 4, 0, 0},new int[]{4, 4, 4, 4}})},

			{37, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 4, 1},
				new int[]{1, 1, 1, 2},new int[]{1, 1, 6, 3},
				new int[]{1, 1, 3, 4},new int[]{1, 1, 7, 5},
				new int[]{1, 1, 2, 6},new int[]{1, 1, 5, 7}})},

			{38, new Texture(8, 4,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 3},
				new int[]{1, 1, 4, 3},new int[]{1, 1, 5, 2},
				new int[]{1, 1, 6, 1},new int[]{1, 1, 7, 0}})},

			{39, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 3, 0},new int[]{3, 1, 2, 1},
				new int[]{5, 1, 1, 2},new int[]{7, 1, 0, 3},
				new int[]{5, 1, 1, 4},new int[]{3, 1, 2, 5},
				new int[]{1, 1, 3, 6}})},
			{40, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 7, 0},new int[]{1, 1, 6, 1},
				new int[]{1, 1, 5, 2},new int[]{1, 1, 4, 3},
				new int[]{1, 1, 3, 4},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 2, 5},new int[]{1, 1, 5, 5},
				new int[]{1, 1, 1, 6},new int[]{1, 1, 6, 6},
				new int[]{1, 1, 0, 7},new int[]{1, 1, 7, 7}})},

			{41, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 2, 2},new int[]{1, 1, 3, 3},
				new int[]{1, 1, 4, 4},new int[]{1, 1, 5, 5},
				new int[]{1, 1, 6, 6},new int[]{1, 1, 7, 7},
				new int[]{1, 1, 7, 1},new int[]{1, 1, 6, 2},
				new int[]{1, 1, 5, 3},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 3, 5},new int[]{1, 1, 2, 6},
				new int[]{1, 1, 1, 7}})},

			{42, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 4, 0},new int[]{1, 1, 6, 0},
				new int[]{1, 1, 1, 1},new int[]{1, 1, 3, 1},
				new int[]{1, 1, 5, 1},new int[]{1, 1, 7, 1},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 2, 2},
				new int[]{1, 1, 4, 2},new int[]{1, 1, 6, 2},
				new int[]{1, 1, 1, 3},new int[]{1, 1, 3, 3},
				new int[]{1, 1, 5, 3},new int[]{1, 1, 7, 3},
				new int[]{4, 4, 0, 4}})},

			{43, new Texture(8, 8,  false, new int[][]{
				new int[]{3, 1, 1, 0},new int[]{3, 1, 5, 0},
				new int[]{1, 3, 0, 1},new int[]{1, 3, 4, 1},
				new int[]{1, 3, 7, 1},new int[]{3, 3, 5, 2},
				new int[]{3, 1, 1, 4},new int[]{3, 1, 5, 4},
				new int[]{1, 3, 0, 5},new int[]{2, 3, 3, 5},
				new int[]{3, 3, 1, 6}})},

			{44, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 4, 0},
				new int[]{1, 1, 1, 1},new int[]{1, 1, 3, 1},
				new int[]{1, 1, 5, 1},new int[]{1, 1, 2, 2},
				new int[]{1, 1, 6, 2},new int[]{1, 1, 1, 3},
				new int[]{1, 1, 5, 3},new int[]{1, 1, 7, 3},
				new int[]{1, 1, 0, 4},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 3, 5},new int[]{1, 1, 5, 5},
				new int[]{1, 1, 2, 6},new int[]{1, 1, 6, 6},
				new int[]{1, 1, 1, 7},new int[]{1, 1, 3, 7},
				new int[]{1, 1, 7, 7}})},

			{45, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 2, 0},
				new int[]{1, 1, 4, 0},new int[]{1, 1, 6, 0},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 0, 4},
				new int[]{1, 1, 0, 6}})},

			{46, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 0, 0},new int[]{1, 1, 1, 1},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 4, 4},
				new int[]{1, 1, 5, 5},new int[]{1, 1, 4, 6}})},

			{47, new Texture(8, 8,  false, new int[][]{
				new int[]{1, 1, 6, 0},new int[]{1, 1, 7, 0},
				new int[]{1, 1, 0, 1},new int[]{1, 1, 5, 1},
				new int[]{1, 1, 1, 2},new int[]{1, 1, 4, 2},
				new int[]{1, 1, 2, 3},new int[]{1, 1, 3, 3},
				new int[]{1, 1, 4, 4},new int[]{1, 1, 5, 4},
				new int[]{1, 1, 6, 5},new int[]{1, 1, 7, 6},
				new int[]{1, 1, 7, 7}})},

			{48, new Texture(7, 4,  false, new int[][]{
				new int[]{1, 1, 3, 0},new int[]{1, 1, 4, 0},
				new int[]{1, 1, 2, 1},new int[]{1, 1, 5, 1},
				new int[]{1, 1, 0, 2},new int[]{1, 1, 1, 2}})}
		};
    }

    class Texture {
		int     Texturewidth;
		int     TextureHeight;
        bool    TextureReverse;
        int[][] TextureArray;

        public Texture(int Texturewidth, int TextureHeight, bool TextureReverse, int [][] TextureArray) {
            this.Texturewidth   = Texturewidth;
            this.TextureHeight  = TextureHeight;
            this.TextureReverse = TextureReverse;
            this.TextureArray   = TextureArray;
        }

        public Bitmap RenderBitmap(
            int ImageWidth, int ImageHeight, int BorderWidth, int magnified,
            Color ForColor, Color BackColor, Color BorderColor) {

			int RenderTexturewidth  = (this.Texturewidth  == -1) ? ImageWidth  : this.Texturewidth  * magnified;
			int RenderTextureHeight = (this.TextureHeight == -1) ? ImageHeight : this.TextureHeight * magnified;

			if(this.TextureReverse) {
                Color temp = BackColor;
                BackColor  = ForColor;
                ForColor   = temp;
            }

            Bitmap     bitmap      = new Bitmap(ImageWidth,ImageHeight);
            Graphics   graphics    = Graphics.FromImage(bitmap);
            SolidBrush ForeBrush   = new SolidBrush(ForColor);
            SolidBrush BackBrush   = new SolidBrush(BackColor);
            SolidBrush BorderBrush = new SolidBrush(BorderColor);
            graphics.FillRectangle(BackBrush,0,0,ImageWidth,ImageHeight);
            

			for(var x = 0; x < (int)(ImageWidth / RenderTexturewidth)+1; x++) {
                for(var y = 0;y < (int)(ImageHeight / RenderTextureHeight)+1;y++) {
                    foreach(int[] TextureUnit in this.TextureArray) {
                        int UnitWidth  = TextureUnit[0] * magnified;
                        int UnitHeight = TextureUnit[1] * magnified;
                        int UnitX      = (TextureUnit[2] == -1) ? (int)ImageWidth/2  : TextureUnit[2] * magnified;
                        int UnitY      = (TextureUnit[3] == -1) ? (int)ImageHeight/2 : TextureUnit[3] * magnified;

						int PixelX     = (x * RenderTexturewidth)  + UnitX;
                        int PixelY     = (y * RenderTextureHeight) + UnitY;
                        graphics.FillRectangle(ForeBrush,PixelX,PixelY,UnitWidth,UnitHeight);
                    }
                }
            }
            graphics.FillRectangle(BorderBrush, 0, 0, BorderWidth, ImageHeight); //L
            graphics.FillRectangle(BorderBrush, 0, ImageHeight - BorderWidth,ImageWidth,BorderWidth); //U
            graphics.FillRectangle(BorderBrush, ImageWidth - BorderWidth, 0,BorderWidth,ImageHeight); //R
            graphics.FillRectangle(BorderBrush, 0, 0,  ImageWidth, BorderWidth); //D

            graphics.Dispose();
            return bitmap;
        }

		public BitmapImage RenderBitmapImage(
			int ImageWidth,int ImageHeight,int BorderWidth, int magnified,
			Color ForColor,Color BackColor,Color BorderColor) {

			return Bitmap2BitmapImage(
				RenderBitmap(
					ImageWidth, ImageHeight, BorderWidth, magnified,
					ForColor,   BackColor,   BorderColor)
				);
		}
		public BitmapImage Bitmap2BitmapImage(Bitmap bitmap) {
			using(var memory = new System.IO.MemoryStream()) {
				bitmap.Save(memory,System.Drawing.Imaging.ImageFormat.Png);
				memory.Position = 0;

				var bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				bitmapImage.Freeze();

				return bitmapImage;
			}
		}
	}
}
