using System;
using System.IO;
using Android.Graphics;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms.Droid
{
    public static class Extensions
    {
        public static ImageSource ToImageSource(this Bitmap image)
        {
            if (image == null)
            {
                return null;
            }

            var ms = new MemoryStream();
            image.Compress(Bitmap.CompressFormat.Png, 80, ms);
            var bytes = ms.ToArray();
            return ImageSource.FromStream(() =>
            {
                return new MemoryStream(bytes, writable: false);
            });
        }

        public static ImageSource ToImageSource(this Stream stream)
        {
            if (stream == null)
            {
                return null;
            }
        
            return ImageSource.FromStream(() => stream );
        }
    }
}
