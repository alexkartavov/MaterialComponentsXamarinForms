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

        private async void OnPgActivityClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ActivityPage());
        }

        private async void OnPgProgressClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProgressPage());
        }

        private async void OnPgSliderClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SliderPage());
        }

        private async void OnPgEntryClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        } 

        private async void OnPgEditorClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EditorPage());
        }
    }

}
