using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using HelloWorld.iOS.Views;
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
            this.Title = "Collection";

            this.CollectionView.BackgroundColor = UIColor.White;
            this.CollectionView.ContentSize = this.View.Frame.Size;
            this.CollectionView.ContentInset = new UIEdgeInsets(10, 10, 10, 10);
            
            this.CollectionView.RegisterClassForCell(typeof(CustomCollectionCell), PersonCollectionSource.PersonCollectionCellId);

            this.CollectionView.DataSource = new PersonCollectionSource(this.__personList);
        }
    }
}
