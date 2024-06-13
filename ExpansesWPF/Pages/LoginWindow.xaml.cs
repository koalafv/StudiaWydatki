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
using ExpansesWPF.BudzetBuddy;

namespace ExpansesWPF.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : BudzetBuddy.BudzetBuddy
    {
        public LoginWindow ( )
        {
            InitializeComponent();
        }

        private void BudzetBuddy_Loaded ( object sender, RoutedEventArgs e )
        {
            tbLogin.Focus();
            tbLogin.SelectAll();
        }

    

        private void BudzetBuddy_MouseDown ( object sender, MouseButtonEventArgs e )
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnLog_Click ( object sender, RoutedEventArgs e )
        {
            LogIn();
        }

        private void btnCancel_Click ( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void Login_KeyDown ( object sender, System.Windows.Input.KeyEventArgs e )
        {
            if (e.Key != Key.Enter)
                return;
            tbPassword.Focus();
            tbPassword.SelectAll();
        }

        private void Password_KeyDown ( object sender, System.Windows.Input.KeyEventArgs e )
        {
            if (e.Key != Key.Enter)
                return;
            LogIn();
        }

        private void btnLog_KeyDown ( object sender, System.Windows.Input.KeyEventArgs e )
        {
            if (e.Key != Key.Enter)
                return;
            LogIn();
        }

        private void LogIn ( )
        {
            if (IsCredentialsRight(tbLogin.Text, tbPassword.Password.ToString()))
            {
                var cApp = ((App)System.Windows.Application.Current);
                cApp.MainWindow = new MainWindow();
                cApp.MainWindow.Show();
                this.Close();
            }
            else
            {
                tbLogin.Focus();
                tbLogin.SelectAll();
            }
        }
    }
}
