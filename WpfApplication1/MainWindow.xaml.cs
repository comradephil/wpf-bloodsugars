using BloodSugarTracker.Core.Components;
using System.Windows;
using System.Windows.Controls;

namespace BloodSugarTracker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		public ReadingValues Readings = new ReadingValues();
		
		public MainWindow()
		{
			InitializeComponent();
			StartLoading();
		}

		private void StartLoading()
		{
			ResultList.ItemsSource = Readings.Readings;
			Readings.ProcessExistingData();
			LoadingComplete();
		}

		public void LoadingComplete()
		{
			ProgressBar.Visibility = Visibility.Hidden;
			Options.Visibility = Visibility.Visible;
		}


		private void ListBoxItem_Selected_Reading(object sender, RoutedEventArgs e)
		{
			ReadingValue.Visibility = Visibility.Visible;
			SubmitButton.Visibility = Visibility.Visible;
			Background.Visibility = Visibility.Hidden;
			ResultList.Visibility = Visibility.Hidden;
		}
		private void ListBoxItem_Selected_Review(object sender, RoutedEventArgs e)
		{
			ReadingValue.Visibility = Visibility.Hidden;
			SubmitButton.Visibility = Visibility.Hidden;
			Background.Visibility = Visibility.Hidden;
			ResultList.Visibility = Visibility.Visible;
		}
		private void ListBoxItem_Selected_GraphDaily(object sender, RoutedEventArgs e)
		{
			ReadingValue.Visibility = Visibility.Hidden;
			SubmitButton.Visibility = Visibility.Hidden;
			Background.Visibility = Visibility.Visible;
			ResultList.Visibility = Visibility.Hidden;
		}
		private void ListBoxItem_Selected_GraphAverage(object sender, RoutedEventArgs e)
		{
			ReadingValue.Visibility = Visibility.Hidden;
			SubmitButton.Visibility = Visibility.Hidden;
			Background.Visibility = Visibility.Visible;
			ResultList.Visibility = Visibility.Hidden;
		}

		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			Readings.AddToDatabase(new Reading(double.Parse(ReadingValue.Text)));
			ReadingValue.Text = "";
		}
	}
}
