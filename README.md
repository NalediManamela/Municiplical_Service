*Municipal Service Application*
This project is a WPF-based desktop application designed to help residents of a municipality report service issues, track their status,view related service request information and 
also see local event that are upcomming.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*Table of Contents*
1.Project Overview
2.Features
3.Setup Instructions
4.Cloning the Repository
5.Compiling the Project
6.Running the Application
7.Usage Instructions

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*Project Overview*
The Municipal Service Application is designed to help manage and track municipal service requests and also see upcoming events. It allows residents to:
1.Report issues in their municipality
2.Track the status of their requests
3.Search for requests by ID, location, or category
4.View dependencies between different service categories using a graph structure
5.View upcoming events 
6.Search for upcoming events
7.View recommened events based on search history 

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*Features*
Service Request Management: View a list of service requests with the option to search for specific requests.
Efficient Search: Uses a Binary Search Tree (BST) for fast search by service request ID.
Category Dependencies: A graph structure to manage and visualize dependencies between service categories.
User Interface: A clean and responsive WPF-based user interface that provides an intuitive experience for managing service requests.
Priority Queus: To store event basedon the date for the upcoming events 
Hashset: To store unique event date for the upcoming events
Dictornaries: to organize and retrieving event information for the upcoming events 

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*Setup Instructions*
Cloning the Repository
Clone the repository to your local machine using Git or download the ZIP file.

bash
Copy code
git clone https://github.com/NalediManamela/Municiplical_Service.git
Navigate to the project folder:

bash
Copy code
cd Municiplical_Service
Compiling the Project
Open the solution file Municiplical_Service.sln in Visual Studio.

Build the solution by selecting Build > Build Solution or pressing Ctrl+Shift+B.

Visual Studio will restore any required NuGet packages and build the project. If there are no errors, you are ready to run the application.

Running the Application
Once the project is successfully compiled, press F5 or Debug > Start Debugging to run the application.

The main window of the Municipal Service application will launch.

Ensure that all necessary dependencies and services (like a local database or repository) are available for the application to interact with.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


