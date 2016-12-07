using Android.App;
using Android.Runtime;
using Android.Widget;
using Android.OS;

namespace HelloWorld.Droid
{
    using Android.Support.Design.Widget;
    using Android.Support.V4.App;
    using Android.Support.V4.View;

    [Activity (Theme = "@style/MyTheme", Label = "HelloWorld.Droid", Icon = "@drawable/icon")]
	public class MainActivity : FragmentActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            
			// Set our view from the "main" layout resource
			this.SetContentView (Resource.Layout.Main);
            
		    var toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar);
            ToolbarTabs.Construct(this, toolbar);
        }
    }
}


