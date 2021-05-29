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
    /// Add_Content.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Add_Content : Window
    {
        MySqlConnection conn;
        string dbTable = "finace_content_tb"; // 접근할 테이블 설정
        string dbInfo()
        {
            string dbServer = "";
            string dbDatabase = "";
            string dbUid = "";
            string dbPwd = "";
            string dbSslMode = "none";
            string Conn = "Server=" + dbServer + ";"
                        + "Database=" + dbDatabase + ";"
                        + "Uid=" + dbUid + ";"
                        + "Pwd=" + dbPwd + ";"
                        + "SslMode=" + dbSslMode;
            return Conn;
        }

        public Add_Content()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (conn = new MySqlConnection(dbInfo()))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open) // System.Data
                    {
                        MessageBox.Show("서버에 연결");
                    }

                    // Mysql DB Table 생성

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
