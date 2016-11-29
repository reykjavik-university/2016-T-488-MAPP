using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.iOS
{
    using UIKit;
    public class NameListController : UIViewController
    {
        private List<string> _nameList;

        public NameListController(List<string> nameList)
        {
            this._nameList = nameList;
        }

        public override void ViewDidLoad()
        {
            this.View.BackgroundColor = UIColor.White;
        }
    }
}
