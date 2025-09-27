using System;

namespace Homework
{
    // Derived class for Writing assignments
    public class WritingAssignment : Assignment
    {
        // Additional member variable specific to Writing assignments
        private string _title;

        // Constructor
        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)  // Call base class constructor
        {
            _title = title;
        }

        // Method to get writing information
        public string GetWritingInformation()
        {
            return $"{_title} by {_studentName}";
        }
    }
}