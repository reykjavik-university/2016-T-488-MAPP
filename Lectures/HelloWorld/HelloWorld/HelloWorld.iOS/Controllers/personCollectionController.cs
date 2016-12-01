using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using UIKit;
    public class PersonCollectionController : UIViewController
    {
        public PersonCollectionController()
        {
            this.TabBarItem = new UITabBarItem(UITabBarSystemItem.Favorites, 0);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.View.BackgroundColor = UIColor.White;
            this.Title = "Collection";
        }
    }
}
