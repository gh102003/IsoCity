﻿using IsoCity.Tiles;
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
    public sealed partial class Toolbar : Grid
    {
        private int length = 8;

        public Toolbar()
        {
            this.InitializeComponent();

            for (var i = 0; i < length; i++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());

                ToolbarItem item;
                try
                {
                    item = new ToolbarItem(World.tileInfos[i]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    item = new ToolbarItem(null);
                }
                this.Children.Add(item);
                Grid.SetColumn(item, i);
            }
        }
    }
}
