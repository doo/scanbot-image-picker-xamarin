using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace ImagePicker.Test.Droid
{
    [Activity(Label = "ImagePicker.Test", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Button button;
        ImageView image;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            button = FindViewById<Button>(Resource.Id.myButton);
            image = FindViewById<ImageView>(Resource.Id.myImage);

            button.Click += OnButtonPress;
        
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            button.Click -= OnButtonPress;
        }

        async void OnButtonPress(object sender, EventArgs e)
        {
            var bitmap = await Scanbot.ImagePicker.Droid.ImagePicker.Instance.Pick();
            image.SetImageBitmap(bitmap);
        }
    }
}

