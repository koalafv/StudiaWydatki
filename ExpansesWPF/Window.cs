using System.Windows;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace ExpansesWPF
{
	public class Window : System.Windows.Window
	{
		public void ErrorBox(string message) => MessageBox.Show(message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

		public void WarningBox(string message) => MessageBox.Show(message, "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);


		public void SuccesBox(string message) => MessageBox.Show(message, "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
	}
}
