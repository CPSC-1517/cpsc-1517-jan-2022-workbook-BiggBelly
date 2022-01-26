using System;

using January_13th_2022_Objects_and_Classes;//gives reference to the location of classes within the specified namespace
//this allows the developer to avoid having to use a fully qualified name every time a reference is made to a class in a namespace




// See https://aka.ms/new-console-template for more information
DisplayString("Hello, World!");
//fuly qualified name 
//PracticeConsole.Data.Employment job = CreateJob()
Employment job = CreateJob();





static void DisplayString(string text)
{
    Console.WriteLine(text);
}

Employment CreateJob()
{
    Employment defaultJob = new Employment();
    DisplayString($"good job{ defaultJob.ToString() }");
    return defaultJob;
}

