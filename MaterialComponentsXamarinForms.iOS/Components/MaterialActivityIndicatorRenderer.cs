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

        MDCActivityIndicator _ctrl;

        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialActivityIndicator> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    _ctrl = new MDCActivityIndicator();

                    SetNativeControl(_ctrl);
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
            if (Element.Color == Color.Default)
                _ctrl.CycleColors = new UIColor[] {};
            else
                _ctrl.CycleColors = new UIColor[] { Element.Color.ToUIColor() };
            //if(Control.CycleColors!=null)
            //{
            //    for (var i = 0; i < Control.CycleColors.Length; i++)
            //    {
            //        Control.CycleColors[i] = Element.Color.ToUIColor();
            //    }
            //}
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
