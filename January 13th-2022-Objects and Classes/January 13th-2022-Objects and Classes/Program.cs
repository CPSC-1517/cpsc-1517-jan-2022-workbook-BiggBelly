using System;
using System.Text.Json;
using System.IO;
using January_13th_2022_Objects_and_Classes;//gives reference to the location of classes within the specified namespace
                                            //this allows the developer to avoid having to use a fully qualified name every time a reference is made to a class in a namespace




Employment Job = CreateJob ();//

ResidentAddress Address = CreateAddress();

//create a person
Person Me = CreatePerson( Job, Address);

if (Me != null)
{
 DisplayPerson(Me);
}


//ArrayReview(Me);

#region CSV Read and Write File 
//string pathname = CreateCSVFile();
//string pathname = "../../../Employment.dat";

//Console.WriteLine("\n Results of parsing the incoming CSV Employment data file\n");
//List<Employment>Jobs = ReadCSVFile(pathname);
//Console.WriteLine("\n Results of good parsed the incoming CSV Employment data file\n");
//foreach (Employment employment in Jobs)
//{
//DisplayString(employment.ToString());
//}
string Jsonpathname = "../../../Employee.json";
SaveAsJson(Me,Jsonpathname);
Person You = ReadAsJson(Jsonpathname);
DisplayPerson(You);
#endregion

static void DisplayString(string text)
{
    Console.WriteLine(text);
}   
static void DisplayPerson(Person Me)
{
  
    //DisplayString($"{Me.FirstName}{person.LastName}");
    //DisplayString($"{person.Address.ToString()}");
    Console.WriteLine("{0},{1},{2}",Me.FirstName,Me.LastName,Me.Address);// here

    //in our example ,the Person constructor ensures that EmploymentPosition exists 
    // (List was declared);this makes the need for the null mute 
    //if (person.EmploymentPositions != null)
    //{
        //the following loop is a forward moving pre test loop\
        // what it checks is "is there another link element to look at"
        // if yes - then use the element- if no then exit the loop 
          foreach(var position in Me.EmploymentPositions)
          {
            DisplayString(position.ToString());
          }
        // a List<T> can actually be manipulated like an array 
        // is a pre - test loop But does not check for a missing list<T>
        //in our example ,the Person constructor ensures that EmploymentPosition
        // exists (list was declared ); this makes the need for the null note
        //for (int i = 0; i < person.EmploymentPositions.Count; i++)
       // {
            //DisplayString(person.EmploymentPositions[i].ToString());
        //}

       // if (person.EmploymentPositions.Count > 0)
        //{
            //int x = 0;
            // is a post test loop 
            //do
            //{
                //DisplayString(person.EmploymentPositions[x].ToString());
               // x++;
            //} while (x < person.EmploymentPositions.Count);
       // }
   // }
   
}

Employment  CreateJob()
{
    Employment Job = null;//a reference to a variable capable of holding an instance Employment
                   //its initial value will be null
    try
    {
        Job = new Employment();
        //DisplayString($"default good job,{Job.ToString()}");//default constructor
  
        Job = new Employment("Boss", SupervisoryLevel.Owner, 20);//greedy constructor
       // DisplayString($"greedy good job,{ Job.ToString() }");

        //checking exceptions
        //bad data - check for null or whitespace on title
        //Job = new Employment("", SupervisoryLevel.Owner, 20);
        //bad data for year
       // Job = new Employment("boss", SupervisoryLevel.Owner, 6.5);

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
   // DisplayString($"default Address{Address.ToString()}");
    Address = new ResidentAddress(10767, "106 st NW", null, null,"Edmonton", "Alberta");
   // DisplayString($"greedy default Address,{Address.ToString()}");
    return Address;
}
Person CreatePerson(Employment job,ResidentAddress address)
{
    List<Employment> Jobs = new List<Employment>();
    Person thePerson = null;
    try
    {
        // create a good person using a greedy constructor no employment list
        //thePerson = new Person("AndyNoJob", "Taschuk", null, address);
      

        // create a good person using a greedy constructor with an empty employment list 
      
       // thePerson = new Person("AndyEmpty", "Taschuk", Jobs, address);

        // create a good person using a greedy constructor with a job list
      
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.Entry, 7.8));
        Jobs.Add(job);
         thePerson = new Person("Andy with employment", "Taschuk",Jobs, address);

        //exception testing
        // no first name
        // thePerson = new Person(null, "taschuk", Jobs, address);
        //no second name
        // thePerson = new Person("andy", null,Jobs, address);

        //can i change the first name using an assignment statement
        ////the first name is a private set / you are not allowed to use a private set 
        ///on the receiving side of an assignment
        // thePerson.FirstName = "New Name";
        // can i use a behaviour (method) to change the contents of a private set
        // thePerson.ChangeName("Lowand","Behold");

        // can i add another job after the person instance was created
        // thePerson.AddEmployment(new("DP IT", SupervisoryLevel.DepartmentHead, 0.8));

        // i can change the public field address directly 
        // ResidentAddress oldaddress = thePerson.Address;
        //oldaddress.City = "Vancouver";
        // thePerson.Address = oldaddress;
    }
    catch (ArgumentException ex) //specific exception message
    {

        DisplayString(ex.Message);
    }
    catch(Exception ex)//general catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return thePerson;
}
 void ArrayReview(Person person) 
  {
    //declare a single dimensional array size 5
    //in this declaration the value in each element is set to the 
   // datatypes default (numeric ->0)
   
    int[] array1 = new int[5];// one can use a literal for the size
    PrintArray(array1, 5, "declare int array size of 5");

    //declare and set array elements
    int[] array2 = new int[] {1,2,4,8,16};
    PrintArray(array2, 5, "declare int array size using a list of supplied values");

    //alternate syntax
    //size of the array can be determined using the method.Count() of the array collection
    // using the inherited class IEnumerable (array class derived from thr base class IEnumerable
    // which is derived from its base Collections
    // size of the array can be determined using the read only property (just has a get{}) of the
    // array class called .Length

    int[] array3 = new int[] { 1, 3, 6, 12, 24 };
    PrintArray(array3,array3.Count(), "declare int array with just a list of supplied values");

    //travsering to an array of elements
    //remember that the array when declared is physically declared in memory 
    // each element (cell) has a given value ,even if it is the data type default 
    //when you are adding to an array you are really just altering the element value

    //logical counter for your array size to indicate the "valid meaningful" values for processing 
    int lsarray1 = 0;
    int lsarray2 = array2.Count();// IEnumerable method
    int lsarray3 = array3.Length;  // Array read only property 

    Random random = new Random();
    int randomvalue = 0;
    while (lsarray1 < array1.Length)
    {
        randomvalue = random.Next(0, 100);
        array1[lsarray1] = randomvalue;
        lsarray1++;
    }
    PrintArray(array1, lsarray1, "Array load with random values");

    //Alter an element randomly selected to a new value
    int arrayposition = random.Next(0,array1.Length);
    randomvalue = random.Next(0, 100);
    array1[arrayposition] = randomvalue;
    PrintArray(array1, lsarray1, "randomly replace an array value");

    //remove an element from an array
    // move all array elements into positions greater than the removed element position "up one"
    // assume we are removing element 3 (index 2)
    int logicalelementnumber = 3;
    for (int index = logicalelementnumber -1; index < array1.Length -1; index++)//or -- in front of logicalelementnumber
    {
        array1[index] = array1[index + 1];
    }
    lsarray1--;
    array1[array1.Length - 1] = 0;
    PrintArray(array1, array1.Length, "remove an array value");

}
void PrintArray(int[] array, int size, string text) 
  {
    Console.WriteLine($"\n {text} \n");
    //item represents an item in an array 
    // array is your collection (array[])
    //processing will be start at 0 and end at 1
    foreach (var item in array)
    {
       Console.Write($"{item},");
    }
    Console.WriteLine("\n");
    for (int index = size -1; index >=0 ; index--)
        //using the 4 loop this display output the array back to front 
    {
        Console.Write($"{array[index]},");
    }
    Console.WriteLine("\n");
  }

string CreateCSVFile()
{
    string pathname = "../../../Employment.dat";
    try 
    { 
        List<Employment> Jobs = new List<Employment>();

       Jobs.Add(new Employment("lazy", SupervisoryLevel.Entry, 0.1));
       Jobs.Add(new Employment("trainee", SupervisoryLevel.Entry, 0.5));
       Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 3.5));
       Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
       Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
       Jobs.Add(new Employment("worker", SupervisoryLevel.Supervisor, 6.0));
       Jobs.Add(new Employment("worker", SupervisoryLevel.DepartmentHead, 2.1));

        //create a list of comma separated value strings
        //the contents of each string will be 3 values of employment 
        // in .netcore when declaring an instance of a class it is now not necessary to specify the class name after the new
        List<string> csvLines = new();

        //place all the instances of employment into the list<string>
        foreach(var item in Jobs) 
        {
            //item represents an instance of employment in the collection jobs
            //.ToString() is the override method in employment that returns call Employment instance
            // value as comma separated values 

            csvLines.Add(item.ToString());
        }

        // TESTING FOR BAD CSV DATA

        csvLines.Add($"{SupervisoryLevel.Entry},4.5");//missing value error
        csvLines.Add($",{SupervisoryLevel.Owner},4.5");//missing text error on title
        csvLines.Add($"Bad Years,{SupervisoryLevel.DepartmentHead},BOB");// non numeric value for years
        csvLines.Add($"Bad Years,{SupervisoryLevel.DepartmentHead},-4.6");// negative value for years


        // write to a csv file requires the System.IO namespace
        // writing a file will default the output to the folder that contains the executing.exe file 
        // there are several ways to output this file such as using SteamWriter and using the file class
        // within the file class there is a method that outputs a list of strings all within one command
        // there is no need for a Streamwriter instance
        // the pathname of the method at minimum must be the filename
        // the pathname can redirect the default location by using relative addressing with the filename

        File.WriteAllLines( pathname,csvLines);
        Console.WriteLine($"\n Check out the CSV file at: {Path.GetFullPath(pathname)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return Path.GetFullPath(pathname);
}
   

List<Employment> ReadCSVFile(string pathname)
{
    List<Employment> inputList = new List<Employment>();
    //reading a csv file is similar to writing. One can read all lines at one time >there is no need 
    // for a Steamreader.One concern would be the size of the expected input file 
    try
    {
        string[] csvFileInput = File.ReadAllLines(pathname);

        //create a reusable instance of Employment 
        Employment job = null;
        //item represent a line(record) in the incoming data
        //attempt to process EACH line whether any of the incoming lines have an error or not
        // THUS you will need to manage any errors on the individual line as you process that line
        // and be able to continue to the next line
        foreach(var line in csvFileInput) 
        {
            try
            {
                bool returnBool= Employment.TryParse(line, out job);
                //returned value is already boolean value:it is already true or false
                // there is no need to use a relative operator condition to test the field
                // (returnedBool == true) is not necessary
                // a relative operator condition Resolves to true or false 
                if(returnBool)
                {
                    inputList.Add(job); 
                }
            }
            catch (FormatException ex)
            {

                Console.WriteLine($"Format Error:{ex.Message}"); 

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Argument Invalid Error:{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Processing Parse Error:{ex.Message}");
            }
        }
    }
    catch (IOException ex)
    {

        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }
    return inputList;

}

void SaveAsJson(Person me,string pathname)
{
    // the term use to read and write Json files is Serialization
    // the classes use are referred to as serializers
    // with writing we can make these files produced more redable by using indentation
    //Json is very good at using object and properties however,it needs help /prompting to work better with fields
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true,
    };
    try
    {
        //Serilization
    //produce of serilization is a string 
    string jsonstring = JsonSerializer.Serialize<Person>(me, options);
    // output the json string to your file indicted in the path 
    File.WriteAllText(pathname, jsonstring);


    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
       
    }
    
}
Person ReadAsJson(string pathname)
{
    Person you = null;
    try
    {
        //bring in the text from the file 
        string jsonstring = File.ReadAllText(pathname);

        // use the deserializer to unpack the json string into the expected structure(<Person>)

        you = JsonSerializer.Deserialize<Person>(jsonstring);
    }
    catch ( Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return you;
}
