using System;

public class Job
{
    // Change from private to public
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;
    
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}