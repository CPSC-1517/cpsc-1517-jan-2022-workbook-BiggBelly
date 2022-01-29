using System;

using January_13th_2022_Objects_and_Classes;//gives reference to the location of classes within the specified namespace
                                            //this allows the developer to avoid having to use a fully qualified name every time a reference is made to a class in a namespace




// See https://aka.ms/new-console-template for more information

//fully qualified name 
//PracticeConsole.Data.Employment job = CreateJob()
DisplayString("Hello world");

Employment Job= CreateJob ();//
ResidentAddress Address = CreateAddress();   




static void DisplayString(string text)
{
    Console.WriteLine(text);
}

Employment  CreateJob()
{
    Employment Job = null;//a reference to a variable capable of holding an instance Employment
                   //its initial value will be null
    try
    {
        Job = new Employment();
        DisplayString($"default good job,{ Job.ToString() }");//default constructor
        //checking exceptions
        Job = new Employment("Boss", SupervisoryLevel.Owner, 20);//greedy constructor
        DisplayString($"greedy good job,{ Job.ToString() }");
        //bad data - check for null or whitespace on title
        //Job = new Employment("", SupervisoryLevel.Owner, 20);
        //bad data for year
        Job = new Employment("boss", SupervisoryLevel.Owner, 6.5);

    }
    catch(ArgumentException ex) //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)//general catch all
    {

        DisplayString("Run time error: " + ex.Message);
    }
       return Job;
}
ResidentAddress CreateAddress()
{
   ResidentAddress Address = new ResidentAddress();
    DisplayString($"default Address{Address.ToString()}");
    Address = new ResidentAddress(10767, "106 st NW", null, null,"Edmonton", "Alberta");
    DisplayString($"greedy default Address{Address.ToString()}");
    return Address;
}

