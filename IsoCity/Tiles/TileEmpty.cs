using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity.Tiles
{
    class TileEmpty : Tile
    {
        public TileEmpty(WorldPosition worldPosition) : base(worldPosition)
        {
            Name = "Empty tile";

            TextureUri = new BitmapImage(new System.Uri("ms-appx:///Assets/Tiles/empty.png"));

            base.AddComponents();
        }
    }
}
