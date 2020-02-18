
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms.iOS
{
    public class DependencyManager
    {
        public static void Register()
        {
            DependencyService.Register<IImagePicker, ImagePicker>();
        }
    }
}
