using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using Foundation;

    using HelloWorld.iOS.Views;
    using HelloWorld.Model;

    using UIKit;

    public class PersonCollectionSource : UICollectionViewSource
    {
        public static readonly NSString PersonCollectionCellId = new NSString("PersonCollectionCell");

        private List<Person> _personList;

        private Action<int>_onSelectedPerson;

        public PersonCollectionSource(List<Person> personList)
        {
            this._personList = personList;
            }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CustomCollectionCell)collectionView.DequeueReusableCell(PersonCollectionCellId, indexPath);

            int row = indexPath.Row;
            cell.UpdateCell(this._personList[row].Name, this._personList[row].ImageName);

            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return this._personList.Count;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Console.WriteLine("Row {0} selected", indexPath.Row);
        }

        public override bool ShouldSelectItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return true;
        }
    }
}
