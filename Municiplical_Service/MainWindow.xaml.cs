using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Municiplical_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnReportIssue_Click(object sender, RoutedEventArgs e)
        {
            ReportIssueWindow reportIssueWindow = new ReportIssueWindow();
            reportIssueWindow.Show();
        }

        private void btnEventAnnouncements_Click(object sender, RoutedEventArgs e)
        {
            EventWindow eventWindow = new EventWindow();
            eventWindow.Show();
        }

        private void btnRequestStatus_Click(object sender, RoutedEventArgs e)
        {
           // RequestStatusWindow requestStatusWindow = new RequestStatusWindow();
           // requestStatusWindow.Show();
        }
    }
}