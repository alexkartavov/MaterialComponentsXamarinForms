using System;
using MaterialComponents.MaterialSlider;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(XfMaterialSlider), typeof(MaterialSliderRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialSliderRenderer: ViewRenderer<XfMaterialSlider, UIControl>
    {
        public MaterialSliderRenderer()
        {
        }

        protected override UIControl CreateNativeControl()
        {
            return new MDCSlider();
        }
    }
}
