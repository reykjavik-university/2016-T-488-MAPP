using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld.Model;

namespace HelloWorld.iOS.Controllers
{
    using UIKit;
    public class NameListController : UITableViewController
    {
        private List<Person> _personList;

        public NameListController(List<Person> personList)
        {
            this._personList = personList;
        }

        public override void ViewDidLoad()
        {
            this.View.BackgroundColor = UIColor.White;
            this.Title = "Name list";

            this.TableView.Source = new NameListSource(this._personList);
        }
    }
}
