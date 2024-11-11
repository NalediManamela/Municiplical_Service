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
    }
}
