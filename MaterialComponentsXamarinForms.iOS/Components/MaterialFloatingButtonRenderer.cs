using System;
using System.ComponentModel;
using System.Drawing;
using Foundation;
using MaterialComponents.MaterialButtons;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(XfMaterialFloatingButton), typeof(MaterialFloatingButtonRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialFloatingButtonRenderer : MaterialButtonRenderer
    {
        protected override MDCButton CreateNativeControl()
        {
            return new MDCFloatingButton();
        }
    }
}
