using IsoCity.Tiles;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IsoCity
{
    public sealed partial class GamePage : Page
    {
        public GamePage()
        {
            WorldPosition worldSize = new WorldPosition(20, 20);

            World world = new World(worldSize);
            world.Randomise();

            // Create a new camera and add it to the screen, then set give it our keydown events
            Camera camera = new Camera(world);
            this.Content = camera;

            // Send KeyDown events to the camera
            Window.Current.CoreWindow.KeyDown += camera.Window_KeyDown;
        }
    }
}
