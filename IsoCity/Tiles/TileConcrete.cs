using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity.Tiles
{
    class TileConcrete : Tile
    {
        public TileConcrete(WorldPosition worldPosition) : base(worldPosition)
        {
            Name = "Empty tile";

            TextureUri = new BitmapImage(new System.Uri("ms-appx:///Assets/Tiles/concrete.png"));
            height = 99;

            base.AddComponents();
        }
    }
}
