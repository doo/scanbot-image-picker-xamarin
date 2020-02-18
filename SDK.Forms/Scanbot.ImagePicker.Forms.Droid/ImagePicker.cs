using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Scanbot.ImagePicker.Forms.Droid.ImagePicker))]
namespace Scanbot.ImagePicker.Forms.Droid
{
    public class ImagePicker : IImagePicker
    {
        public async Task<ImageSource> Pick()
        {
            var bitmap = await Scanbot.ImagePicker.Droid.ImagePicker.Instance.Pick();
            // TODO Do not use native implementation of Stream -> Bitmap here,
            // as Bitmap -> Imagesource conversion is super ineffective
            return bitmap.ToImageSource();
        }
    }
}
