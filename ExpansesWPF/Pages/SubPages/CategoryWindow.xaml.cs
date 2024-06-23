using ExpansesWPF.BudzetBuddy;
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
	/// Logika interakcji dla klasy CategoryWindow.xaml
	/// </summary>
	public partial class CategoryWindow : BudzetBuddy.BudzetBuddy
	{
		public CategoryWindow()
		{
			InitializeComponent();
		}

		private void categoryWindow_Loaded(object sender, RoutedEventArgs e)
		{
			setupHeight();
			LoadCategories();
			if (AdminPanelVisibility())
				stpPanelAdmin.Visibility = Visibility.Visible; 
		}

		private void LoadCategories() => gvCategories.ItemsSource = db.Categories.Where(w => w.categories_usr_ID == userID).ToList();

		public void setupHeight()
		{
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			WindowState = WindowState.Maximized;
		}

		private void btnMaximalize_Click(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
				this.WindowState = WindowState.Normal;
			else
				WindowState = WindowState.Maximized;
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnMinimize_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void mainWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
		private void btnMenu_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;
			MenuButtonClick(btn);
		}

		private void btnCategory_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(tbCategory.Text))
			{
				WarningBox("Uzupełnij kategorie");
				return;
			}

			db.Categories.InsertOnSubmit(new Categories
			{
				categories_date = DateTime.Now,
				categories_name = tbCategory.Text,
				categories_usr_ID = userID
			});
			db.SubmitChanges();
			ClearTextBox();
			LoadCategories();
		}

		private void ClearTextBox()
		{
			tbCategory.Text = string.Empty;
		}
	}
}
