namespace Scanbot.ImagePicker.Forms
{
    public interface IImagePicker
    {
        Task<ImageSource> PickImageAsync();
    }
}
