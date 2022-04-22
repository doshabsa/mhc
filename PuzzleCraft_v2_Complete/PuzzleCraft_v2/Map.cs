using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCraft_v2
{
    internal class Map
    {
        /* Credits can be found in FormManager.cs */
        public static List<Image> gameMaps = new List<Image>(2);

        private int _mapType;
        private double _width;
        private double _height;

        public int mapType { get { return _mapType; } }

        public double mapWidth { get { return _width; } }
        public double mapHeight { get { return _height; } }

        public Map(int fWidth, int fHeight, int rndMap)
        {
            //The input of this width and height will set the map boundary size
            _width = fWidth;
            _height = fHeight;
            _mapType = rndMap;
            Fetch();
        }

        public void Fetch()
        {
            if(gameMaps.Count != 0) //If Form 2 is closed, this will ensure the maps are purged
                gameMaps.Clear();
            switch (_mapType) //Could add better functionality in future to add more/automate better
            {
                case 0:
                    gameMaps.Add((Bitmap)Resource1.map_0);
                    gameMaps.Add((Bitmap)Resource1.map_3);
                    break;
                case 1:
                    gameMaps.Add((Bitmap)Resource1.map_1);
                    gameMaps.Add((Bitmap)Resource1.map_4);
                    break;
                case 2:
                    gameMaps.Add((Bitmap)Resource1.map_2);
                    gameMaps.Add((Bitmap)Resource1.map_5);
                    break;
            }
        }
    }
}
