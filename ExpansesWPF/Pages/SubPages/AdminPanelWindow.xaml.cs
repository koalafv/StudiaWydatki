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

namespace ExpansesWPF.Pages.SubPages
{
	/// <summary>
	/// Interaction logic for AdminPanelWindow.xaml
	/// </summary>
	public partial class AdminPanelWindow : BudzetBuddy.BudzetBuddy
	{
		public AdminPanelWindow()
		{
			InitializeComponent();
		}

		private void AdminPanelWindow_Loaded(object sender, RoutedEventArgs e)
		{
			setupHeight();
			if (AdminPanelVisibility())
				stpPanelAdmin.Visibility = Visibility.Visible;
		}
		public void setupHeight()
		{
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			WindowState = WindowState.Maximized;
		}

		private void AdminPanelWindow_SizeChanged(object sender, SizeChangedEventArgs e)
		{

		}

		
		private void btnCredentials_Click(object sender, RoutedEventArgs e)
		{
			if (AddAccount(tbLogin.Text, tbPassword.Password))
				SuccesBox("Pomyślnie dodano użytkownika");
			else
				WarningBox("błąd podczas dodawania użytkownika");
			
		}
	}
}
