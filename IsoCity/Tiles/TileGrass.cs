using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity.Tiles
{
    class TileGrass : Tile
    {
        public TileGrass(WorldPosition worldPosition) : base(worldPosition)
        {
            Name = "Grass tile";

            TextureUri = new BitmapImage(new System.Uri("ms-appx:///Assets/Tiles/grass.png"));
            height = 99;

            base.AddComponents();
        }
    }
}
