using System;
using System.ComponentModel;
using System.Drawing;
using MaterialComponents.MaterialActivityIndicator;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(XfMaterialActivityIndicator), typeof(MaterialActivityIndicatorRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialActivityIndicatorRenderer : ViewRenderer<XfMaterialActivityIndicator, MDCActivityIndicator>
    {
        public MaterialActivityIndicatorRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialActivityIndicator> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var ctrl = new MDCActivityIndicator();

                    SetNativeControl(ctrl);
                }

                UpdateColor();
                UpdateIsRunning();
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ActivityIndicator.ColorProperty.PropertyName)
                UpdateColor();
            else if (e.PropertyName == ActivityIndicator.IsRunningProperty.PropertyName)
                UpdateIsRunning();
        }

        void UpdateColor()
        {
            Control.TintColor = Element.Color == Color.Default ? null : Element.Color.ToUIColor();
        }

        void UpdateIsRunning()
        {
            if (Element.IsRunning)
                Control.StartAnimating();
            else
                Control.StopAnimating();
        }

        internal void PreserveState()
        {
            if (Control != null && !Control.Animating && Element != null && Element.IsRunning)
                Control.StartAnimating();
        }
    }
}
