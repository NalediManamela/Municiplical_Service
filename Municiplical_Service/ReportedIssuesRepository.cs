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

   
        public void AddIssue(ReportedIssues issue)
        {
            issue.RequestID = _nextRequestId++;
            _serviceRequestBST.Insert(issue);
        }

       
        public List<ReportedIssues> GetAllIssues()
        {
            return _serviceRequestBST.InOrderTraversal();
        }

       
        public ReportedIssues GetIssueById(int requestId)
        {
            return _serviceRequestBST.Search(requestId);
        }
    }
}
