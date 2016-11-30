using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Views
{
    using CoreGraphics;

    using Foundation;

    using UIKit;

    public class CustomCell : UITableViewCell
    {
        private UILabel _nameLabel, _yearLabel;

        private UIImageView _imageView;

        public CustomCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            this._imageView = new UIImageView();

            this._nameLabel = new UILabel()
                                  {
                                      Font = UIFont.FromName("Cochin-BoldItalic", 22f),
                                      TextColor = UIColor.FromRGB(127, 51, 0),
                                  };
            this._yearLabel = new UILabel()
                                {
                                    Font = UIFont.FromName("AmericanTypewriter", 12f),
                                    TextColor = UIColor.FromRGB(38, 127, 0),
                                    TextAlignment = UITextAlignment.Center,
                                };

            this.ContentView.AddSubviews(new UIView[] {this._imageView, this._nameLabel, this._yearLabel});
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            this._imageView.Frame = new CGRect(this.ContentView.Bounds.Width - 60, 5, 33, 33);
            this._nameLabel.Frame = new CGRect(5, 5, this.ContentView.Bounds.Width - 60, 25);
            this._yearLabel.Frame = new CGRect(100, 25, 100, 20);
        }

        public void UpdateCell(string name, string year, string imageName)
        {
            this._imageView.Image = UIImage.FromFile(imageName);
            this._nameLabel.Text = name;
            this._yearLabel.Text = year;

            this.Accessory = UITableViewCellAccessory.DisclosureIndicator;
        }
    }
}
