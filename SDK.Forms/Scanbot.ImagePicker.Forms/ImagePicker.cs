using System;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms
{
    public class ImagePicker
    {
        /// <summary>
        /// Singleton implementation of the image picker launcher
        /// </summary>
        public static IImagePicker Instance => DependencyService.Get<IImagePicker>();
    }
}
