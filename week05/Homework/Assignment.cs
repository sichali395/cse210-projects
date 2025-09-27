using System;

namespace Homework
{
    // Base class for all assignments
    public class Assignment
    {
        // Protected member variables so derived classes can access them
        protected string _studentName;
        protected string _topic;

        // Constructor
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Method to get summary
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }

        // Public getter for student name
        public string GetStudentName()
        {
            return _studentName;
        }
    }
}