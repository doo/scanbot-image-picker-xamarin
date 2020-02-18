using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Forms
{
    public interface IImagePicker
    {
        Task<ImageSource> Pick();
    }
}
