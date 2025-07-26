using System;

#pragma warning disable CA1050 // Declare types in namespaces
public class Job
#pragma warning restore CA1050 // Declare types in namespaces
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} - {_endYear}");
    }
}
