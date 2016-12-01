using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Views
{
    using CoreGraphics;

    using Foundation;

    using UIKit;

    public class CustomCollectionCell : UICollectionViewCell
    {
        private UILabel _nameLabel;

        private UIImageView _imageView;

        [Export("initWithFrame:")]
        public CustomCollectionCell(CGRect frame): base(frame)
        {
            this._imageView = new UIImageView();

            this._nameLabel = new UILabel()
                                  {
                                      BackgroundColor = UIColor.White,
                                      TextAlignment = UITextAlignment.Left,
                                      Font = UIFont.FromName("AmericanTypeWriter", 12f),
                                      TextColor = UIColor.Red,
                                  };
            
            this.ContentView.AddSubviews(new UIView[] {this._imageView, this._nameLabel});
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            this._imageView.Frame = new CGRect(0, 0,
                this.ContentView.Bounds.Width - 20, 
                this.ContentView.Bounds.Height - 20);

            this._nameLabel.Frame = new CGRect(0, 
                this.ContentView.Bounds.Height - 20,
                this.ContentView.Bounds.Width,
                20);
        }

        public void UpdateCell(string name, string imageName)
        {
            this._imageView.Image = UIImage.FromFile(imageName);
            this._nameLabel.Text = name;
        }
    }
}
