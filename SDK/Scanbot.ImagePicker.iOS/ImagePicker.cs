using System.Globalization;
using PhotosUI;
#pragma warning disable CA1416 // Validate platform compatibility
namespace Scanbot.ImagePicker.iOS
{
    public class ImagePicker : Foundation.NSObject, IPHPickerViewControllerDelegate
    {
        public static readonly ImagePicker Instance = new ImagePicker();

        TaskCompletionSource<UIImage> source;
        UIImagePickerController imagePickerViewController;
        PHPickerViewController phPickerViewController;

        public UIViewController RootViewController => UIApplication.SharedApplication.KeyWindow.RootViewController;

        //-----------------------------------------
        // Pick Images Async
        //-----------------------------------------
        public async Task<UIImage> PickImageAsync()
        {
            var systemVersion = Convert.ToDouble(UIDevice.CurrentDevice.SystemVersion, CultureInfo.InvariantCulture);
            if (systemVersion >= 14.0)
            {
                return await PickImageNew();
            }
            else
            {
                return await PickImageOld();
            }
        }

        #region Image Picker View Controller

        /// <summary>
        /// Method used below iOS 14
        /// </summary>
        /// <returns></returns>
        internal Task<UIImage> PickImageOld()
        {
            // Create and define UIImagePickerController
            imagePickerViewController = new UIImagePickerController();

            imagePickerViewController.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            // Set event handlers
            imagePickerViewController.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePickerViewController.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
           
            RootViewController.PresentViewController(imagePickerViewController, true, null);

            // Return Task object
            source = new TaskCompletionSource<UIImage>();
            return source.Task;
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;

            imagePickerViewController.DismissViewController(true, () =>
            {
                Task.Run(() =>
                {
                    if (image != null)
                    {
                        source.SetResult(image);
                    }
                    else
                    {
                        source.SetResult(null);
                    }
                });
            });
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            source.SetResult(null);
            imagePickerViewController.DismissViewController(true, null);
        }

        #endregion

        #region 

        internal Task<UIImage> PickImageNew()
        {

            var config = new PHPickerConfiguration();
            config.SelectionLimit = 1;
            config.Filter = PHPickerFilter.ImagesFilter;
            config.Selection = PHPickerConfigurationSelection.Default;
            phPickerViewController = new PHPickerViewController(config);
            phPickerViewController.Delegate = this;
            source = new TaskCompletionSource<UIImage>();
            RootViewController.PresentViewController(phPickerViewController, true, null);
            return source.Task;
        }

        void IPHPickerViewControllerDelegate.DidFinishPicking(PhotosUI.PHPickerViewController picker, PhotosUI.PHPickerResult[] results)
        {
            picker.DismissViewController(true, null);
            foreach (var result in results)
            {
                result.ItemProvider.LoadObject<UIImage>(ExtractImage);

            }
        }

        //-----------------------------------------------------
        // Extracts image.
        //-----------------------------------------------------
        private void ExtractImage(UIImage result, NSError error)
        {
            if (error == null)
            {
                source.SetResult(result);
            }
        }
        #endregion
    }
}
#pragma warning restore CA1416 // Validate platform compatibility