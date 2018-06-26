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
        //public SizeF SizeThatFits(SizeF size)
        //{
        //    // progress bar will size itself to be as wide as the request, even if its inifinite
        //    // we want the minimum need size
        //    var result = base.SizeThatFits(size);
        //    return new SizeF(10, result.Height);
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialProgressView> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                    SetNativeControl(new MDCProgressView());

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

        protected override void SetBackgroundColor(Color color)
        {
            base.SetBackgroundColor(color);

            if (Control == null)
                return;

            Control.TrackTintColor = color != Color.Default ? color.ToUIColor() : null;
        }

        void UpdateProgressColor()
        {
            //Control.ProgressTintColor = Element.ProgressColor == Color.Default ? null : Element.ProgressColor.ToUIColor();
        }

        void UpdateProgress()
        {
            Control.Progress = (float)Element.Progress;
        }
    }
}
