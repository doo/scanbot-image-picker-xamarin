using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Scanbot.ImagePicker.Droid.Utils;

namespace Scanbot.ImagePicker.Droid
{
    public class ImagePicker : IDisposable
    {
        public static readonly ImagePicker Instance = new ImagePicker();

        public async Task<Bitmap> Pick()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            var chooser = Intent.CreateChooser(intent, "Pick image");
            var result = await ActivityResultDispatcher.ReceiveProxyActivityResult(Platform.Context, chooser);

            if (result.Result == Result.Ok && result.Intent != null)
            {
                var uri = result.Intent.Data;
                var stream = Platform.Context.ContentResolver.OpenInputStream(uri);
                return BitmapFactory.DecodeStream(stream);
            }

            return null;
        }

        public void Dispose()
        {
            // TODO destroy any cached data it may contain
        }

    }
}
