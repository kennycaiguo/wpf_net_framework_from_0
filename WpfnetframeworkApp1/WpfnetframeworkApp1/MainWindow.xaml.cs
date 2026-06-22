using MySqlConnector;
using System;
using System.Data;

//using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;


namespace WpfnetframeworkApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Label1.Content = "Hello";
            string connStr = "server=127.0.0.1;user=root;password=root;database=mydata;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    //MsqlDemo1(conn);
                    MysqlDemo(conn, this);
                }
                catch (Exception ex)
                {
                    // 处理连接错误
                    Console.WriteLine(ex.Message);
                    Label1.Content = $"Error: {ex.Message}";
                }
                finally
                {
                    conn.Close();
                }
            }

        }


        private static void MysqlDemo(MySqlConnection conn,MainWindow win)
        {
            conn.Open();
            string sql = "select * from data;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            win.dtGrid.ItemsSource = dt.DefaultView;
            conn.Close();
        }
    }
}
