using System;
using System.ComponentModel;
using System.Drawing;
using MaterialComponents.MaterialProgressView;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(XfMaterialProgressView), typeof(MaterialProgressViewRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialProgressViewRenderer: ViewRenderer<XfMaterialProgressView, MDCProgressView>
    {
        protected override MDCProgressView CreateNativeControl()
        {
            return new MDCProgressView();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialProgressView> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                    SetNativeControl(CreateNativeControl());

                UpdateProgressColor();
                UpdateProgress();
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ProgressBar.ProgressColorProperty.PropertyName)
                UpdateProgressColor();
            else if (e.PropertyName == ProgressBar.ProgressProperty.PropertyName)
                UpdateProgress();
        }

        nfloat colorDesaturation = 0.3f;
        protected override void SetBackgroundColor(Color color)
        {
            base.SetBackgroundColor(color);

            if (Control == null)
                return;
            
            if (color == Color.Default)
            {
                var c = Control.ProgressTintColor;
                c.GetHSBA(out var hue, out var saturation, out var brightness, out var alpha);
                saturation = (nfloat)Math.Min((double)saturation * colorDesaturation, 1.0);
                Control.TrackTintColor = UIColor.FromHSBA(hue, saturation, brightness, alpha);
                return;
            }

            Control.TrackTintColor = color.ToUIColor();
        }

        void UpdateProgressColor()
        {
            Control.ProgressTintColor = Element.ProgressColor == Color.Default ? Color.Blue.ToUIColor() : Element.ProgressColor.ToUIColor();
        }

        void UpdateProgress()
        {
            Control.Progress = (float)Element.Progress;
        }
    }
}
