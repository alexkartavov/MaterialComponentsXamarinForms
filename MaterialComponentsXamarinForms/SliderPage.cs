using System;

using Xamarin.Forms;

namespace MaterialComponentsXamarinForms
{
    public class SliderPage : ContentPage
    {
        public SliderPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

