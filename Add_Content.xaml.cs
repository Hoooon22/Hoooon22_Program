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

                    // MySql DB Table 생성 (없으면)
                    string create_sql = "Create table if not exists " + dbTable + " ("
                               + "id int NOT NULL AUTO_INCREMENT PRIMARY KEY,"
                               + "date Date NOT NULL,"
                               + "title Varchar(45) NOT NULL,"
                               + "amount int NOT NULL,"
                               + "source Varchar(45) NOT NULL,"
                               + "remarks Varchar(45)"
                               + ");";
                    MySqlCommand create_cmd = new MySqlCommand(create_sql, conn);
                    create_cmd.ExecuteNonQuery();
                    //MessageBox.Show("테이블 생성 성공");

                    // MySql DB Table 값 입력
                    string insert_sql = "insert into " + dbTable
                        + "(date, title, amount, source, remarks)"
                        + " values "
                        + "(\'" + Date.Text + "\', \'" + Title.Text + "\', " + Amount.Text + ", \'" + Source.Text + "\', \'" + Remarks.Text + "\');";

                    MessageBox.Show(insert_sql);

                    MySqlCommand insert_cmd = new MySqlCommand(insert_sql, conn);
                    insert_cmd.ExecuteNonQuery();
                    MessageBox.Show("입력 성공!");

                    conn.Close(); // 연결 종료
                    Close(); // 윈도우 종료
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
