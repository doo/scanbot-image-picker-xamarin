using System;
using CoreGraphics;
using UIKit;

namespace ImagePicker.Test.iOS
{
    public class MainViewController : UIViewController
    {
        public MainView ContentView { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "IMAGE PICKER TEST";

            ContentView = new MainView();
            View = ContentView;

            ContentView.Button.TouchUpInside += async delegate
            {
                var image = await Scanbot.ImagePicker.iOS.ImagePicker.Instance.Pick();
                ContentView.Image.Image = image;
            };
        }
    }

    public class MainView : UIView
    {
        public UIButton Button { get; private set; }

        public UIImageView Image { get; private set; }

        public MainView()
        {
            //BackgroundColor = UIColor.White;

            Button = new UIButton();
            Button.SetTitle("PICK IMAGE", UIControlState.Normal);
            Button.Layer.BorderColor = UIColor.LightGray.CGColor;
            Button.Layer.BorderWidth = 1;
            AddSubview(Button);

            Image = new UIImageView();
            Image.Layer.BorderColor = UIColor.LightGray.CGColor;
            Image.Layer.BorderWidth = 1;
            AddSubview(Image);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            nfloat padding = 5;
            nfloat buttonH = 60;

            nfloat x = padding;
            nfloat y = padding;
            nfloat w = Frame.Width - 2 * padding;
            nfloat h = buttonH;

            Button.Frame = new CGRect(x, y, w, h);

            y += h + padding;
            h = Frame.Height / 2;

            Image.Frame = new CGRect(x, y, w, h);
        }

    }
}
