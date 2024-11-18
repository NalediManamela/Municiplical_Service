using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Municiplical_Service;

namespace Municiplical_Service
{
   public class ReportedIssues
    {
        public int RequestID { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string Status { get; set; } 
        public DateTime DateReported { get; set; }

        public ReportedIssues(int requestId, string location, string category, string description, string attachment)
        {
            RequestID = requestId;
            Location = location;
            Category = category;
            Description = description;
            Attachment = attachment;
            Status = "Pending"; 
            DateReported = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ID: {RequestID} | Location: {Location} | Category: {Category} | Status: {Status} | Date: {DateReported}";
        }
    }
}
