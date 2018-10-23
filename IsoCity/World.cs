using IsoCity.Tiles;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace IsoCity
{
    struct WorldPosition
    {
        public int x;
        public int y;

        public WorldPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] ToScreenPos()
        {
            int screenX = (x + y) * (Tile.STANDARD_WIDTH - 1) / 2;
            int screenY = (y - x) * (Tile.STANDARD_HEIGHT - 1) / 2;

            return new int[] { screenX, screenY };
        }
    }

    class World : Canvas
    {
        // List of all TileInfos
        public static List<TileInfo> tileInfos = new List<TileInfo>();

        /// <summary>
        /// The tiles in the 2d array should not be changed, but they can be accessed and their methods can be called
        /// </summary>
        public Tile[,] Tiles { get; }

        public World(WorldPosition citySize)
        {
            if (tileInfos.Count < 1) SetupTiles();

            Tiles = new Tile[citySize.x, citySize.y];
        }

        public static void SetupTiles()
        {
            tileInfos.Add(new TileInfo("TileEmpty", new BitmapImage(new Uri("ms-appx:///Assets/Tiles/empty.png"))));
            tileInfos.Add(new TileInfo("TileDirt", new BitmapImage(new Uri("ms-appx:///Assets/Tiles/dirt.png")), height: 99));
            tileInfos.Add(new TileInfo("TileGrass", new BitmapImage(new Uri("ms-appx:///Assets/Tiles/grass.png")), height: 99));
            tileInfos.Add(new TileInfo("TileLawn", new BitmapImage(new Uri("ms-appx:///Assets/Tiles/lawn.png")), height: 99));
            tileInfos.Add(new TileInfo("TileConcrete", new BitmapImage(new Uri("ms-appx:///Assets/Tiles/lawn.png")), height: 99));
        }

        /// <summary>
        /// Sets the tile at a specific position in the world, deleting old tiles as necessary
        /// </summary>
        /// <param name="tile">the new tile</param>
        public void SetTile(Tile tile)
        {
            // Get the world position from the tile
            WorldPosition wp = tile.WorldPosition;

            // Set tile's z-index based on x and y position
            SetZIndex(tile, wp.y - wp.x);

            // Set tile's screen position relative to the world
            int[] screenPos = wp.ToScreenPos();
            SetLeft(tile, screenPos[0]);
            SetTop(tile, screenPos[1]);

            // Remove the old tile
            if (Tiles[wp.x, wp.y] != null)
            {
                Children.Remove(Tiles[wp.x, wp.y]);
            }

            // Set the new tile
            Tiles[wp.x, wp.y] = tile;
            Children.Add(tile);
        }

        /// <summary>
        /// Sets all tiles to a random one from the array tileClasses
        /// </summary>
        public void Randomise()
        {
            Random r = new Random();

            for (var x = 0; x < Tiles.GetLength(0); x++)
            {
                for (var y = 0; y < Tiles.GetLength(1); y++)
                {
                    TileInfo tileInfo = tileInfos[r.Next(tileInfos.Count)];
                    SetTile(new Tile(tileInfo, new WorldPosition(x, y)));
                }
            }
        }
    }
}
