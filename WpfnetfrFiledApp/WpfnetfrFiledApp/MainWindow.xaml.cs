using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Xml.Schema;


namespace WpfnetfrFiledApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string initValue;
        public MainWindow()
        {
            InitializeComponent();
            initValue = this.TextBox1.Text;
        }

        private void NewAction_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "未命名";
            TextBox1.Text = string.Empty;
            TextBox1.Focus();
        }

        private void OpenAction_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Multiselect = false;
            bool? result = ofd.ShowDialog(); //在wpf中DialogResult 是一个bool值，这个和Winform是不一样的。
            if (result == true)
            {
                //MessageBox.Show(ofd.FileName);
                string filename = ofd.FileName;
                TextBox1.Text = File.ReadAllText(filename);
            }
        }

        private void ExitAction_Click(object sender, RoutedEventArgs e)
        {
            if (this.Title == "未命名" || TextBox1.Text != initValue)
            {
                MessageBoxResult result = MessageBox.Show(
                    "保存内容？",
                    "保存提示",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                // 判断用户的点击结果
                if (result == MessageBoxResult.Yes)
                {
                    // 用户点击了“是”
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    bool? dlgRet = dlg.ShowDialog();
                    if (dlgRet == true)
                    {
                        string filename = dlg.FileName;
                        File.WriteAllText(filename, TextBox1.Text);
                    }
                }
               
            }
            App.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RoutedEventArgs e1=new RoutedEventArgs();
            ExitAction_Click(sender, e1);
        }
    }
}
