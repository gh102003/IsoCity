using IsoCity.UI;
using System.Diagnostics;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;

namespace IsoCity
{
    sealed partial class Camera : Grid
    {
        private const int KEYBOARD_CAMERA_SPEED = 8;
        private const double MOUSE_CAMERA_SPEED = 0.9;

        private World world;
        private PointerPoint draggingCameraFrom = null;

        public Camera(World world)
        {
            this.InitializeComponent();

            this.world = world;
            CameraCanvas.Children.Add(world);

            var toolbar = new Toolbar
            {
                Name = "Toolbar"
            };
            Grid.SetRow(toolbar, 1);
            this.Children.Add(toolbar);

        }

        public void Window_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                case VirtualKey.W:
                    Canvas.SetTop(world, Canvas.GetTop(world) + KEYBOARD_CAMERA_SPEED);
                    break;

                case VirtualKey.Down:
                case VirtualKey.S:
                    Canvas.SetTop(world, Canvas.GetTop(world) - KEYBOARD_CAMERA_SPEED);
                    break;

                case VirtualKey.Left:
                case VirtualKey.A:
                    Canvas.SetLeft(world, Canvas.GetLeft(world) + KEYBOARD_CAMERA_SPEED);
                    break;

                case VirtualKey.Right:
                case VirtualKey.D:
                    Canvas.SetLeft(world, Canvas.GetLeft(world) - KEYBOARD_CAMERA_SPEED);
                    break;
            }
        }

        public void Window_PointerPressed(CoreWindow sender, PointerEventArgs args)
        {
            // Store the current point, to be used in drag calculations
            draggingCameraFrom = args.CurrentPoint;
        }

        public void Window_PointerReleased(CoreWindow sender, PointerEventArgs args)
        {
            // Delete the drag point
            draggingCameraFrom = null;
        }

        public void Window_PointerMoved(CoreWindow sender, PointerEventArgs args)
        {
            if (args.CurrentPoint.IsInContact && args.CurrentPoint.Properties.IsRightButtonPressed)
            {
                // Find delta between drag point and current point
                double deltaX = args.CurrentPoint.Position.X - draggingCameraFrom.Position.X;
                double deltaY = args.CurrentPoint.Position.Y - draggingCameraFrom.Position.Y;

                // Move the camera based on the delta and the camera speed
                Canvas.SetLeft(world, Canvas.GetLeft(world) + deltaX * MOUSE_CAMERA_SPEED);
                Canvas.SetTop(world, Canvas.GetTop(world) + deltaY * MOUSE_CAMERA_SPEED);

                // Overwrite draggingCameraFrom, since we have already accounted for this bit of the drag
                draggingCameraFrom = args.CurrentPoint;
            }
        }
    }
}
