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

            // Send KeyDown and mouse events to the camera
            Window.Current.CoreWindow.KeyDown += camera.Window_KeyDown;
            Window.Current.CoreWindow.PointerMoved += camera.Window_PointerMoved;
            Window.Current.CoreWindow.PointerPressed += camera.Window_PointerPressed;
            Window.Current.CoreWindow.PointerReleased += camera.Window_PointerReleased;
        }
    }
}
