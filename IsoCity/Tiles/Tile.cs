using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace IsoCity.Tiles
{
    class Tile : Canvas
    {
        public const int STANDARD_WIDTH = 149;
        public const int STANDARD_HEIGHT = 89;

        public WorldPosition WorldPosition { get; }

        public TileInfo tileInfo;

        public Tile(TileInfo tileInfo, WorldPosition worldPosition)
        {
            this.tileInfo = tileInfo;
            this.WorldPosition = worldPosition;

            AddComponents();
        }
        
        /// <summary>
        /// Adds the texture to the tile
        /// </summary>
        private void AddComponents()
        {
            // Create texture brush
            var textureBrush = new ImageBrush
            {
                ImageSource = tileInfo.TextureUri
            };

            // Create textured rectangle
            var texturedRect = new Rectangle
            {
                Fill = textureBrush,
                Width = tileInfo.width,
                Height = tileInfo.height
            };

            // Anchor texture to the bottom of the tile
            SetTop(texturedRect, STANDARD_HEIGHT - tileInfo.height);

            this.Children.Add(texturedRect);
        }
    }
}
