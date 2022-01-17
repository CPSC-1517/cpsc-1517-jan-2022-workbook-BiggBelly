using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_13th_2022_Objects_and_Classes
{
   
    public class Employment
    {
      


        //an instance of this class will hold data about a person's employment
        //create our instances or fields -these will hold our data about a person's employment
        //the code of this class is the definition of the data
        //the characteristics(data) of the class
        //title,supervisor level,years of employment within the company 
        //the 4 componets of a class def are
        //1-data fields,
        //2-properties,
        //3-constructor,
        //4-methods(behaviour)

        //data fields-these are storage areas in your class-treated as variables 
        //these may be public or private 
        //public is read only 
        private string _Title;
        private double _Years;


        //properties-these are access techniques to  retrieve or set data in your class without direct touching the storage data field\

        //fully implemented property 
        //a- a declard storage area(data field)
        //b- a declared property signature 
        //c- a coded "get" method 
        //d- an optional coded set "method"

        //when do you want to use a fully implemented property:
        // a)if you are storing the associate data in an explicitly declared data field
        // b)if you are during validation access incoming data
        // c)creating  a property that generates output from other data sources within the class(read only properties)
        // these properties would have only a get method 

        public string Title
        {
            get 
            {
                //accessor 
                //the get method will return the contents of our data fields
                //as an expression 
                return _Title;
            }
            set
            {
               
                //mutator 
                //the set method receives an incoming value and places it in the associated field 
                //during the setting you may want to validate the incoming data
                //you may wish to add some type of logic processing using the data to set another field 
                // the incoming data is referred to using the keyword "value"
                // ensure the incoming data is not null or whitesp
                if (string.IsNullOrWhiteSpace(value))
                {
                   throw new ArgumentNullException("Title is a required piece of data");
                }
                else//beyond this point data is consdidered valid   
                {
                   _Title = value;
                }
            }
        }//eop title
               
          
    

        //auto implemented property 

        //these properties only differ in syntax
        // each propery is responsible for a single piece of data 
        // these properties do not reference a declared private data member 
        // the system generates an internal storage area  of the return data type
        // the system manages the internal  storage for teh accessor or mutator 
        // this is no additional logic applied to the data value 

        //using an enum for this field will automatically restrict the values
         public int Level { get; set; }
      

        public double Years 
        {
            get
            {
                return _Years;
            }
            set
            {
                _Years = value;
            }
        }//eop Years

        //this property Years could be coded as either fully implemented property or as auto implemented property 

        //constructors 
        //is to intiliaze the physical object (instance) during its creation
        // the result of creation is to ensure that the coder gets an instance in a known state
        // if your class definition has no constructor coded,then the data members
        // auto implented properties are set to the c sharp default data type value
        // you can code one or more constructors in your class definition
        // if you code a construvtor for the class,you are respondible for all constructors used by the class
        //generally - we code by 2 types of constructors
        // default constructor:this constructor does not take in any paramaters
        //Greedy:(over loaded constructor)this constructor has a list pf parameters,one for each property ,declare for incoming data
        //syntax:accesstype classname([list of parameters]){constructor code body}
        //you do not call a constructor directly -called using the new operator

        //Default constructor
        public Employment()
        {
            //constructor body 
            //a) empty 
            //b) you could assign literal values to your properties
            Level = 1;
            Title = "uknown";
        }

        //greedy construcor 
        public Employment (string title,int level ,double years)
        {
            // constructor body 
            //a parameter for each property
            //you could do validation within the constructor instead of the property
            // validation for read only data members
            //validation for a property
            _Title = title;
            _Years = years;
            Level = level;

        }

        //Behaviours( aka methods)
        // are no different than methods elsewhere
        //syntax accesstype [static] return data type Behaviour Name ([list of parameters])
        //code body 
        //there may be times you wish to obtain all the data in your instance
        //all at once for display 
        // generally to accomplish this your class over rides the.ToString() method of 

        public override string ToString()
        {
            //comma separate value string (csv)
            return $"{Title},{Level},{Years}";
        }

        public void SetEmployeeResponsibilityLevel(int level)
        {
            if (string.IsNullOrWhiteSpace)
                throw new Exception("Employee resposibility level must be positive");
        }
        



    }//eoc
}//eon
