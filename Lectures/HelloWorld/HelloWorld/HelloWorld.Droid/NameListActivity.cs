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
    public class NameListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var jsonStr = this.Intent.GetStringExtra("personList");
            var personList = JsonConvert.DeserializeObject<List<Person>>(jsonStr);
            this.ListAdapter = new NameListAdapter(this, personList);
            // Create your application here
        }
    }
}