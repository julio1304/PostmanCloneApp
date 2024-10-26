using PostmanCloneLibrary;
using System.Windows;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApiAccess api = new ApiAccess();

        public MainWindow()
        {
            InitializeComponent();

            httpVerbSelection.ItemsSource = Enum.GetValues(typeof(HttpAction));

            httpVerbSelection.SelectedItem = HttpAction.GET;
        }

        private async void callApi_Click(object sender, RoutedEventArgs e)
        {
            systemStatus.Text = "Calling API...";
            resultsText.Text = "";

            // Validate the API URL
            if (api.IsValidUrl(apiText.Text) == false)
            {
                systemStatus.Text = "Invalid URL";
                return;
            }

            HttpAction action = (HttpAction)httpVerbSelection.SelectedItem;        

            try
            {
                resultsText.Text = await api.CallApiAsync(apiText.Text, bodyText.Text, action);
                callData.SelectedItem = resultsTab;

                systemStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                resultsText.Text = "Error: " + ex.Message;
                systemStatus.Text = "Error";
            }
        }
    }
}