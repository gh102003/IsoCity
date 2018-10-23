using IsoCity.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace IsoCity.UI
{
    public sealed partial class ToolbarItem : Grid
    {
        public ToolbarItem(TileInfo tileInfo)
        {
            // TODO render tile and name

            this.InitializeComponent();
        }
    }
}
