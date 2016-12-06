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

    public class NameListAdapter : BaseAdapter<Person>
    {
        private Activity _context;

        private List<Person> _personList;

        public NameListAdapter(Activity context, List<Person> personList)
        {
            this._context = context;
            this._personList = personList;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = this._context.LayoutInflater.Inflate(Resource.Layout.NameListItem, null);
            }

            var person = this._personList[position];
            view.FindViewById<TextView>(Resource.Id.name).Text = person.Name;
            view.FindViewById<TextView>(Resource.Id.year).Text = person.BirthYear.ToString();

            var resourceId = this._context.Resources.GetIdentifier(
                person.ImageName,
                "drawable",
                this._context.PackageName);
            view.FindViewById<ImageView>(Resource.Id.picture).SetBackgroundResource(resourceId);

            return view;
        }

        public override int Count {
            get
            {
                return this._personList.Count;
            }
        }

        public override Person this[int position]
        {
            get
            {
                return this._personList[position];
            }
        }
    }
}