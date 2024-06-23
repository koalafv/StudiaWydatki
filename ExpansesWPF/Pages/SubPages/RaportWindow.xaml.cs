using ExpansesWPF.BudzetBuddy;
using ExpansesWPF.BudzetBuddy.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace ExpansesWPF.Pages.SubPages
{
	/// <summary>
	/// Logika interakcji dla klasy RaportWindow.xaml
	/// </summary>
	public partial class RaportWindow : BudzetBuddy.BudzetBuddy, ISetHeight
    {
        List<Months> months = new List<Months>();
        public RaportWindow ( )
        {
            InitializeComponent();
        }
		public void setHeight()
		{
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			WindowState = WindowState.Maximized;
		}

		private void raportWIndow_Loaded ( object sender, RoutedEventArgs e )
        {
            LoadMonths();
			if (AdminPanelVisibility())
				stpPanelAdmin.Visibility = Visibility.Visible;
		}

        private void LoadMonths ( )
        {
            months = db.Months.ToList();
            cbMonths.ItemsSource = months.Select(s => s.mth_name).ToList();
        }

        private void cbMonths_SelectionChanged ( object sender, SelectionChangedEventArgs e )
        {
            if (cbMonths.SelectedItem != null)
            {
                var sumPrice = new List<SumPrice>();

                int month = months.Where(w => w.mth_name == cbMonths.SelectedItem.ToString()).Select(s => s.mth_number).FirstOrDefault();

                List<Categories> categories = db.Categories.Where(w => w.categories_usr_ID == userID).ToList();

                var expanses = db.Expanses.Where(w => w.exps_date.Value.Month == month).Select(s => new
                {
                    s.exps_Category,
                    s.exps_Price,
                    s.exps_usr_ID
                }).ToList();

                foreach (var category in categories)
                {
                    sumPrice.Add(new SumPrice
                    {
                        CategoryName = category.categories_name,
                        SummedPrice = expanses.Where(w => w.exps_Category == category.categories_name && w.exps_usr_ID == userID).Sum(s => s.exps_Price)
                    });
                }

                sumPrice.Add(new SumPrice
                {
                    CategoryName = "Wszystko",
                    SummedPrice = expanses.Where(w => w.exps_usr_ID == userID).Sum(s => s.exps_Price)
                });

                gvSummedPrice.ItemsSource = sumPrice;
            }
        }
	}

    class SumPrice
    {
        public decimal? SummedPrice { get; set; }
        public string? CategoryName { get; set; }
    }
}
