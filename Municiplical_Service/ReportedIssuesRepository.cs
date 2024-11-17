using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Municiplical_Service;

namespace Municiplical_Service
{
    public class ReportedIssuesRepository
    {
        private static ReportedIssuesRepository _instance;
        private ServiceRequestBST _serviceRequestBST = new ServiceRequestBST();
        private int _nextRequestId = 1;

        private ReportedIssuesRepository() { }

        public static ReportedIssuesRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportedIssuesRepository();
                }
                return _instance;
            }
        }

        // Add new issue
        public void AddIssue(ReportedIssues issue)
        {
            issue.RequestID = _nextRequestId++;
            _serviceRequestBST.Insert(issue);
        }

        // Get all issues using in-order traversal
        public List<ReportedIssues> GetAllIssues()
        {
            return _serviceRequestBST.InOrderTraversal();
        }

        // Get a specific issue by ID
        public ReportedIssues GetIssueById(int requestId)
        {
            return _serviceRequestBST.Search(requestId);
        }
    }
}
