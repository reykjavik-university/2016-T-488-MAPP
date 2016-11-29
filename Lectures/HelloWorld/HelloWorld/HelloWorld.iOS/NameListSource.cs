using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS
{
    using Foundation;

    using UIKit;

    public class NameListSource : UITableViewSource
    {
        public readonly NSString NameListCellId = new NSString("NameListCell");

        private List<string> _nameList;

        public NameListSource(List<string> nameList)
        {
            this._nameList = nameList;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(this.NameListCellId);

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, (NSString)this.NameListCellId);
            }

            int row = indexPath.Row;
            cell.TextLabel.Text = this._nameList[row];

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this._nameList.Count;
        }
    }
}
