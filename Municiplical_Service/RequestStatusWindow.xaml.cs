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

namespace Municiplical_Service
{
    /// <summary>
    /// Interaction logic for RequestStatusWindow.xaml
    /// </summary>
    public partial class RequestStatusWindow : Window
    {
        public RequestStatusWindow()
        {
            InitializeComponent();
            LoadServiceRequests();
        }

        private void LoadServiceRequests()
        {
            var issues = ReportedIssuesRepository.Instance.GetAllIssues();
            dgServiceRequests.ItemsSource = issues;
        }

        private List<ReportedIssues> allIssues;
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (allIssues == null || !allIssues.Any())
            {
                MessageBox.Show("No service requests available.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string searchText = txtSearch.Text.ToLower();
            var filteredIssues = allIssues.Where(issue =>
                issue.RequestID.ToString().Contains(searchText) ||
                (issue.Location?.ToLower().Contains(searchText) ?? false) ||
                (issue.Category?.ToLower().Contains(searchText) ?? false)).ToList();

            dgServiceRequests.ItemsSource = filteredIssues;

            // Display a message if no results are found
            if (!filteredIssues.Any())
            {
                MessageBox.Show("No matching service requests found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


     
    }
}
