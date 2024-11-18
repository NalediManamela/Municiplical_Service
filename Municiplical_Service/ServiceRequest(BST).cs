using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municiplical_Service
{
    public class ServiceRequestBST
    {
        public class TreeNode
        {
            public ReportedIssues Data;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(ReportedIssues data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        public TreeNode Root { get; private set; }

        // Insert a new issue into the BST
        public void Insert(ReportedIssues issue)
        {
            Root = Insert(Root, issue);
        }

        private TreeNode Insert(TreeNode node, ReportedIssues issue)
        {
            if (node == null)
                return new TreeNode(issue);

            if (issue.RequestID < node.Data.RequestID)
                node.Left = Insert(node.Left, issue);
            else if (issue.RequestID > node.Data.RequestID)
                node.Right = Insert(node.Right, issue);

            return node;
        }

       
        public ReportedIssues Search(int requestId)
        {
            return Search(Root, requestId);
        }

        private ReportedIssues Search(TreeNode node, int requestId)
        {
            if (node == null) return null;
            if (node.Data.RequestID == requestId) return node.Data;

            if (requestId < node.Data.RequestID)
                return Search(node.Left, requestId);
            else
                return Search(node.Right, requestId);
        }

        
        public List<ReportedIssues> InOrderTraversal()
        {
            List<ReportedIssues> result = new List<ReportedIssues>();
            InOrderTraversal(Root, result);
            return result;
        }

        private void InOrderTraversal(TreeNode node, List<ReportedIssues> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list);
            list.Add(node.Data);
            InOrderTraversal(node.Right, list);
        }
    }
}
