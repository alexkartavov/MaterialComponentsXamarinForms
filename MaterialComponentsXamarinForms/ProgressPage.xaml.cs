using System;
using System.Collections.Generic;
using System.Timers;
using Xamarin.Forms;

namespace MaterialComponentsXamarinForms
{
    public partial class ProgressPage : ContentPage
    {
        double _progress = 0.0;
        public ProgressPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                _progress += 0.2;
                if (_progress > 1)
                    _progress = 0.0;
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.progressView1.Progress = _progress;
                    this.progressView2.Progress = _progress;
                });
                return true;
            });
        }

    }
}
