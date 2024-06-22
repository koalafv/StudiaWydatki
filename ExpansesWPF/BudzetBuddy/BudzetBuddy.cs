using ExpansesWPF.Pages;
using ExpansesWPF.Pages.SubPages;
using System.Windows;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;


namespace ExpansesWPF.BudzetBuddy
{
	public class BudzetBuddy : Window
	{
		public ExpansesWPF.BudzetBuddy.ExpansesDBDataContext db = new ExpansesWPF.BudzetBuddy.ExpansesDBDataContext();
		public static int userID { get; set; }
		public void ErrorBox(string message) => MessageBox.Show(message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

		public void WarningBox(string message) => MessageBox.Show(message, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);


		public void SuccesBox(string message) => MessageBox.Show(message, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);

		public bool IsCredentialsRight(string login, string pass)
		{
			var users = db.Users.ToList();

			if (string.IsNullOrEmpty(login))
			{
				WarningBox("Podaj login");
				return false;
			}

			if (string.IsNullOrEmpty(pass))
			{
				WarningBox("Podaj hasło");
				return false;
			}

			var user = users.Where(w => string.Equals(w.usr_Login, login, StringComparison.Ordinal) && string.Equals(w.usr_Password, pass, StringComparison.Ordinal)).FirstOrDefault();

			if (user != null)
			{
				userID = user.usr_ID;

				return true;
			}

			WarningBox("Nieprawidłowe dane logowania");

			return false;
		}

		public void MenuButtonClick(System.Windows.Controls.Button btn)
		{
			try
			{
				if (btn.Name == "btnExpanses")
				{
					var cApp = ((App)System.Windows.Application.Current);
					cApp.MainWindow = new MainWindow();
					cApp.MainWindow.Show();
					this.Close();
				}
				else if (btn.Name == "btnCategories")
				{
					var cApp = ((App)System.Windows.Application.Current);
					cApp.MainWindow = new CategoryWindow();
					cApp.MainWindow.Show();
					this.Close();
				}
				else if (btn.Name == "btnRaport")
				{
					var cApp = ((App)System.Windows.Application.Current);
					cApp.MainWindow = new RaportWindow();
					cApp.MainWindow.Show();
					this.Close();
				}
			}
			catch (Exception ex)
			{
				ErrorBox($"Błąd: {ex.Message}");
			}
		}
		public void btnMinimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

		public void btnClose_Click(object sender, RoutedEventArgs e) => this.Close();
		public void btnMaximalize_Click(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
				this.WindowState = WindowState.Normal;
			else
				WindowState = WindowState.Maximized;
		}

		public void mainWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (WindowState == WindowState.Maximized)
				{
					WindowState = WindowState.Normal;
				}
				DragMove();
			}
		}
		public void btnMenu_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
			MenuButtonClick(btn);
		}
	}

}
