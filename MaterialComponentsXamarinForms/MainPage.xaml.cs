using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaterialComponentsXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPgButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ButtonsPage());
        }

        //void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
