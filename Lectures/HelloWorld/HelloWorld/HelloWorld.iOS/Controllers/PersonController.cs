using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld.Model;

namespace HelloWorld.iOS.Controllers
{
    using CoreGraphics;

    using UIKit;
    public class PersonController : UIViewController
    {
        private const int HorizontalMargin = 20;

        private const int StartY = 80;

        private const int StepY = 50;

        private int _yCoord;

        private People _people;

        public PersonController()
        {
            this._people = new People();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Name input";
            this.View.BackgroundColor = UIColor.White;

            this._yCoord = StartY;

            var prompt = this.CreatePromptl();

            var nameField = this.CreateNameField();

            var greetingButton = this.CreateButton("Greet me");

            var greetingLabel = this.CreateGreetingLabel();

            var navigateButton = this.CreateButton("See name list");

            greetingButton.TouchUpInside += (sender, args) =>
                {
                    nameField.ResignFirstResponder();
                    var person = new Person() { Name = nameField.Text, BirthYear = 0, ImageName = string.Empty };
                    this._people.Persons.Add(person);
                    greetingLabel.Text = "Hello " + nameField.Text;
                };

            navigateButton.TouchUpInside += (sender, args) =>
            {
                nameField.ResignFirstResponder();
                this.NavigationController.PushViewController(new PersonListController(this._people.Persons), true);
            };
            this.View.AddSubview(prompt);
            this.View.AddSubview(nameField);
            this.View.AddSubview(greetingButton);
            this.View.AddSubview(greetingLabel);
            this.View.AddSubview(navigateButton);
        }

        private UIButton CreateButton(string title)
        {
            var button = UIButton.FromType(UIButtonType.RoundedRect);
            button.Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width - 2 * HorizontalMargin, 50);
            button.SetTitle(title, UIControlState.Normal);
            this._yCoord += StepY;
            return button;
        }

        private UILabel CreateGreetingLabel()
        {
            var greetingLabel = new UILabel() { Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width, 50) };
            this._yCoord += StepY;
            return greetingLabel;
        }

        private UITextField CreateNameField()
        {
            var nameField = new UITextField()
                                {
                                    Frame =
                                        new CGRect(
                                            HorizontalMargin,
                                            this._yCoord,
                                            this.View.Bounds.Width - 2 * HorizontalMargin,
                                            50),
                                    BorderStyle = UITextBorderStyle.RoundedRect,
                                    Placeholder = "Your name"
                                };
            this._yCoord += StepY;
            return nameField;
        }

        private UILabel CreatePromptl()
        {
            var prompt = new UILabel()
                             {
                                 Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width, 50),
                                 Text = "Enter you name: "
                             };
            this._yCoord += StepY;
            return prompt;
        }
    }
}
