using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity.Tiles
{
    class TileLawn : Tile
    {
        public TileLawn(WorldPosition worldPosition) : base(worldPosition)
        {
            Name = "Empty tile";

            TextureUri = new BitmapImage(new System.Uri("ms-appx:///Assets/Tiles/lawn.png"));
            height = 99;

            base.AddComponents();
        }
    }
}
