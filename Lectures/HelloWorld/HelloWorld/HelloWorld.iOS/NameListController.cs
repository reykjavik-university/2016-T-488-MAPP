using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS
{
    using UIKit;
    public class NameListController : UITableViewController
    {
        private List<string> _nameList;

        public NameListController(List<string> nameList)
        {
            this._nameList = nameList;
        }

        public override void ViewDidLoad()
        {
            this.View.BackgroundColor = UIColor.White;
            this.Title = "Name list";

            this.TableView.Source = new NameListSource(this._nameList);
        }
    }
}
