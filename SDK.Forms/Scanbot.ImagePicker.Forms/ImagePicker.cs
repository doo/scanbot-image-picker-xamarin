#if IOS
using Scanbot.ImagePicker.Forms.iOS;
#elif ANDROID
using Scanbot.ImagePicker.Forms.Droid;
#endif

namespace Scanbot.ImagePicker.Forms;

public class ImagePicker : IImagePicker
{
    /// <summary>
    /// Pick Images from photos gallery app.
    /// </summary>
    /// <returns></returns>
    public async Task<ImageSource> PickImageAsync()
    {
#if IOS
#pragma warning disable CA1416 // Validate platform compatibility
        var image = await Scanbot.ImagePicker.iOS.ImagePicker.Instance.PickImageAsync();
#pragma warning restore CA1416 // Validate platform compatibility
        return image.ToImageSource();

#elif ANDROID
        var stream = await Scanbot.ImagePicker.Droid.ImagePicker.Instance.PickImageAsync();
            return stream.ToImageSource();
#endif
        return null;
    }
}
