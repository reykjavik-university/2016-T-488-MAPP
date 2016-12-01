using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using HelloWorld.Model;

    using UIKit;
    public class PersonCollectionController : UICollectionViewController
    {
        private List<Person> __personList;

        public PersonCollectionController(UICollectionViewFlowLayout layout, List<Person> personList) : base(layout)
        {
            this.__personList = personList;
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
