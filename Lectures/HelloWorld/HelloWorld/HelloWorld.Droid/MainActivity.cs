using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloWorld.Droid
{
    using System.Linq;

    using Android.Hardware.Input;
    using Android.Provider;
    using Android.Views.InputMethods;
    using HelloWorld.Model;

    [Activity (Theme = "@style/MyTheme", Label = "HelloWorld.Droid", Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
        private People _people;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            this._people = new People();

			// Set our view from the "main" layout resource
			this.SetContentView (Resource.Layout.Main);

			// Get our UI controls from the loaded layout
		    var nameEditText = this.FindViewById<EditText>(Resource.Id.nameEditText);

            var greetingTextView = this.FindViewById<TextView>(Resource.Id.greetingTextView);

            var greetingButton = this.FindViewById<Button>(Resource.Id.greetingButton);
            greetingButton.Click += (sender, args) =>
                {
                    var manager = (InputMethodManager)this.GetSystemService(InputMethodService);
                    manager.HideSoftInputFromWindow(nameEditText.WindowToken, 0);

                    this._people.AddPerson(nameEditText.Text, 0, string.Empty);
                    greetingTextView.Text = "Hello " + nameEditText.Text;
                };

            var nameListButton = this.FindViewById<Button>(Resource.Id.nameListButton);
            nameListButton.Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(NameListActivity));
                intent.PutStringArrayListExtra("nameList", this._people.Persons.Select(p => p.Name).ToArray());
                this.StartActivity(intent);  
            };
        }
    }
}


