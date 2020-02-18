using System;
using UIKit;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms.iOS
{
    public static class Extensions
    {
        public static ImageSource ToImageSource(this UIImage image)
        {
            if (image == null)
            {
                return null;
            }
            return ImageSource.FromStream(image.AsPNG().AsStream);
        }

    }
}
