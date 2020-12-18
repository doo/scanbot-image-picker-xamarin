using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Scanbot.ImagePicker.iOS
{
    public class ImagePicker : IDisposable
    {
        public static readonly ImagePicker Instance = new ImagePicker();

        TaskCompletionSource<UIImage> source;
        UIImagePickerController picker;

        public Task<UIImage> Pick()
        {
            // Create and define UIImagePickerController
            picker = new UIImagePickerController();
            
            // Set event handlers
            picker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            picker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(picker, true);

            // Return Task object
            source = new TaskCompletionSource<UIImage>();
            return source.Task;
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {
                source.SetResult(image);
            }
            else
            {
                source.SetResult(null);
            }
            picker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            source.SetResult(null);
            picker.DismissModalViewController(true);
        }
        public void Dispose()
        {
            // TODO destroy any cached data it may contain
        }
    }
}
