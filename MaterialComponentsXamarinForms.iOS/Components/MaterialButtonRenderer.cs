using System;
using MaterialComponents.MaterialButtons;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(XfMaterialButton), typeof(MaterialButtonRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialButtonRenderer: ButtonRenderer
    {
        public MaterialButtonRenderer()
        {
        }

        protected override UIButton CreateNativeControl()
        {
            return new MDCButton();
        }
    }
}
