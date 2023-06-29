namespace Scanbot.ImagePicker.Maui.Test;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new TestImagePicker();
	}
}

