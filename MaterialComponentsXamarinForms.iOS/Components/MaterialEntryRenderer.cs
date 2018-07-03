using System;
using System.ComponentModel;
using MaterialComponents.MaterialTextFields;
using MaterialComponentsXamarinForms.Components;
using MaterialComponentsXamarinForms.iOS.Components;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRendererAttribute(typeof(XfMaterialEntry), typeof(MaterialEntryRenderer))]

namespace MaterialComponentsXamarinForms.iOS.Components
{
    public class MaterialEntryRenderer: ViewRenderer<XfMaterialEntry, MDCTextField>
    {
        public MaterialEntryRenderer()
        {
        }

        protected override MDCTextField CreateNativeControl()
        {
            return new MDCTextField();
        }

        UIColor _defaultTextColor;
        UIColor _defaultPlaceholderTextColor;
        protected override void OnElementChanged(ElementChangedEventArgs<XfMaterialEntry> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(CreateNativeControl());

                    _defaultTextColor = Control.TextColor;
                    _defaultPlaceholderTextColor = Control.PlaceholderLabel.TextColor;

                    //ctrl.Underline.Enabled = true;
                    //ctrl.Underline.Color = UIColor.Blue;

                    Control.ValueChanged += OnTextChanged;
                    Control.EditingDidEnd += OnCompleted;
                }

                UpdatePlaceHolder();
                UpdateIsPassword();
                UpdateHorizontalTextAlignement();
                UpdatePlaceholderColor();
                UpdateText();
                UpdateTextColor();
                UpdateFontAttributes();
                UpdateFontFamily();
                UpdateFontSize();
            }

            base.OnElementChanged(e);
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            Element?.SendCompleted();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Entry.PlaceholderProperty.PropertyName)
                UpdatePlaceHolder();
            else if (e.PropertyName == Entry.IsPasswordProperty.PropertyName)
                UpdateIsPassword();
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
                UpdateHorizontalTextAlignement();
            else if (e.PropertyName == Entry.PlaceholderColorProperty.PropertyName)
                UpdatePlaceholderColor();
            else if (e.PropertyName == Entry.TextProperty.PropertyName)
                UpdateText();
            else if (e.PropertyName == Entry.TextColorProperty.PropertyName)
                UpdateTextColor();
            else if (e.PropertyName == Entry.FontAttributesProperty.PropertyName)
                UpdateFontAttributes();
            else if (e.PropertyName == Entry.FontFamilyProperty.PropertyName)
                UpdateFontFamily();
            else if (e.PropertyName == Entry.FontSizeProperty.PropertyName)
                UpdateFontSize();
        }

        private void UpdateFontSize()
        {
            Control.MinimumFontSize = (float)Element.FontSize;
        }

        private void UpdateFontFamily()
        {
            
        }

        private void UpdateFontAttributes()
        {
            
        }

        private void UpdateTextColor()
        {
            if (Element.TextColor == Color.Default)
                Control.TextColor = _defaultTextColor;
            else
                Control.TextColor = Element.TextColor.ToUIColor();
        }

        private void UpdateText()
        {
            Control.Text = Element.Text;
        }

        private void UpdatePlaceholderColor()
        {
            if (Element.PlaceholderColor == Color.Default)
                Control.PlaceholderLabel.TextColor = _defaultPlaceholderTextColor;
            else
                Control.PlaceholderLabel.TextColor = Element.PlaceholderColor.ToUIColor();
        }

        private void UpdateHorizontalTextAlignement()
        {
            Control.HorizontalAlignment = 
                Element.HorizontalTextAlignment == TextAlignment.Start 
                ? UIControlContentHorizontalAlignment.Leading
                : (Element.HorizontalTextAlignment == TextAlignment.Center
                   ? UIControlContentHorizontalAlignment.Center
                   : UIControlContentHorizontalAlignment.Trailing);
        }

        private void UpdateIsPassword()
        {
            Control.SecureTextEntry = Element.IsPassword;
        }

        private void UpdatePlaceHolder()
        {
            Control.Placeholder = Element.Placeholder;
        }

    }
}
