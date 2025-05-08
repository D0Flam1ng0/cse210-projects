using System;

class Program
{
    static void Main(string[] args)
    {
         Job job = new Job();
        job._jobTitle = "Software Engineer";
        job._company = "KPMG";
        job._startYear = 2004;
        job._endYear = 2007;

        Job jobs = new Job();
        jobs._jobTitle = "Manager";
        jobs._company = "Krutilla & Associates";
        jobs._startYear = 2007;
        jobs._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Lucille Anderson";

        myResume._jobs.Add(job);
        myResume._jobs.Add(jobs);

        myResume.Display();
    }
}