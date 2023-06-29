namespace Scanbot.ImagePicker.Maui.Test
{
    public class TestImagePicker : ContentPage
    {
        Grid GridViewContainer { get; set; }

        Button Button { get; set; }

        Image Image { get; set; }

        public TestImagePicker()
        {
            GridViewContainer = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(8, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                },
                Margin = new Thickness(10, 45, 10, 30)
            };

            Button = new Button();
            Button.BorderColor = Colors.Gray;
            Button.BorderWidth = 2;
            Button.TextColor = Colors.Gray;
            Button.Text = "PICK IMAGE";
            Button.Padding = new Thickness(10);
            Button.BackgroundColor = Colors.Snow;
            Button.VerticalOptions = LayoutOptions.Center;
            Button.HorizontalOptions = LayoutOptions.Center;
            GridViewContainer.Add(Button, 0, 1);

            Image = new Image();
            Image.VerticalOptions = LayoutOptions.Center;
            Image.HorizontalOptions = LayoutOptions.Center;
            GridViewContainer.Add(Image, 0, 0);
            Image.Aspect = Aspect.AspectFit;


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
            ImageSource source = await new Scanbot.ImagePicker.Forms.ImagePicker().PickImageAsync();
            Image.Source = source;
        }
    }
}
