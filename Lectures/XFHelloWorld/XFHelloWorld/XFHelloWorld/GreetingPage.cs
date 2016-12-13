using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFHelloWorld
{
    public class GreetingPage : ContentPage
    {
        private Label _entryLabel = new Label
        {
            HorizontalOptions = LayoutOptions.Start,
            Text = "Enter your name:",
        };

        private Entry _nameEntry = new Entry
        {
            HorizontalOptions = LayoutOptions.Fill,
            Placeholder = "Name",
        };

        private Button _displayNameButton = new Button
        {
            Text = "Greet me",
            BorderColor = Color.Gray,
            HorizontalOptions = LayoutOptions.Fill,
        };

        private Label _displayLabel = new Label
        {
            Text = string.Empty,
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
        };

        private Button _seeNameListButton = new Button
        {
            Text = "See name list",
            BorderColor = Color.Gray,
            HorizontalOptions = LayoutOptions.Fill,
        };


        public GreetingPage()
        {
            this.BackgroundColor = Color.FromRgb(240, 240, 240);
            this.Title = "Hello my friend!";

            this.Content = new StackLayout
                               {
                                   Margin = 30,
                                   VerticalOptions = LayoutOptions.Start,
                                   Spacing = 10,
                                   Children =
                                       {
                                           new StackLayout { Children = { this._entryLabel, this._nameEntry, }, },
                                           this._displayNameButton,
                                           this._displayLabel,
                                           this._seeNameListButton
                                       }
                               };

            this._displayNameButton.Clicked += this.OnDisplayNameButtonClicked;
            this._nameEntry.Completed += this.OnDisplayNameButtonClicked;

            this._seeNameListButton.Clicked += async (sender, args) =>
                {
                    await this.Navigation.PushAsync(new NameListPage());
                };
        }

        private void OnDisplayNameButtonClicked(object sender, EventArgs args)
        {
            this._displayLabel.Text = "Hello " + this._nameEntry.Text;
            this._nameEntry.Text = string.Empty;
        }
    }
}
