using IsoCity.Tiles;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace IsoCity.UI
{
    public sealed partial class ToolbarItem : Grid
    {
        public ToolbarItem(TileInfo tileInfo)
        {
            this.InitializeComponent();

            if (tileInfo != null)
            {
                // Create texture brush
                var textureBrush = new ImageBrush
                {
                    ImageSource = tileInfo.TextureUri
                };
                Icon.Width = tileInfo.width;
                Icon.Height = tileInfo.height;
                Icon.Fill = textureBrush;

                Label.Text = tileInfo.Name;
            }
        }
    }
}
