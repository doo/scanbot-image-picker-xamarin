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
            var stream = await Scanbot.ImagePicker.Droid.ImagePicker.Instance.GetResultStream();
            return stream.ToImageSource();
        }
    }
}
