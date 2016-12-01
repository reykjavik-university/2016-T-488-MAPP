using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS.Controllers
{
    using Foundation;

    using HelloWorld.iOS.Views;
    using HelloWorld.Model;

    using UIKit;

    public class PersonListSource : UITableViewSource
    {
        public readonly NSString NameListCellId = new NSString("NameListCell");

        private List<Person> _personList;

        private Action<int>_onSelectedPerson;

        public PersonListSource(List<Person> personList, Action<int> onSelectedPerson)
        {
            this._personList = personList;
            this._onSelectedPerson = onSelectedPerson;
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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            this._onSelectedPerson(indexPath.Row);
        }
    }
}
