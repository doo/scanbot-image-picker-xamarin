namespace Scanbot.ImagePicker.Droid.Utils
{
    public class Platform
    {
        public static Android.App.Application Context
        {
            get => (Android.App.Application)Android.App.Application.Context;
        }
    }
}
