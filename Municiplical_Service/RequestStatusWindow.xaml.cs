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
        private List<ReportedIssues> allIssues;

        public RequestStatusWindow()
        {
            InitializeComponent();
            LoadServiceRequests();
        }

        private void LoadServiceRequests()
        {
            allIssues = ReportedIssuesRepository.Instance.GetAllIssues();
            dgServiceRequests.ItemsSource = allIssues;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            // Using Binary Search Tree for efficient ID-based search
            if (int.TryParse(searchText, out int requestId))
            {
                var result = ReportedIssuesRepository.Instance.GetIssueById(requestId);
                dgServiceRequests.ItemsSource = result != null ? new List<ReportedIssues> { result } : new List<ReportedIssues>();
            }
            else
            {
                // Search by Location or Category
                var filteredIssues = allIssues.Where(issue =>
                    (issue.Location?.ToLower().Contains(searchText) ?? false) ||
                    (issue.Category?.ToLower().Contains(searchText) ?? false)).ToList();

                dgServiceRequests.ItemsSource = filteredIssues;
            }
        }
    }
}
