using System;
using System.Collections.Generic;
using Graphics=System.Drawing.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitmap = System.Drawing.Bitmap;
using Color  = System.Drawing.Color;
using SolidBrush = System.Drawing.SolidBrush;

namespace AdvShape {
    class ImageGenerate {
        public void Draw() {
            int Width       = 32;
            int Height      = 32;
            Color ForColor  = Color.AliceBlue;
            Color BackColor = Color.White;
            Bitmap bitmap   = new Bitmap(Width,Height);

            for(var x = 0;x < bitmap.Width;x++) {
                for(var y = 0;y < bitmap.Height;y++) {
                    bitmap.SetPixel(x,y,Color.BlueViolet);
                }
            }

            bitmap.Save("m.bmp");
        }
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

        public Bitmap RenderBitmap(int ImageWidth,int ImageHeight,Color ForColor, Color BackColor) {

            if(this.TextureReverse) {
                Color temp = BackColor;
                BackColor  = ForColor;
                ForColor   = temp;
            }

            Bitmap     bitmap    = new Bitmap(ImageWidth,ImageHeight);
            Graphics   graphics  = Graphics.FromImage(bitmap);
            SolidBrush ForeBrush = new SolidBrush(ForColor);
            SolidBrush BackBrush = new SolidBrush(BackColor);
            graphics.FillRectangle(BackBrush,0,0,ImageWidth,ImageHeight);
            
            for(var x = 0; x < (int)(ImageWidth / this.Texturewidth); x++) {
                for(var y = 0;y < (int)(ImageHeight / this.TextureHeight);y++) {
                    foreach(int[] TextureUnit in this.TextureArray) {
                        int UnitWidth  = TextureUnit[0];
                        int UnitHeight = TextureUnit[1];
                        int UnitX      = TextureUnit[2];
                        int UnitY      = TextureUnit[3];

                        int PixelX     = (x * Texturewidth) + UnitX;
                        int PixelY     = (y * Texturewidth) + UnitY;
                        graphics.FillRectangle(ForeBrush,PixelX,PixelY,UnitWidth,UnitHeight);
                    }
                }
            }
            graphics.Dispose();
            return bitmap;
        }
    }
}
