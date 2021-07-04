using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace mvvmTest2
{
    public abstract class ObservableBase : MainViewModel, INotifyPropertyChanged
    {
        public void Set<TValue>(ref TValue field, TValue newValue, string propertyName = "")
        {
            if (!EqualityComparer<TValue>.Default.Equals(field, default) && field.Equals(newValue))
            {
                return;
            }

            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public abstract class ViewModelBase : ObservableBase
    {
        public bool IsInDesignMode
            => (bool)DesignerProperties.IsInDesignModeProperty
                .GetMetadata(typeof(DependencyObject))
                .DefaultValue;
    }

    public static class FocusHelper
    {
        public static bool GetIsFocused(DependencyObject ctrl)
            => (bool)ctrl.GetValue(IsFocusedProperty);

        public static void SetIsFocused(DependencyObject ctrl, bool value)
            => ctrl.SetValue(IsFocusedProperty, value);

        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
                "IsFocused", typeof(bool), typeof(FocusHelper),
                new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

        private static void OnIsFocusedPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            UIElement ctrl = (UIElement)d;
            if ((bool)e.NewValue)
            {
                ctrl.Focus(); // Don't care about false values.
            }
        }
    }
}
