
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms.iOS
{
    public class ImagePicker : IImagePicker
    {
        public async Task<ImageSource> Pick()
        {
            var image = await Scanbot.ImagePicker.iOS.ImagePicker.Instance.Pick();
            return image.ToImageSource();
        }
    }
}
