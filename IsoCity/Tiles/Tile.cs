using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace IsoCity.Tiles
{
    abstract class Tile : Canvas
    {
        public static readonly int STANDARD_WIDTH = 149;
        public static readonly int STANDARD_HEIGHT = 89;

        public WorldPosition WorldPosition { get; }

        public string TileName { get; protected set; }
        protected BitmapImage TextureUri { get; set; }
        protected int width = STANDARD_WIDTH;
        protected int height = STANDARD_HEIGHT;

        public Tile(WorldPosition worldPosition)
        {
            this.WorldPosition = worldPosition;
        }
        
        /// <summary>
        /// Adds the texture to the tile
        /// </summary>
        protected void AddComponents()
        {
            // Create texture brush
            var textureBrush = new ImageBrush
            {
                ImageSource = TextureUri
            };

            // Create textured rectangle
            var texturedRect = new Rectangle
            {
                Fill = textureBrush,
                Width = width,
                Height = height
            };

            // Anchor texture to the bottom of the tile
            SetTop(texturedRect, STANDARD_HEIGHT - height);

            this.Children.Add(texturedRect);
        }
    }
}
