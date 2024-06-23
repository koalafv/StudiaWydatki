using ExpansesWPF.Pages;
using ExpansesWPF.Pages.SubPages;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;


namespace ExpansesWPF.BudzetBuddy
{
	public class BudzetBuddy : ExpansesWPF.Window
	{
		public ExpansesWPF.BudzetBuddy.ExpansesDBDataContext db = new ExpansesWPF.BudzetBuddy.ExpansesDBDataContext();
		public static int userID { get; set; }
		public static UserAdmin UserAdmin { get; set; }
		public bool AddAccount(string login, string password)
		{
			try
			{
				if (db.Users.Any(w => w.usr_Login == login))
				{
					WarningBox("Już istnieje taki użytkownik, zmień nazwę");
					return false;
				}

				var newUser = new Users
				{
					usr_date = DateTime.Now,
					usr_IsAdmin = false,
					usr_Login = login,
					usr_Password = HashPassword(password)
				};

				db.Users.InsertOnSubmit(newUser);
				db.SubmitChanges();


				return true;
			}
			catch
			{
				WarningBox("błąd podczas dodawania użytkownika");
				return false;
			}

		}
		private static string HashPassword(string password)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
					builder.Append(bytes[i].ToString("x2"));
				return builder.ToString();
			}
		}
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

			var user = users.Where(w => string.Equals(w.usr_Login, login, StringComparison.Ordinal) && string.Equals(w.usr_Password, HashPassword(pass), StringComparison.Ordinal)).FirstOrDefault();

			if (user != null)
			{
				userID = user.usr_ID;

				if (user.usr_IsAdmin != null && (bool)user.usr_IsAdmin)
				{
					UserAdmin = new UserAdmin();
					UserAdmin.usr_IsAdmin = true;
					UserAdmin.usr_Login = user.usr_Login;
					UserAdmin.usr_Password = user.usr_Password;
				}
				else
				{
					UserAdmin = null;
				}

				return true;
			}

			WarningBox("Nieprawidłowe dane logowania");

			return false;
		}

		public bool AdminPanelVisibility()
		{
			if (UserAdmin != null) return true;

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
				else if (btn.Name == "btnLogout")
				{
					var cApp = ((App)System.Windows.Application.Current);
					cApp.MainWindow = new LoginWindow();
					cApp.MainWindow.Show();
					this.Close();
				}
				else if (btn.Name == "btnAdminPanel")
				{
					var cApp = ((App)System.Windows.Application.Current);
					cApp.MainWindow = new AdminPanelWindow();
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
