using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_13th_2022_Objects_and_Classes
{
    public class Person
    {
        // example of a composite class
        //each instance of this class will represent an individual
        // First name,Last name ,resident address and employment positions   
        // a composite class uses other classes in its definition 
        // a composite class is recongnized with the phrase "has a" class
        // this class of Person "has a "resident address

        //an inherited class extends another class in  its definition
        //  an inherited class is recognized with the phrase "is a" class
        // assume a general class called "Transportation "-then we can extend this class to more specific classes    
        // public class Vehicle :Transportation
        // public class Bike :Transportation
        // public class Boat :Transportation

        // my fields 
        private string _FirstName;
        private string _LastName;

        //my properties
        public string FirstName  
        { 
            get 
            { return _FirstName; } 
            private set                
            {
              if (Utilities.IsEmpty(value)) 
              {
                    throw new ArgumentNullException("First name is required");
              }
              else
              { 
                _FirstName = value; 
              } 
            }
            
        }

        public string LastName 
        {
            get
            {
                return _LastName;
            }
            private set 
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("Last name is required ");
                }
                else
                {
                  _LastName = value; 
                }
                
            }
        }//eop

        //composition actually uses the other class as a property /field within the definition of the class defined  \

        public ResidentAddress Address;//in this example Address is a field (data member)- there is no get,set
        public List<Employment> EmploymentPositions { get; private set; }

       // public Person()//this is our default constructor
       // {
            //if an instance of List <T> is not created and assigned then the property will have an initial value of null
           // EmploymentPositions = new List<Employment>();

             //option 1  - assign a default value 
            //since first name and last name need to have values-you can assign default literals to the properties
           // FirstName = "uknown";
           // LastName = "unknown";
      // }

            //option 2- DO NOT code a default constructor
            //code only the greedy (overloaded) constructor
            // if the overloaded constructor is the only constructor for the class-then we can only use this for the class instance

        public Person(string firstname,string lastname,List<Employment>employmentpositions,ResidentAddress address)// overloaded constructor
        {
            FirstName = firstname;
            LastName = lastname;
            if (employmentpositions !=null)
            {
              EmploymentPositions = employmentpositions;
            }
            else//allows a null value and the class to have an empty list<T>
            {
                EmploymentPositions = new List<Employment>();              
            }
           
              Address = address;

        }
        public void ChangeName(string firstname,string lastname)
        {
            FirstName = firstname.Trim();
            LastName = lastname.Trim();
        }

        public void AddEmployment(Employment employment) 
        { 
            EmploymentPositions.Add(employment);
        }
     

    }//eoclass
}//eon
