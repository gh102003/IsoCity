using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity.Tiles
{
    class TileDirt : Tile
    {
        public TileDirt(WorldPosition worldPosition) : base(worldPosition)
        {
            Name = "Dirt tile";

            TextureUri = new BitmapImage(new System.Uri("ms-appx:///Assets/Tiles/dirt.png"));
            height = 99;

            base.AddComponents();
        }
    }
}
