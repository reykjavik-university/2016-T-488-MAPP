using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using UIKit;
    public class TabBarController : UITabBarController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TabBar.BackgroundColor = UIColor.LightGray;
            this.TabBar.TintColor = UIColor.Red;

            this.SelectedIndex = 0;
        }
    }
}
