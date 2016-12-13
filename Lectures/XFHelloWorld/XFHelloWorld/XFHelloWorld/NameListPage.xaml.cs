using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFHelloWorld
{
    public partial class NameListPage : ContentPage
    {
        public NameListPage()
        {
            this.InitializeComponent();
        }

        private void Listview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            this.DisplayAlert(e.SelectedItem.ToString(), string.Empty, "Ok");
        }
    }
}
