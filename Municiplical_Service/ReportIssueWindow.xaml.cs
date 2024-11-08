using Microsoft.Win32;
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
    /// Interaction logic for ReportIssueWindow.xaml
    /// </summary>
    public partial class ReportIssueWindow : Window
    {
        private List<ReportedIssues> reportedIssues = new List<ReportedIssues>();
        private string attachedFilePath = " ";
        public ReportIssueWindow()
        {
            InitializeComponent();
            txtLocation.TextChanged += UpdateProgressBar;
            cmbCategory.SelectionChanged += UpdateProgressBar;
            txtDescription.TextChanged += UpdateProgressBar;
        }

        private void UpdateProgressBar(object sender, EventArgs e)
        {
            double progress = 0;

            // Check if location is filled
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 33.33;
            }

            // Check if category is selected
            if (cmbCategory.SelectedIndex != -1)
            {
                progress += 33.33;
            }

            // Check if description is filled
            if (!string.IsNullOrWhiteSpace(new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text))
            {
                progress += 33.34;
            }

            // Update the ProgressBar value
            progressBar.Value = progress;

            // Update engagement label
            if (progress == 100)
            {
                lblProgress.Text = "You're ready to submit!";
                lblProgress.Foreground = Brushes.Green;
            }
            else
            {
                lblProgress.Text = $"Form completion: {progress}%";
                lblProgress.Foreground = Brushes.Orange;
            }
        }

        // OpenFileDialog for media attachment
        private void btnAttachFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|Document files (*.pdf)|*.pdf"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                attachedFilePath = openFileDialog.FileName;
                lblAttachment.Text = $"Attached: {attachedFilePath}";
            }
        }
        // Submit button
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string location = txtLocation.Text;
            string category = (cmbCategory.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text;

            if (string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Please enter the location of the issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please provide a description of the issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Data structure to store issues
            var newIssue = new ReportedIssues
            {
                Location = location,
                Category = category,
                Description = description,
                Attachment = attachedFilePath
            };
            reportedIssues.Add(newIssue);
            progressBar.Value = 100;
            lblProgress.Text = "Report submitted successfully!";

            MessageBox.Show("Your issue has been reported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            // Clear the form for next input
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            txtDescription.Document.Blocks.Clear();
            lblAttachment.Text = "";
            progressBar.Value = 0;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
