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
using System.Windows.Shapes;

namespace Hoooon22_Program
{
    /// <summary>
    /// Finance.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Finance : Window
    {
        ScaleTransform scale = new ScaleTransform();
        double originWidth, originHeight;

        public Finance()
        {
            originWidth = this.Width;
            originHeight = this.Height;
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window_Loaded);
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            originWidth = this.Width;
            originHeight = this.Height;

            if (this.WindowState == WindowState.Maximized)
            {
                ChangeSize(this.ActualWidth, this.ActualHeight);
            }

            this.SizeChanged += new SizeChangedEventHandler(Window_Changed);
        }

        private void ChangeSize(double width, double height)
        {
            scale.ScaleX = width / originWidth;
            scale.ScaleY = height / originHeight;

            FrameworkElement rootElement = this.Content as FrameworkElement;
            rootElement.LayoutTransform = scale;
        }

        void Window_Changed(object sender, SizeChangedEventArgs e)
        {
            scale.ScaleX = e.NewSize.Width / originWidth;
            scale.ScaleY = e.NewSize.Height / originHeight;
            FrameworkElement rootElement = this.Content as FrameworkElement;
            rootElement.LayoutTransform = scale;
        }
    }
}
