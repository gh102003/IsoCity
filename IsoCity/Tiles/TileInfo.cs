using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity.Tiles
{
    public class TileInfo
    {
        public string Name { get; protected set; }
        public BitmapImage TextureUri { get; set; }
        public int width = Tile.STANDARD_WIDTH;
        public int height = Tile.STANDARD_HEIGHT;

        public TileInfo(string name, BitmapImage textureUri, int width = Tile.STANDARD_WIDTH, int height = Tile.STANDARD_HEIGHT)
        {
            this.Name = name;
            this.TextureUri = textureUri;
            this.width = width;
            this.height = height;
        }
    }
}
