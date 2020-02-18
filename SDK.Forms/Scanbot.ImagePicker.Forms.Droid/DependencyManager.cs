using System;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms.Droid
{
    public class DependencyManager
    {
        public static void Register()
        {
            DependencyService.Register<IImagePicker, ImagePicker>();
        }
    }
}
