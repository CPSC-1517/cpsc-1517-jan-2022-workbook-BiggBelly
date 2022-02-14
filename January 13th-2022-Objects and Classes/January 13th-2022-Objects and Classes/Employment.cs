using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_13th_2022_Objects_and_Classes
{
    //internal class means can only be used within this project 
    public class Employment//any class within this project or any other project outside of the namespace can use this class  
    {

        //an instance of this class will hold data about a person's employment
        //create our instances or fields -these will hold our data about a person's employment
        //the code of this class is the definition of the data
        //the characteristics(data) of the class
        //title,supervisor level,years of employment within the company 
        //the 4 componets of a class definition are
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
                // ensure the incoming data is not null or whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data");
                }
                else//beyond this point data is consdidered valid   
                {
                    _Title = value;
                }
            }
        }//eopublic title   




        //auto implemented property 

        //these properties only differ in syntax
        // each propery is responsible for a single piece of data 
        // these properties do not reference a declared private data member 
        // the system generates an internal storage area  of the return data type
        // the system manages the internal  storage for teh accessor or mutator 
        // this is no additional logic applied to the data value 

        //using an enum for this field will automatically restrict the values this property can contain
        public SupervisoryLevel Level { get; set; }


        public double Years
        {
            get
            {
                return _Years;
            }
            set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException("Year cannot be a negative value");
                }
                else
                {
                   _Years = value;
                }
                
              
            }
        }//eop Years

        //this property Years could be coded as either fully implemented property or as auto implemented property 

        //constructors 
        //is to intiliaze the physical object (instance) during its creation
        // the result of creation is to ensure that the coder gets an instance in a known state
        // if your class definition has no constructor coded,then the data members
        // auto implented properties are set to the c sharp default data type value
        // you can code one or more constructors in your class definition
        // if you code a constructor for the class,you are respondible for all constructors used by the class
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
            Level = SupervisoryLevel.Supervisor;
            Title = "uknown";
        }

        //greedy constructor 
        public Employment(string title, SupervisoryLevel level, double years)
        {
            // constructor body 
            //a parameter for each property
            //you could do validation within the constructor instead of the property
            // validation for read only data members
            //validation for a property
            
            Title = title;
            Level = level;
            Years = years;
        }

        //Behaviours( aka methods)
        // are no different than methods elsewhere
        //syntax accesstype [static] return data type Behaviour Name ([list of parameters])
        //code body 
        //there may be times you wish to obtain all the data in your instance
        //all at once for display 
        // generally to accomplish this your class over rides the.ToString() method of 

        public override string ToString()//a very common method 
        {
            //comma separate value string (csv)
            //the string is being created using string interpolation
             // $"string characters {fieldname}....."
            return $"{Title},{Level},{Years}";
            // or straight concatentation of strings 
            //return "Title" +"," Level + "," + Years.ToString();   
        }

        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            //you could validation within this method to ensure acceptable value
            if (level < 0) 
                throw new Exception("Employee resposibility level must be positive");
            else
            {
              Level = level;
            }
           
        }

        // the following method will receive a csv string of values that represent an instance of of Employment
        // the method will validate that there are sufficient values for an instance
        // will use primitive data type.Parse() to convert indicidually 
        // will return a load instance of the employment class 
        // will use the FormalException() if insufficient data is supplied 

        // as the instance is loaded on the return ,the Employment constructor will be used
        // thus any error generated by the constructor shall still be created 

        // this method will not retain any data 
        // this method will be a shared method (static)

        public static Employment Parse(string text)
        {
            // text is a string of csv values 
            // value 1,value 2 ,value 3 and so on 
            // step 1 - separate the string of values into individual values 
            // the result will be an array of strings 
            // each array represents a value 
            // the string class method.Split(delimiter) is used for this function 
            // a delimiter can be any c sharp recongized character
            // in a csv string,the delimiter character is a comma 

            string[] parts = text.Split(',');

            //step 2 - verify that sufficient values exist to create the Employment instance 
            if (parts.Length != 3)
            {
                throw new FormatException($"string is not in expected format,Missing Value.{text} ");

            }
            // step 3 return a new instance of the employment class 
            // create a new instance of the return statement 
            // as the  instance is being created,the Employmnet constructor will be used 
            // Any validation occuring during the constructor execution will still be done 
            // whether the logic is in the constructor OR in the individual property 
            // use the primitive .Parse () method already in their class 
            return new Employment(parts[0],(SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), parts[1]), double.Parse(parts[2]));
        }

        // the TryParse() method will receive a string and output an instance of employment via an output parameter
        // the method will return a boolean value indicating if the action with the method was successful
        // the action within the method will be to call the.Parse() method
        // this is the same concept of Parsing primitive datatypes already in c#
        // bool int.TryParse(text,output variable) --> int int.Parse(string)

        //static  is shared method
        public static bool TryParse(string text,out Employment result)
        {
            //create an initialized output return value
            result = null;
            bool valid = false;
            try
            {
                //the logic of the try is to do the Parse
                result=Parse(text);
                valid = true;
            }
            catch (FormatException ex)
            {

                throw new FormatException(ex.Message);
                   
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception($"TryParse Employment:{ex.Message}");
            }
            return valid;
        }


    }//eoc
}//eon
