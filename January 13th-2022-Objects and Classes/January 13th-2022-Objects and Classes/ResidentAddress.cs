using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_13th_2022_Objects_and_Classes
{
    //struct is another developer defined data type
    //looks like a class definition
    // struct however is a value type storage where as class is a referance type storage
    //struct can have fields.properties,constructors and methods(behaviours)

    public struct ResidentAddress
     
    {
        //my fields
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        //my properties
        public string Unit
        {
            get { return _Unit; }   
            set { _Unit = value; }
        }
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
               _City = value;
            }

        }
        public ResidentAddress(int Number,string Address1,string Address2,string Unit,string City,string ProvinceState)
        {
            //concern: parameter name is exactly the same as the struct /class field/property
            //solution: use the keyword this.on your instance item
            //the keyword this references to the instance that you are currently accessing in your program 
            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.ProvinceState = ProvinceState;
            _Unit = Unit;
            _City = City;
        }
        //note-no default constructor was created because i wish the program to assign the adress with all the necessary data at creation time 
        public override string ToString()
        {
            return $"{Number}, {Address1} ,{Address2} ,{Unit},{City},{ProvinceState}";
        }


    }//eopublic struct

    
    
}//eon
