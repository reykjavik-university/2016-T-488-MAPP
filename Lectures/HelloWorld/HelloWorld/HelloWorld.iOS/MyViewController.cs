using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS
{
    using CoreGraphics;

    using UIKit;
    public class MyViewController : UIViewController
    {
        private const int HorizontalMargin = 20;

        private const int StartY = 80;

        private const int StepY = 50;

        private int _yCoord;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.White;

            this._yCoord = StartY;

            var prompt = new UILabel()
                             {
                                 Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width, 50),
                                 Text = "Enter you name: "
                             };
            this._yCoord += StepY;

            var nameField = new UITextField()
                                {
                                    Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width - 2*HorizontalMargin, 50),
                                    BorderStyle = UITextBorderStyle.RoundedRect,
                                    Placeholder = "Your name"
                                };
            this._yCoord += StepY;

            var greetingButton = UIButton.FromType(UIButtonType.RoundedRect);
            greetingButton.Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width - 2 * HorizontalMargin, 50);
            greetingButton.SetTitle("Greet me", UIControlState.Normal);
            this._yCoord += StepY;

            var greetingLabel = new UILabel()
                                    {
                                        Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width, 50)    
                                    };
            this._yCoord += StepY;

            greetingButton.TouchUpInside += (sender, args) =>
                {
                    nameField.ResignFirstResponder();
                    greetingLabel.Text = "Hello " + nameField.Text;
                };

            this.View.AddSubview(prompt);
            this.View.AddSubview(nameField);
            this.View.AddSubview(greetingButton);
            this.View.AddSubview(greetingLabel);
        }
    }
}
