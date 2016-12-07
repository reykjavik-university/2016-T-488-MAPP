using System;

using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

using Fragment = Android.Support.V4.App.Fragment;

namespace HelloWorld.Droid
{
    using Model;
    using Android.Views.InputMethods;

    using Newtonsoft.Json;

    public class NameInputFragment : Fragment
    {
        private People _people;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this._people = new People();

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var rootView = inflater.Inflate(Resource.Layout.NameInput, container, false);

            // Get our UI controls from the loaded layout:
            EditText nameEditText = rootView.FindViewById<EditText>(Resource.Id.nameEditText);

            Button greetingButton = rootView.FindViewById<Button>(Resource.Id.greetingButton);
            TextView greetingTextView = rootView.FindViewById<TextView>(Resource.Id.greetingTextView);

            greetingButton.Click += (object sender, EventArgs e) =>
            {
                InputMethodManager manager = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
                manager.HideSoftInputFromWindow(nameEditText.WindowToken, 0);
                this._people.AddPerson(nameEditText.Text, 0, string.Empty);
                greetingTextView.Text = "Hello " + nameEditText.Text;
            };

            Button nameListButton = rootView.FindViewById<Button>(Resource.Id.nameListButton);
            nameListButton.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this.Context, typeof(NameListActivity));
                intent.PutExtra("personList", JsonConvert.SerializeObject(this._people.Persons));
                this.StartActivity(intent);
            };

            return rootView;
        }
    }
}
