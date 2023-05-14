using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGame
{
    class MapController
    {
        public const int mapWidth = 20;
        public const int mapHeight = 30;
        //Pens & Brushes
        public Pen bp = new Pen(Color.DarkMagenta, 4);
        //Image
        public Image arcanoid;
        //Map
        public int[,] map = new int[mapHeight, mapWidth];

        public MapController() 
        {
            arcanoid = new Bitmap("C:\\Users\\user\\source\\repos\\WinFormsGame\\WinFormsGame\\Image\\arcanoid.png");
        }

        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < MapController.mapHeight; i++)
            {
                for (int j = 0; j < MapController.mapWidth; j++)
                {
                    if (map[i, j] == 9)
                    {
                        //Choose plat pixels
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(60, 20)), 398, 17, 150, 50, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 8)
                    {
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(20, 20)), 806, 548, 73, 73, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16, 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(arcanoid, new Rectangle(new Point(j * 20, i * 20), new Size(40, 20)), 20, 16 + 77 * (map[i, j] - 1), 170, 59, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public void DrawArea(Graphics g)
        {
            g.DrawRectangle(bp, new Rectangle(0, 0, MapController.mapWidth * 20, MapController.mapHeight * 20));
        }

        public void AddLineBricks()
        {
            for (int i = mapHeight - 2; i > 0; i--)
            {
                for (int j = 0; j < mapWidth; j += 2)
                {
                    map[i, j] = map[i - 1, j];
                }
            }
            Random r = new Random();
            for (int j = 0; j < mapWidth; j += 2)
            {
                int currBrick = r.Next(1, 5);
                map[0, j] = currBrick;
                map[0, j + 1] = currBrick + currBrick * 10;
            }
        }

    }

}
