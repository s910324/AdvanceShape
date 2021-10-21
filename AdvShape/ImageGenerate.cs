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
		static public Dictionary<int,Texture> TextureDict = new Dictionary<int,Texture>{
			{1, new Texture(8*2, 8*2,  false, new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 4*2, 4*2}})},

			{2, new Texture(6*2,3*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 },new int[]{1*2,1*2,3*2,2*2}})},

			{3, new Texture(4*2,4*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 },new int[]{1*2,1*2,2*2,2*2}})},

			{4, new Texture(4*2, (int)2.5*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 },new int[]{1*2,1*2,2*2,1*2}})},

			{5, new Texture(4*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2},
				new int[]{1*2, 1*2, 1*2, 1*2}, new int[]{1*2, 1*2, 0*2, 2*2},
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}})},

			{6, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2}, 
				new int[]{1*2, 1*2, 4*2, 0*2}, new int[]{1*2, 1*2, 6*2, 0*2}, 
				new int[]{1*2, 1*2, 1*2, 1*2}, new int[]{1*2, 1*2, 3*2, 1*2}, 
				new int[]{1*2, 1*2, 5*2, 1*2}, new int[]{1*2, 1*2, 7*2, 1*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 2*2, 2*2},
				new int[]{1*2, 1*2, 4*2, 2*2}, new int[]{1*2, 1*2, 1*2, 3*2}, 
				new int[]{1*2, 1*2, 3*2, 3*2}, new int[]{1*2, 1*2, 5*2, 3*2}, 
				new int[]{1*2, 1*2, 7*2, 3*2}, new int[]{1*2, 1*2, 0*2, 4*2}, 
				new int[]{1*2, 1*2, 2*2, 4*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 6*2, 4*2}, new int[]{1*2, 1*2, 1*2, 5*2},
				new int[]{1*2, 1*2, 3*2, 5*2}, new int[]{1*2, 1*2, 5*2, 5*2}, 
				new int[]{1*2, 1*2, 7*2, 5*2}, new int[]{1*2, 1*2, 0*2, 6*2}, 
				new int[]{1*2, 1*2, 4*2, 6*2}, new int[]{1*2, 1*2, 6*2, 6*2}, 
				new int[]{1*2, 1*2, 1*2, 7*2}, new int[]{1*2, 1*2, 3*2, 7*2}, 
				new int[]{1*2, 1*2, 5*2, 7*2}, new int[]{1*2, 1*2, 7*2, 7*2}})},

			{7, new Texture(2*2,2*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,1*2,1*2}})},

			{8, new Texture(4*2,4*2,true,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2}, 
				new int[]{1*2, 1*2, 1*2, 1*2}, new int[]{1*2, 1*2, 0*2, 2*2}, 
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}})},

			{9, new Texture(4*2, (int)2.5*2,true,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,2*2,1*2}})},

			{10, new Texture(4*2,4*2,true,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,2*2,2*2}})},

			{11, new Texture(6*2,3*2,true,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,3*2,2*2}})},

			{12, new Texture(8*2,8*2,true,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,4*2,4*2}})},

			{13, new Texture(4*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 1*2},
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}})},

			{14, new Texture(4*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{1*2, 1*2, 2*2, 1*2}, 
				new int[]{1*2, 1*2, 1*2, 2*2}, new int[]{1*2, 1*2, 0*2, 3*2}})},

			{15, new Texture(4*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 0*2}, 
				new int[]{1*2, 1*2, 1*2, 1*2}, new int[]{1*2, 1*2, 2*2, 1*2}, 
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 2*2}, 
				new int[]{1*2, 1*2, 3*2, 3*2}, new int[]{1*2, 1*2, 0*2, 3*2}})},

			{16, new Texture(4*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2}, 
				new int[]{1*2, 1*2, 2*2, 1*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 1*2, 2*2}, new int[]{1*2, 1*2, 0*2, 2*2}, 
				new int[]{1*2, 1*2, 0*2, 3*2}, new int[]{1*2, 1*2, 3*2, 3*2}})},

			{17, new Texture(6*2,6*2,false,new int[][]{
				new int[]{1*2, 1*2, 1*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2}, 
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{1*2, 1*2, 2*2, 1*2}, 
				new int[]{1*2, 1*2, 3*2, 1*2}, new int[]{1*2, 1*2, 4*2, 1*2}, 
				new int[]{1*2, 1*2, 3*2, 2*2}, new int[]{1*2, 1*2, 4*2, 2*2}, 
				new int[]{1*2, 1*2, 5*2, 2*2}, new int[]{1*2, 1*2, 0*2, 3*2},
				new int[]{1*2, 1*2, 4*2, 3*2}, new int[]{1*2, 1*2, 5*2, 3*2}, 
				new int[]{1*2, 1*2, 0*2, 4*2}, new int[]{1*2, 1*2, 1*2, 4*2}, 
				new int[]{1*2, 1*2, 5*2, 4*2}, new int[]{1*2, 1*2, 0*2, 5*2}, 
				new int[]{1*2, 1*2, 1*2, 5*2}, new int[]{1*2, 1*2, 2*2, 5*2}})},

			{18, new Texture(6*2,6*2,false,new int[][]{
				new int[]{1*2, 1*2, 2*2, 0*2}, new int[]{1*2, 1*2, 3*2, 0*2}, 
				new int[]{1*2, 1*2, 4*2, 0*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 2*2, 1*2}, new int[]{1*2, 1*2, 3*2, 1*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 1*2, 2*2}, 
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 0*2, 3*2},
				new int[]{1*2, 1*2, 1*2, 3*2}, new int[]{1*2, 1*2, 5*2, 3*2}, 
				new int[]{1*2, 1*2, 0*2, 4*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 5*2, 4*2}, new int[]{1*2, 1*2, 3*2, 5*2}, 
				new int[]{1*2, 1*2, 4*2, 5*2}, new int[]{1*2, 1*2, 5*2, 5*2}})},

			{19, new Texture(6*2,1*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2}})},

			{20, new Texture(1*2,6*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2}})},

			{21, new Texture(1*2,4*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,0*2,1*2}})},

			{22, new Texture(4*2,1*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 },new int[]{1*2,1*2,1*2,0*2}})},

			{23, new Texture(4*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}})},

			{24, new Texture(4*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{1*2, 1*2, 2*2, 1*2}, 
				new int[]{1*2, 1*2, 1*2, 2*2}, new int[]{1*2, 1*2, 0*2, 3*2}})},

			{25, new Texture(8*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}, 
				new int[]{1*2, 1*2, 4*2, 3*2}, new int[]{1*2, 1*2, 5*2, 2*2}, 
				new int[]{1*2, 1*2, 6*2, 1*2}, new int[]{1*2, 1*2, 7*2, 0*2}})},

			{26, new Texture(7*2,4*2,false,new int[][]{
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{1*2, 1*2, 4*2, 0*2}, 
				new int[]{1*2, 1*2, 2*2, 1*2}, new int[]{1*2, 1*2, 5*2, 1*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 1*2, 2*2}})},

			{27, new Texture(4*2,1*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,2*2,0*2}})},

			{28, new Texture(1*2,4*2,false,new int[][]{
				new int[]{1*2,1*2,0*2,0*2 }, new int[]{1*2,1*2,0*2,2*2}})},

			{29, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 0*2}, 
				new int[]{1*2, 1*2, 2*2, 0*2}, new int[]{1*2, 1*2, 3*2, 0*2}, 
				new int[]{1*2, 1*2, 4*2, 4*2}, new int[]{1*2, 1*2, 5*2, 4*2}, 
				new int[]{1*2, 1*2, 6*2, 4*2}, new int[]{1*2, 1*2, 7*2, 4*2}})},

			{30, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 0*2, 1*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 0*2, 3*2}, 
				new int[]{1*2, 1*2, 4*2, 4*2}, new int[]{1*2, 1*2, 4*2, 5*2}, 
				new int[]{1*2, 1*2, 4*2, 6*2}, new int[]{1*2, 1*2, 4*2, 7*2}})},

			{31, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 4*2, 1*2}, 
				new int[]{1*2, 1*2, 1*2, 2*2}, new int[]{1*2, 1*2, 6*2, 3*2}, 
				new int[]{1*2, 1*2, 3*2, 4*2}, new int[]{1*2, 1*2, 7*2, 5*2}, 
				new int[]{1*2, 1*2, 2*2, 6*2}, new int[]{1*2, 1*2, 5*2, 7*2}})},

			{32, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 0*2}, 
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{1*2, 1*2, 4*2, 0*2}, 
				new int[]{1*2, 1*2, 0*2, 1*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 4*2, 2*2}, new int[]{1*2, 1*2, 5*2, 2*2}, 
				new int[]{1*2, 1*2, 0*2, 3*2}, new int[]{1*2, 1*2, 4*2, 3*2},
				new int[]{1*2, 1*2, 5*2, 3*2}, new int[]{1*2, 1*2, 7*2, 3*2}, 
				new int[]{1*2, 1*2, 0*2, 4*2}, new int[]{1*2, 1*2, 2*2, 4*2}, 
				new int[]{1*2, 1*2, 3*2, 4*2}, new int[]{1*2, 1*2, 7*2, 4*2}, 
				new int[]{1*2, 1*2, 2*2, 5*2}, new int[]{1*2, 1*2, 3*2, 5*2}, 
				new int[]{1*2, 1*2, 6*2, 6*2}, new int[]{1*2, 1*2, 7*2, 6*2},
				new int[]{1*2, 1*2, 3*2, 7*2}, new int[]{1*2, 1*2, 4*2, 7*2}, 
				new int[]{1*2, 1*2, 6*2, 7*2}, new int[]{1*2, 1*2, 7*2, 7*2}})},

			{33, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 7*2, 0*2}, new int[]{1*2, 1*2, 6*2, 1*2}, 
				new int[]{1*2, 1*2, 5*2, 2*2}, new int[]{1*2, 1*2, 4*2, 3*2}, 
				new int[]{1*2, 1*2, 3*2, 4*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 2*2, 5*2}, new int[]{1*2, 1*2, 5*2, 5*2}, 
				new int[]{1*2, 1*2, 1*2, 6*2}, new int[]{1*2, 1*2, 6*2, 6*2},
				new int[]{1*2, 1*2, 0*2, 7*2}, new int[]{1*2, 1*2, 7*2, 7*2}})},

			{34, new Texture(8*2,8*2,false,new int[][]{
				new int[]{8*2, 1*2, 0*2, 0*2}, new int[]{1*2, 5*2, 0*2, 0*2}, 
				new int[]{8*2, 1*2, 0*2, 4*2}, new int[]{1*2, 5*2, 4*2, 4*2}})},

			{35, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 4*2, 0*2}, 
				new int[]{1*2, 1*2, 1*2, 1*2}, new int[]{1*2, 1*2, 3*2, 1*2}, 
				new int[]{1*2, 1*2, 5*2, 1*2}, new int[]{1*2, 1*2, 2*2, 2*2}, 
				new int[]{1*2, 1*2, 6*2, 2*2}, new int[]{1*2, 1*2, 1*2, 3*2}, 
				new int[]{1*2, 1*2, 5*2, 3*2}, new int[]{1*2, 1*2, 7*2, 3*2},
				new int[]{1*2, 1*2, 0*2, 4*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 3*2, 5*2}, new int[]{1*2, 1*2, 5*2, 5*2}, 
				new int[]{1*2, 1*2, 2*2, 6*2}, new int[]{1*2, 1*2, 6*2, 6*2}, 
				new int[]{1*2, 1*2, 1*2, 7*2}, new int[]{1*2, 1*2, 3*2, 7*2},
				new int[]{1*2, 1*2, 7*2, 7*2}})},

			{36, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2}, 
				new int[]{1*2, 1*2, 4*2, 0*2}, new int[]{1*2, 1*2, 6*2, 0*2}, 
				new int[]{1*2, 1*2, 1*2, 1*2}, new int[]{1*2, 1*2, 3*2, 1*2}, 
				new int[]{1*2, 1*2, 5*2, 1*2}, new int[]{1*2, 1*2, 7*2, 1*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 2*2, 2*2},
				new int[]{1*2, 1*2, 4*2, 2*2}, new int[]{1*2, 1*2, 6*2, 2*2}, 
				new int[]{1*2, 1*2, 1*2, 3*2}, new int[]{1*2, 1*2, 3*2, 3*2}, 
				new int[]{1*2, 1*2, 5*2, 3*2}, new int[]{1*2, 1*2, 7*2, 3*2}, 
				new int[]{4*2, 4*2, 0*2, 4*2}})},

			{37, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 5*2, 5*2}, new int[]{1*2, 1*2, 4*2, 6*2}})},

			{38, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 2*2, 0*2}, 
				new int[]{1*2, 1*2, 4*2, 0*2}, new int[]{1*2, 1*2, 6*2, 0*2}, 
				new int[]{1*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 0*2, 4*2}, 
				new int[]{1*2, 1*2, 0*2, 6*2}})},

			{39, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 2*2, 2*2}, 
				new int[]{1*2, 1*2, 6*2, 2*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 2*2, 6*2}, new int[]{1*2, 1*2, 6*2, 6*2}})},

			{40, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 6*2, 0*2}, new int[]{1*2, 1*2, 7*2, 0*2}, 
				new int[]{1*2, 1*2, 0*2, 1*2}, new int[]{1*2, 1*2, 5*2, 1*2}, 
				new int[]{1*2, 1*2, 1*2, 2*2}, new int[]{1*2, 1*2, 4*2, 2*2}, 
				new int[]{1*2, 1*2, 2*2, 3*2}, new int[]{1*2, 1*2, 3*2, 3*2}, 
				new int[]{1*2, 1*2, 4*2, 4*2}, new int[]{1*2, 1*2, 5*2, 4*2},
				new int[]{1*2, 1*2, 6*2, 5*2}, new int[]{1*2, 1*2, 7*2, 6*2}, 
				new int[]{1*2, 1*2, 7*2, 7*2}})},

			{41, new Texture(8*2,8*2,false,new int[][]{
				new int[]{3*2, 1*2, 1*2, 0*2}, new int[]{3*2, 1*2, 5*2, 0*2}, 
				new int[]{1*2, 3*2, 0*2, 1*2}, new int[]{1*2, 3*2, 4*2, 1*2}, 
				new int[]{1*2, 3*2, 7*2, 1*2}, new int[]{3*2, 3*2, 5*2, 2*2}, 
				new int[]{3*2, 1*2, 1*2, 4*2}, new int[]{3*2, 1*2, 5*2, 4*2}, 
				new int[]{1*2, 3*2, 0*2, 5*2}, new int[]{2*2, 3*2, 3*2, 5*2},
				new int[]{3*2, 3*2, 1*2, 6*2}})},

			{42, new Texture(4*2,4*2,false,new int[][]{
				new int[]{4*2, 1*2, 0*2, 0*2}, new int[]{2*2, 1*2, 1*2, 1*2}, 
				new int[]{4*2, 1*2, 0*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}, 
				new int[]{1*2, 1*2, 0*2, 3*2}})},

			{43, new Texture(4*2,4*2,false,new int[][]{
				new int[]{4*2,1*2,0*2,0*2 }, new int[]{1*2,4*2,0*2,0*2}})},

			{44, new Texture(8*2,8*2,false,new int[][]{
				new int[]{8*2,1*2,0*2,0*2 }, new int[]{1*2,8*2,0*2,0*2}})},

			{45, new Texture(4*2,4*2,false,new int[][]{
				new int[]{2*2,2*2,0*2,0*2 }, new int[]{2*2,2*2,2*2,2*2}})},

			{46, new Texture(8*2,8*2,false,new int[][]{
				new int[]{4*2,4*2,0*2,0*2 }, new int[]{4*2,4*2,4*2,4*2}})},

			{47, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 0*2, 0*2}, new int[]{1*2, 1*2, 1*2, 1*2}, 
				new int[]{1*2, 1*2, 2*2, 2*2}, new int[]{1*2, 1*2, 3*2, 3*2}, 
				new int[]{1*2, 1*2, 4*2, 4*2}, new int[]{1*2, 1*2, 5*2, 5*2}, 
				new int[]{1*2, 1*2, 6*2, 6*2}, new int[]{1*2, 1*2, 7*2, 7*2}, 
				new int[]{1*2, 1*2, 7*2, 1*2}, new int[]{1*2, 1*2, 6*2, 2*2},
				new int[]{1*2, 1*2, 5*2, 3*2}, new int[]{1*2, 1*2, 4*2, 4*2}, 
				new int[]{1*2, 1*2, 3*2, 5*2}, new int[]{1*2, 1*2, 2*2, 6*2}, 
				new int[]{1*2, 1*2, 1*2, 7*2}})},

			{48, new Texture(8*2,8*2,false,new int[][]{
				new int[]{1*2, 1*2, 3*2, 0*2}, new int[]{3*2, 1*2, 2*2, 1*2}, 
				new int[]{5*2, 1*2, 1*2, 2*2}, new int[]{7*2, 1*2, 0*2, 3*2}, 
				new int[]{5*2, 1*2, 1*2, 4*2}, new int[]{3*2, 1*2, 2*2, 5*2}, 
				new int[]{1*2, 1*2, 3*2, 6*2}})}
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
            int ImageWidth, int ImageHeight, int BorderWidth,
            Color ForColor, Color BackColor, Color BorderColor) {

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
            
            for(var x = 0; x < (int)(ImageWidth / this.Texturewidth); x++) {
                for(var y = 0;y < (int)(ImageHeight / this.TextureHeight);y++) {
                    foreach(int[] TextureUnit in this.TextureArray) {
                        int UnitWidth  = TextureUnit[0];
                        int UnitHeight = TextureUnit[1];
                        int UnitX      = TextureUnit[2];
                        int UnitY      = TextureUnit[3];

                        int PixelX     = (x*Texturewidth) + UnitX;
                        int PixelY     = (y*Texturewidth) + UnitY;
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
    }
}
