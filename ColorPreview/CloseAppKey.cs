using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ColorPreview
{
    public static class CloseAppKey
    {
        public static Key GetCloseKey(DependencyObject d)
        {
            return (Key) d.GetValue(KeyCloseProperty);
        }

        public static void SetCloseKey(DependencyObject d, Key k)
        {
            d.SetValue(KeyCloseProperty, k);
        }

        public static readonly DependencyProperty KeyCloseProperty = DependencyProperty.RegisterAttached("CloseKey",
            typeof(Key), typeof(CloseAppKey), new PropertyMetadata(Key.None, KeyChange));

        private static void KeyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Key key = (Key) e.NewValue;
            if (d is Window)
            {
                (d as Window).PreviewKeyDown += (object sender1, KeyEventArgs e1) =>
                {
                    if (e1.Key == key)
                    {
                        (sender1 as Window).Close();
                    }
                };
            }
            else
            {
                (d as UIElement).PreviewKeyDown += (object sender, KeyEventArgs e2) =>
                {
                    if (e2.Key == key)
                    {
                        (sender as UIElement).IsEnabled = false;
                    }
                };
            }
        }


    }
}
