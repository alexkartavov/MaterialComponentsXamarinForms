using System;
using System.ComponentModel;
using MaterialComponents.MaterialSlider;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(XfMaterialSlider), typeof(MaterialSliderRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialSliderRenderer: ViewRenderer<XfMaterialSlider, MDCSlider>
    {
        public MaterialSliderRenderer()
        {
        }

        protected override MDCSlider CreateNativeControl()
        {
            return new MDCSlider();
        }
        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialSlider> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                    SetNativeControl(CreateNativeControl());

                UpdateMin();
                UpdateMax();
                UpdateValue();
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Slider.MaximumProperty.PropertyName)
                UpdateMax();
            else if (e.PropertyName == Slider.MinimumProperty.PropertyName)
                UpdateMin();
            else if (e.PropertyName == Slider.ValueProperty.PropertyName)
                UpdateValue();
        }

        void UpdateMax()
        {
            Control.MaximumValue = (float)Element.Maximum;
        }

        void UpdateMin()
        {
            Control.MinimumValue = (float)Element.Minimum;
        }

        void UpdateValue()
        {
            Control.Value = (float)Element.Value;
        }
    }
}
