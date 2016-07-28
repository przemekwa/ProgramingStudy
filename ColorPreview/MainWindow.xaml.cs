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
using ColorPreview.Properties;

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

            this.SliderR.Value = Settings.Default.R;
            this.SliderG.Value = Settings.Default.G;
            this.SliderB.Value = Settings.Default.B;

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
                Settings.Default.R = this.SliderR.Value;
                Settings.Default.G = this.SliderG.Value;
                Settings.Default.B = this.SliderB.Value;

                Settings.Default.Save();

                Application.Current.Shutdown();
            }
        }
    }
}
