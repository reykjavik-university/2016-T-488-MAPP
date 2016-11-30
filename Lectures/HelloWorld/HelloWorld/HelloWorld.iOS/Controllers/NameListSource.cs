using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using Foundation;

    using HelloWorld.iOS.Views;
    using HelloWorld.Model;

    using UIKit;

    public class NameListSource : UITableViewSource
    {
        public readonly NSString NameListCellId = new NSString("NameListCell");

        private List<Person> _personList;

        public NameListSource(List<Person> personList)
        {
            this._personList = personList;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CustomCell)tableView.DequeueReusableCell(this.NameListCellId);

            if (cell == null)
            {
                cell = new CustomCell((NSString)this.NameListCellId);
            }

            int row = indexPath.Row;
            cell.UpdateCell(this._personList[row].Name, this._personList[row].BirthYear.ToString(), this._personList[row].ImageName);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this._personList.Count;
        }
    }
}
