using System;
using ScanbotBarcodeSDK.Forms;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Test.Forms
{
    public class MainPage : ContentPage
    {
        StackLayout Container { get; set; }

        Button Button { get; set; }

        Image Image { get; set; }

        public MainPage()
        {
            Container = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            Button = new Button();
            Button.Text = "PICK IMAGE";
            Container.Children.Add(Button);

            Image = new Image();
            Container.Children.Add(Image);
            Content = Container;

            Button.Clicked += OnButtonClick;
        }

        async void OnButtonClick(object sender, EventArgs e)
        {
            ImageSource source = await Scanbot.ImagePicker.Forms.ImagePicker.Instance.Pick();

            SBSDK.Initialize(new InitializationOptions());
            var codes = await SBSDK.Operations.DetectBarcodesFrom(source);
            Image.Source = source;


        }
    }
}
