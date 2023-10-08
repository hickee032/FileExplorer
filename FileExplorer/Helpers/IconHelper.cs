﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FileExplorer.Helpers
{
    public static class IconHelper
    {
        #region DLL
        [DllImport("gdi32.dll", SetLastError =true)]
        private static extern bool DeleteObject(IntPtr obj);

        public static ImageSource ToImageSource(this Icon ico) {

            Bitmap bitmap = ico.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();

            ImageSource image = Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }

        #endregion

    }
}