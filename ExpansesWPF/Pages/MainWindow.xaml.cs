using System.Windows;
using System.Windows.Interop;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;
using ExpansesWPF.BudzetBuddy;
using System.Windows.Documents;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ExpansesWPF.BudzetBuddy.Interfaces;


namespace ExpansesWPF.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BudzetBuddy.BudzetBuddy, ISetHeight
	{

        public MainWindow ( )
        {
            InitializeComponent();
        }
		public void setHeight()
		{
			this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			WindowState = WindowState.Maximized;
		}

		private void mainWindow_Loaded ( object sender, RoutedEventArgs e )
        {
            setHeight();
            LoadExpanses();
            LoadCategories();
            AddMonthlyExpanses();
			if (AdminPanelVisibility())
				stpPanelAdmin.Visibility = Visibility.Visible;
		}

        private void AddMonthlyExpanses ( )
        {
            var monthlyExpanses = db.MonthlyExpanses.Where(w=>w.expsm_usr_ID==userID).ToList();
            var expanses = db.Expanses.Where(w => w.exps_usr_ID == userID).ToList();
            
            if (monthlyExpanses.Count == 0)
                return;

            foreach(var exps in monthlyExpanses){
                if(exps.expsm_day == int.Parse(DateTime.Today.Day.ToString()))
                {
                    if(expanses.Where(w=>w.exps_monthlyExps_ID == exps.expsm_ID).Any())
                    {
                        if(!(exps.expsm_date.Month == int.Parse(DateTime.Today.Month.ToString()) && exps.expsm_date.Year == int.Parse(DateTime.Today.Year.ToString())))
                        {
                            db.Expanses.InsertOnSubmit(new Expanses
                            {
                                exps_Category = exps.expsm_Category,
                                exps_Description = exps.expsm_Description,
                                exps_Price = exps.expsm_Price,
                                exps_date = DateTime.Now,
                                exps_usr_ID = userID,
                                exps_monthlyExps_ID = exps.expsm_ID,
                            });
                            db.SubmitChanges();
                        }
                    }
                    else
                    {
                        db.Expanses.InsertOnSubmit(new Expanses
                        {
                            exps_Category = exps.expsm_Category,
                            exps_Description = exps.expsm_Description,
                            exps_Price = exps.expsm_Price,
                            exps_date = DateTime.Now,
                            exps_usr_ID = userID,
                            exps_monthlyExps_ID = exps.expsm_ID,
                        });
                        db.SubmitChanges();
                    }
                }
            }
        }

        private void LoadCategories ( )
        {
            var categories = db.Categories.Where(w => w.categories_usr_ID == userID).Select(s => s.categories_name).ToList();
            cbCategory.ItemsSource = categories;
            cbCatergoryMonthly.ItemsSource = categories;
        }

        private void mainWindow_SizeChanged ( object sender, SizeChangedEventArgs e )
        {
            
        }

        private void LoadExpanses ( )
        {
            List<ExpansesDT> expanses = new List<ExpansesDT>();
            expanses = db.Expanses.Where(w=>w.exps_usr_ID == userID).Select(s => new ExpansesDT
            {    
                exps_ID=s.exps_ID,
                 exps_Category = s.exps_Category,
                 shortDate = s.exps_date.Value.ToShortDateString(),
                 exps_Description = s.exps_Description,
                 exps_Price = s.exps_Price,
            }).OrderByDescending(o=>o.exps_ID).ToList();

            gvExpanses.ItemsSource = expanses;
        }

        private void btnAddExpanse_Click ( object sender, RoutedEventArgs e )
        {
            try
            {
                string category = cbCategory.Text;
                decimal price = decimal.Parse(tbPrice.Text);
                string description = GetRichTextBoxText(tbDescription);

                Expanses expanse = new Expanses
                {
                    exps_Category = category,
                    exps_Description = description,
                    exps_Price = price,
                    exps_date = DateTime.Now,
                    exps_usr_ID = userID,
                };

                db.Expanses.InsertOnSubmit(expanse);
                db.SubmitChanges();
                SuccesBox("Dodano pomyślnie");
                ClearTextBox();
                LoadExpanses();
            }
            catch
            {
                ErrorBox("Nie udało się dodać,\n ponieważ cena musi być: np 1 lub 1.0");
            }
        }
        private string GetRichTextBoxText ( System.Windows.Controls.RichTextBox richTextBox )
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange.Text;
        }

        private void ClearRichTextBoxText ( System.Windows.Controls.RichTextBox richTextBox )
        {
            richTextBox.Document = new System.Windows.Documents.FlowDocument();
        }

        private void ClearTextBox ( )
        {
            ClearRichTextBoxText(tbDescription);
            tbPrice.Text = string.Empty;
            cbCategory.Text = string.Empty;
        }

        private void btnAddMonthlyExpanse_Click ( object sender, RoutedEventArgs e )
        {
            if (!IsDayCorrect())
                return;
            try
            {
                string category = cbCatergoryMonthly.Text;
                decimal price = decimal.Parse(tbPriceMonthly.Text);
                string description = GetRichTextBoxText(tbDescriptionMonthly);

                MonthlyExpanses monthlyExpanse = new MonthlyExpanses
                {
                    expsm_Category = category,
                    expsm_date = DateTime.Now,
                    expsm_day = int.Parse(tbDay.Text),
                    expsm_Price = price,
                    expsm_Description = description,
                    expsm_usr_ID = userID,
                };

                db.MonthlyExpanses.InsertOnSubmit(monthlyExpanse);
                db.SubmitChanges();
                SuccesBox("Dodano pomyślnie");
                ClearTextBox();
                LoadExpanses();
            }
            catch
            {
                ErrorBox("Błąd podczas dodawania");
            }

        }

        private bool IsDayCorrect ( )
        {
            try
            {
                if (int.Parse(tbDay.Text) <= 0 || int.Parse(tbDay.Text)>28)
                {
                    ErrorBox("Zły podany dzień");
                    return false;
                }
                return true;


            }
            catch
            {
                ErrorBox("Nie prawidłowy dzień");
                return false;
            }
        }

        private void tcExpanses_SelectionChanged ( object sender, System.Windows.Controls.SelectionChangedEventArgs e )
        {
            if (ExpansesGrid.IsSelected)
            {
                AddMonthlyExpanses();
            }
        }
	}

    public class ExpansesDT : Expanses
    {
        public string? shortDate { get; set; }
    }
}
