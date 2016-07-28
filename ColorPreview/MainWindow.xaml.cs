using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ColorPreview.Model;
using ColorPreview.Properties;
using Color = System.Windows.Media.Color;

namespace ColorPreview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var color = UserSettings.GetUserColor();

            this.SliderR.Value = color.R;
            this.SliderG.Value = color.G;
            this.SliderB.Value = color.B;

        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var color = Color.FromRgb(
                (byte)this.SliderR.Value, 
                (byte)this.SliderG.Value, 
                (byte)this.SliderB.Value);

            this.Rectangle1.Fill = new SolidColorBrush(color);
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                var color = new ColorPreview.Model.Color
                {
                    R = (byte) this.SliderR.Value,
                    G = (byte) this.SliderG.Value,
                    B = (byte) this.SliderB.Value
                };

                UserSettings.SaveColor(color);

                Application.Current.Shutdown();
            }
        }
    }
}
