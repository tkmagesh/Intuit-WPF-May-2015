using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            var userName = TxtUserName.Text;
            var password = PwdPassword.Password;
            if (userName == "Magesh" && password == "password")
            {
                TextBlockStatus.Text = "Login Successful!";
                TextBlockStatus.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Green);
            }
            else
            {
                TextBlockStatus.Text = "Wrong creditials! Login Failure!!";
                TextBlockStatus.Foreground = new System.Windows.Media.SolidColorBrush(Colors.Red);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TxtUserName.Text = PwdPassword.Password = string.Empty;
        }
    }
}
