using System;
using System.Diagnostics;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace IsoCity
{
    sealed partial class Camera : Grid
    {
        private static readonly int CAMERA_SPEED = 8;

        private World world;

        public Camera(World world)
        {
            this.InitializeComponent();

            this.world = world;
            CameraCanvas.Children.Add(world);
        }

        public void Window_KeyDown(CoreWindow sender, KeyEventArgs e)
        {
            Debug.WriteLine("Keypress");

            switch (e.VirtualKey)
            {
                case VirtualKey.Up:
                case VirtualKey.W:
                    world.SetValue(Canvas.TopProperty, (double)world.GetValue(Canvas.TopProperty) + CAMERA_SPEED);
                    break;

                case VirtualKey.Down:
                case VirtualKey.S:
                    world.SetValue(Canvas.TopProperty, (double)world.GetValue(Canvas.TopProperty) - CAMERA_SPEED);
                    break;

                case VirtualKey.Left:
                case VirtualKey.A:
                    world.SetValue(Canvas.LeftProperty, (double)world.GetValue(Canvas.LeftProperty) + CAMERA_SPEED);
                    break;

                case VirtualKey.Right:
                case VirtualKey.D:
                    world.SetValue(Canvas.LeftProperty, (double)world.GetValue(Canvas.LeftProperty) - CAMERA_SPEED);
                    break;
            }
        }
    }
}
