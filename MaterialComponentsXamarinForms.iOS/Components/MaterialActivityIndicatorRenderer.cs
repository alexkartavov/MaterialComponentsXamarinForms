using System;
using System.ComponentModel;
using System.Drawing;
using MaterialComponents;
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

        protected override MDCActivityIndicator CreateNativeControl()
        {
            return new MDCActivityIndicator();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialActivityIndicator> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(CreateNativeControl());
                }

                UpdateColor();
                UpdateIsRunning();
                UpdateIndicatorMode();
                UpdateProgress();
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
            else if (e.PropertyName == XfMaterialActivityIndicator.IndicatorModePropertyName)
                UpdateIndicatorMode();
            else if (e.PropertyName == XfMaterialActivityIndicator.ProgressPropertyName)
                UpdateProgress();
        }

        void UpdateColor()
        {
            if (Element.Color == Color.Default)
                Control.CycleColors = new UIColor[] {};
            else
                Control.CycleColors = new UIColor[] { Element.Color.ToUIColor() };
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

        void UpdateIndicatorMode()
        {
            Control.IndicatorMode = 
                Element.IndicatorMode == ActivityIndicatorMode.Indeterminate 
                    ? MDCActivityIndicatorMode.Indeterminate 
                    : MDCActivityIndicatorMode.Determinate;
        }

        void UpdateProgress()
        {
            //Control.StopAnimating();
            if (!Control.Animating)
            {
                Control.StartAnimating();
                Control.Progress = (float)Element.Progress;
                Control.StopAnimating();
            }
        }
    }
}
