using System;
using ScanbotBarcodeSDK.Forms;
using Xamarin.Forms;

namespace Scanbot.ImagePicker.Test.Forms
{
    public class MainPage : ContentPage
    {
        Grid GridViewContainer { get; set; }

        Button Button { get; set; }

        Image Image { get; set; }

        public MainPage()
        {
            GridViewContainer = new Grid
            {
                BackgroundColor = Color.SkyBlue,
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                }
            };



            Button = new Button();
            Button.Text = "PICK IMAGE";
            Button.TextColor = Color.Red;
            Button.BackgroundColor = Color.Snow;
            Button.VerticalOptions = LayoutOptions.Center;
            Button.HorizontalOptions = LayoutOptions.Center;
            GridViewContainer.Children.Add(Button, 0, 1);

            Image = new Image();
            Image.VerticalOptions = LayoutOptions.CenterAndExpand;
            Image.HorizontalOptions = LayoutOptions.CenterAndExpand;
            GridViewContainer.Children.Add(Image, 0, 0);


            Content = GridViewContainer;

            Button.Clicked += OnButtonClick;
        }

        async void OnButtonClick(object sender, EventArgs e)
        {
            ImageSource source = await Scanbot.ImagePicker.Forms.ImagePicker.Instance.Pick();

            //SBSDK.Initialize(new InitializationOptions());
            //var codes = await SBSDK.Operations.DetectBarcodesFrom(source);
            Image.Source = source;


        }
    }
}
