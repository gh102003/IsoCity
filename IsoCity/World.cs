using IsoCity.Tiles;
using System;
using Windows.UI.Xaml.Controls;

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
            int screenX = (x + y) * (Tile.STANDARD_WIDTH - 1 ) / 2;
            int screenY = (y - x) * (Tile.STANDARD_HEIGHT - 1 ) / 2;

            return new int[] { screenX, screenY };
        }
    }

    class World : Canvas
    {
        private static readonly Type[] tileClasses = new Type[] { typeof(TileEmpty), typeof(TileDirt) , typeof(TileGrass), typeof(TileLawn), typeof(TileConcrete) };

        /// <summary>
        /// The tiles in the 2d array should not be changed, but they can be accessed and their methods can be called
        /// </summary>
        public Tile[,] Tiles { get; }

        public World(WorldPosition citySize)
        {
            Tiles = new Tile[citySize.x, citySize.y];
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
            // TODO position relative to World
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
                    Type tileClass = tileClasses[r.Next(tileClasses.Length)];
                    object[] tileParameters = new object[] { new WorldPosition(x, y) };
                    SetTile(Activator.CreateInstance(tileClass, tileParameters) as Tile);
                }
            }
        }
    }
}
