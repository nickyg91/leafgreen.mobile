using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeafGreen.App.Models;
using Xamarin.Forms;

namespace LeafGreen.App.Behaviors
{
    public class GardenValidatorBehavior : Behavior<Entry>
    {
        private static readonly BindablePropertyKey IsValidPropertyKey
            = BindableProperty
            .CreateReadOnly("IsValid", 
                typeof(bool), 
                typeof(GardenValidatorBehavior), 
                false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            private set => SetValue(IsValidPropertyKey, value);
        }

        public void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = !string.IsNullOrEmpty(e.NewTextValue);
            ((Entry) sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
