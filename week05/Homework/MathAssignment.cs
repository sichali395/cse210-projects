using System;

namespace Homework
{
    // Derived class for Math assignments
    public class MathAssignment : Assignment
    {
        // Additional member variables specific to Math assignments
        private string _textbookSection;
        private string _problems;

        // Constructor
        public MathAssignment(string studentName, string topic, string textbookSection, string problems)
            : base(studentName, topic)  // Call base class constructor
        {
            _textbookSection = textbookSection;
            _problems = problems;
        }

        // Method to get homework list
        public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problems {_problems}";
        }
    }
}