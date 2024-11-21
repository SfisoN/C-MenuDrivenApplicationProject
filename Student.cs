using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeterriaDiscountApp
{
    internal class Student
    {
        public string Name { get { return name; } set { name = value; } }               // create public access methods which do not contain actual data stored in program
        public string Surname { get { return surname; } set { surname = value; } }
        public string FName;
        public int Years { get { return years; } set { years = value; } }
        public bool Residence { get { return residence; } set { residence = value; } }

        public int RYears { get { return rYears; } set { rYears = value; } }
        public double MAllowance { get { return mAllowance; } set { mAllowance = value; } }  
        public double Average { get { return average; } set { average = value; } }

        private string name, surname, fName;                // make all variables private
        private int years, rYears;
        private bool residence;
        private double mAllowance, average; 

        public Student(string n, string s, bool r, int y, int rY, double allowance, double avg) 
        {
            this.Name = n;
            this.Surname = s;
            this.FName = n+" "+s;     // set fullname as firstname and surname
            this.Residence = r;
            this.Years = y;
            this.RYears = rY;
            this.mAllowance = allowance;
            this.Average = avg; 
        }
        
        public Student() { }

        public override string ToString()
        {
            return $"Fullname:{FName}\tResident:{Residence}\tYears:{Years}\tNumber of Residence Years:{RYears}\tAllowance:R{MAllowance}+Average:{Average}";  
        }


    


public int CheckDiscount(string studentName, bool stayedOnCampus, int yearsOnCampus, int average, int allowance)
{
    int discount = 0;

    if (stayedOnCampus = true && yearsOnCampus > 1 && average >= 85 && allowance < 1000)
    {
        Console.WriteLine("Student qualifies for discount");

        discount = 100;
        Console.WriteLine($"{studentName} \n{stayedOnCampus} \n{yearsOnCampus} \n{average} \n{allowance} \n{discount}");

    }
    else
    {
        Console.WriteLine("Student does not qualifies for discount");
        discount = 0;
        Console.WriteLine($"{studentName} \n{stayedOnCampus} \n{yearsOnCampus} \n{average} \n{allowance} \n{discount}");
    }

    return discount;
}
    }
}