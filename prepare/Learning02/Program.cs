using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2020;
        job1._endYear = 2026;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Hardware Engineer";
        job2._startYear = 1998;
        job2._endYear = 2010;

        Resume myResume = new Resume();
        myResume._name = "Nephi Zaugg";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.DisplayResumeDetails();
    }
}