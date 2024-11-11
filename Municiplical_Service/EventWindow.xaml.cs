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
    /// Interaction logic for EventWindow.xaml
    /// </summary>
    public partial class EventWindow : Window
    {
        private SortedDictionary<DateTime, Queue<Event>> eventPriorityQueue = new SortedDictionary<DateTime, Queue<Event>>();
        private HashSet<string> uniqueCategories = new HashSet<string>();
        private List<(string Category, DateTime? Date)> searchHistory = new List<(string, DateTime?)>();
        private Dictionary<string, int> categorySearchCounts = new Dictionary<string, int>();

        public EventWindow()
        {
            InitializeComponent();
            LoadSampleEvents();
            DisplayEvents();
        }

        public void LoadSampleEvents()
        {
            AddEventToSystem(new Event("Town Hall Meeting", new DateTime(2024, 11, 1), "Government"));
            AddEventToSystem(new Event("Music Festival", new DateTime(2024, 10, 31), "Entertainment"));
            AddEventToSystem(new Event("Community Cleanup", new DateTime(2024, 10, 20), "Volunteer"));
            AddEventToSystem(new Event("Farmers Market", new DateTime(2024, 10, 22), "Market"));
            AddEventToSystem(new Event("School Opening", new DateTime(2024, 11, 30), "Government"));
            AddEventToSystem(new Event("Beach Day", new DateTime(2024, 11, 30), "Entertainment"));
            AddEventToSystem(new Event("Beach Clean Up", new DateTime(2024, 11, 20), "Volunteer"));
            AddEventToSystem(new Event("Market Day", new DateTime(2024, 10, 22), "Market"));
        }

        private void AddEventToSystem(Event newEvent)
        {
            if (!eventPriorityQueue.ContainsKey(newEvent.EventDate))
            {
                eventPriorityQueue[newEvent.EventDate] = new Queue<Event>();
            }
            eventPriorityQueue[newEvent.EventDate].Enqueue(newEvent);
            uniqueCategories.Add(newEvent.Category);
        }

        private void DisplayEvents()
        {
            List<Event> eventList = eventPriorityQueue.Values.SelectMany(q => q).ToList();
            eventDataGrid.ItemsSource = eventList;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string category = categoryComboBox.Text;
            DateTime? searchDate = datePicker.SelectedDate;
            List<Event> searchResults = new List<Event>();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                searchHistory.Add((category, searchDate));
                if (categorySearchCounts.ContainsKey(category))
                    categorySearchCounts[category]++;
                else
                    categorySearchCounts[category] = 1;
            }

            foreach (var dateQueue in eventPriorityQueue)
            {
                foreach (var eventItem in dateQueue.Value)
                {
                    if ((category == "All" || eventItem.Category.Equals(category, StringComparison.OrdinalIgnoreCase)) &&
                        (!searchDate.HasValue || eventItem.EventDate == searchDate.Value))
                    {
                        searchResults.Add(eventItem);
                    }
                }
            }

            eventDataGrid.ItemsSource = searchResults;

            if (searchResults.Count > 0)
            {
                string resultMessage = "Search Results:\n";
                foreach (var eventItem in searchResults)
                {
                    resultMessage += $"Event: {eventItem.Name}\nCategory: {eventItem.Category}\nDate: {eventItem.EventDate.ToShortDateString()}\n\n";
                }
                MessageBox.Show(resultMessage, "Search Results", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No events found for that category or date.", "Search Results", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            UpdateRecommendations();
        }

        private void UpdateRecommendations()
        {
            if (categorySearchCounts.Count == 0)
            {
                recommendationsListBox.Items.Clear();
                recommendationsListBox.Items.Add("No recommendations available yet.");
                return;
            }

            var mostSearchedCategory = categorySearchCounts.OrderByDescending(kvp => kvp.Value).First().Key;
            List<Event> recommendedEvents = new List<Event>();

            foreach (var dateQueue in eventPriorityQueue)
            {
                foreach (var eventItem in dateQueue.Value)
                {
                    if (eventItem.Category.Equals(mostSearchedCategory, StringComparison.OrdinalIgnoreCase))
                    {
                        recommendedEvents.Add(eventItem);
                    }
                }
            }

            recommendationsListBox.Items.Clear();
            if (recommendedEvents.Count > 0)
            {
                foreach (var recommendedEvent in recommendedEvents.Take(3))
                {
                    recommendationsListBox.Items.Add($"📅 {recommendedEvent.EventDate.ToShortDateString()} - {recommendedEvent.Name} ({recommendedEvent.Category})");
                }
            }
            else
            {
                recommendationsListBox.Items.Add("No events to recommend based on your search patterns.");
            }
        }
    }

    
}
