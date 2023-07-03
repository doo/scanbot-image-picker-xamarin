namespace Scanbot.ImagePicker.Maui.Test;

public class HomePage : ContentPage
{
    Grid GridViewContainer { get; set; }

    Button btnPickImage { get; set; }

    Image imageView { get; set; }

    public HomePage()
    {
        GridViewContainer = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(100) },
            },
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill
        };

        btnPickImage = new Button();
        btnPickImage.BorderColor = Colors.Gray;
        btnPickImage.BorderWidth = 2;
        btnPickImage.TextColor = Colors.Gray;
        btnPickImage.Text = "PICK IMAGE";
        btnPickImage.Padding = new Thickness(10);
        btnPickImage.BackgroundColor = Colors.Snow;
        btnPickImage.VerticalOptions = LayoutOptions.Center;
        btnPickImage.HorizontalOptions = LayoutOptions.Center;

        imageView = new Image();
        imageView.VerticalOptions = LayoutOptions.Fill;
        imageView.HorizontalOptions = LayoutOptions.Fill;
        imageView.Aspect = Aspect.AspectFit;

        GridViewContainer.Add(imageView, 0, 0);
        GridViewContainer.Add(btnPickImage, 0, 1);
        Content = GridViewContainer;
        btnPickImage.Clicked += OnButtonClick;
    }

    /// <summary>
    /// Show result on the screen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void OnButtonClick(object sender, EventArgs e)
    {
        ImageSource source = await new Scanbot.ImagePicker.Forms.ImagePicker().PickImageAsync();
        await MainThread.InvokeOnMainThreadAsync(() => imageView.Source = source);
    }
}
