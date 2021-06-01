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
using System.Data;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace Hoooon22_Program
{
    /// <summary>
    /// Finance.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Finance : Window
    {
        // DB Load

        MySqlConnection conn;
        string dbTable = "finace_content_tb"; // 접근할 테이블 설정
        string dbInfo()
        {
            string dbServer = "localhost";
            string dbDatabase = "hpdb";
            string dbUid = "root";
            string dbPwd = "password";
            string dbSslMode = "none";
            string Conn = "Server=" + dbServer + ";"
                        + "Database=" + dbDatabase + ";"
                        + "Uid=" + dbUid + ";"
                        + "Pwd=" + dbPwd + ";"
                        + "SslMode=" + dbSslMode;
            return Conn;
        }
        string select_sql;

        // Size
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
            // Window 사이즈 변경 시 컨트롤 크기 변경
            /*originWidth = this.Width;
            originHeight = this.Height;

            if (this.WindowState == WindowState.Maximized)
            {
                ChangeSize(this.ActualWidth, this.ActualHeight);
            }

            this.SizeChanged += new SizeChangedEventHandler(Window_Changed);*/

            // DB Load
            try
            {
                using (conn = new MySqlConnection(dbInfo()))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open) // System.Data
                    {
                        //MessageBox.Show("서버에 연결");
                    }

                    // Bring and Show DB Table
                    select_sql = "select * from " + dbTable + " order by date";
                    MySqlCommand select_cmd = new MySqlCommand(select_sql, conn);
                    MySqlDataReader rdr = select_cmd.ExecuteReader();

                    while (rdr.Read()) // Add Content each
                    {
                        Grid panel = new Grid(); // 사각형 감싸줄 Panel
                        panel.Margin = new Thickness(10, 20, 10, 0);

                        Rectangle rectangle = new Rectangle();
                        rectangle.Stroke = new SolidColorBrush(Colors.Aquamarine);
                        rectangle.Height = 50;

                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = rdr[2].ToString();
                        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;

                        panel.Children.Add(rectangle);
                        panel.Children.Add(textBlock);

                        Contents.Children.Add(panel);
                    }

                    conn.Close(); // 연결 종료
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

        // Add Content
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Content add_Content = new Add_Content();
            add_Content.Show();
        }
    }
}
