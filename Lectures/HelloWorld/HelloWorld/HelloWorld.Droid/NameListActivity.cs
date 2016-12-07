using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloWorld.Droid
{
    using HelloWorld.Model;

    using Newtonsoft.Json;

    [Activity(Theme = "@style/MyTheme", Label = "Name list")]
    public class NameListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            this.SetContentView(Resource.Layout.NameList);

            var jsonStr = this.Intent.GetStringExtra("personList");
            var personList = JsonConvert.DeserializeObject<List<Person>>(jsonStr);

            var listview = this.FindViewById<ListView>(Resource.Id.namelistview);
            listview.Adapter = new NameListAdapter(this, personList);

            var toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar);
            this.SetActionBar(toolbar);
            this.ActionBar.Title = this.GetString(Resource.String.ToolbarTitle);
        }
    }
}