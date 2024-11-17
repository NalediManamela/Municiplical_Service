using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municiplical_Service
{
    public class ServiceRequestGraph
    {
        private Dictionary<string, List<string>> adjacencyList;

        public ServiceRequestGraph()
        {
            adjacencyList = new Dictionary<string, List<string>>();
        }

        public void AddCategory(string category)
        {
            if (!adjacencyList.ContainsKey(category))
            {
                adjacencyList[category] = new List<string>();
            }
        }

        public void AddDependency(string category1, string category2)
        {
            if (adjacencyList.ContainsKey(category1) && adjacencyList.ContainsKey(category2))
            {
                adjacencyList[category1].Add(category2);
            }
        }

        public List<string> GetDependencies(string category)
        {
            return adjacencyList.ContainsKey(category) ? adjacencyList[category] : new List<string>();
        }
    }
}
