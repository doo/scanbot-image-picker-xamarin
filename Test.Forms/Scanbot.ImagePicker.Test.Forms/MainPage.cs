using System;
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
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(85, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(15, GridUnitType.Star) },
                },
                Margin = new Thickness(10, 45, 10, 30)
            };

            Button = new Button();
            Button.BorderColor = Color.Gray;
            Button.BorderWidth = 2;
            Button.TextColor = Color.Gray;
            Button.Text = "PICK IMAGE";
            Button.Padding = new Thickness(10);
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

        /// <summary>
        /// Show result on the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnButtonClick(object sender, EventArgs e)
        {
            ImageSource source = await Scanbot.ImagePicker.Forms.ImagePicker.Instance.Pick();
            Image.Source = source;
        }
    }
}
