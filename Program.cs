using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;     // import collections library to access lists
using CafeterriaDiscountApp;

namespace CafeteriaDiscountApp
{  
     class Program
    {
        public List<Student> students = new List<Student>();       // create a new list to store all students
        public List<String> discountStudents = new List<String>();      // create a list to store all students qualifying for discount
        enum Menu{ CaptureDetails =1, CheckDiscountQualification =2, ShowQualificationStats =3, Exit =4 };  // create Menu for switching between options
        public List<Student> GetStudents()
        {
            return students;     // return the list of all Students
        }

        public List<string> getDiscountStudents() 
        {
            return discountStudents;    // return the list of qualified students
        }

        static void Main(string[] args)
        {
            Program obj = new Program();            // create object to access student lists
            Console.WriteLine("Welcome to the Belgium Campus Cafeteria Discount Application");     // display welcome message
            do {
                Console.WriteLine("Enter a number to proceed:\n1 = Capture Details\n2 = Check Discount Qualification \n3 = Show Qualification Stats\n4 = Exit");
                int option = int.Parse(Console.ReadLine());

                switch (((Menu)option))         // switch between options of enum menu
                {
                    case Menu.CaptureDetails:    // Capture Details option selected
                        CaptureDetails(obj.GetStudents());      // call the capture method and pass the student list into it
                        break;

                    case Menu.CheckDiscountQualification:
                        DisplayQualification(obj.GetStudents(), obj.getDiscountStudents()); // call the qualification display method and pass the student & qualified student list into it
                        break;

                    case Menu.ShowQualificationStats:
                        ShowStats(obj.GetStudents(), obj.getDiscountStudents());         // call the qualification display method and pass the student & qualified student list into it
                        break;

                    case Menu.Exit:
                        Console.WriteLine("Thank you for using our application");     // display a thank you message
                        Environment.Exit(0);                                         // close the application
                        break;
                }
                Console.WriteLine("Do you want to make another transaction? Enter Y for Yes and N for No");     // prompt user 
            } while (Console.ReadLine().ToUpper() == "Y");              // wait for user input to decide whether to end application or go back to menu


          

            Console.ReadKey();              // make sure the application doesn't close unless a key is pressed
        }
        
        public static void CaptureDetails(List<Student> students)     // create details capture method
        {
            
            do    // run this code once then wait for condition to decide whether or not to loop again
            {
            bool resident = false;     // create boolean for residence 
            Console.WriteLine("Please enter your name");       
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Are you a resident?");
                string response = Console.ReadLine();
                if ((response.ToUpper() == "Y") || (response.ToUpper() == "YES"))     // conditon to be seen as resident
                {
                    resident = true;                                        // set to true if yes is entered
                }
                else 
                {
                    resident = false;                                       // set to false if no is entered
                }
            

            Console.WriteLine("Please enter the number of years you've been on Campus.");
            int years = int.Parse(Console.ReadLine());
            int rYears;
            if (resident == true)                   // ask for number of years at residence if the student is a resident, else default to 0 years
            {
                 Console.WriteLine("Please enter the number of years you've been at your current residence");
                    rYears = int.Parse(Console.ReadLine());
            }else 
            {
                 rYears = 0;
            }
            

            Console.WriteLine("Please enter your monthly allowance");
            double mAllowance = double.Parse(Console.ReadLine());

          
                Console.WriteLine("Please enter your average.");
                double average = double.Parse(Console.ReadLine());



                Student student = new Student(name,surname,resident, years, rYears, mAllowance,average);
             students.Add(student);              

            Console.WriteLine("Do you want to capture any more applicants? Enter Y for Yes and N for No");          // prompt user

            } while (Console.ReadLine().ToUpper() == "Y") ;         // wait for user response to decide whether to continue entering details
        }

        
        
        public static void DisplayQualification(List<Student> students, List<String> qualifiedStudents) 

        {
            foreach (Student s in students)         // check every student in Student List
            {
                if ((s.Average>=85) && (s.MAllowance<=1000) && (s.RYears>1))    // check if student meets all Discount Criteria
                {
                    qualifiedStudents.Add($"{s.FName}\t{s.Residence}\t{s.Years}\t{s.RYears}\t{s.MAllowance}\t{s.Average}");  // if true, add them to new list which stores discount students
                }
            }
            Console.WriteLine($"Fullname:\tResident:\tYears:\tNo. Year @Res:\tAllowance:\tAverage:");     // add all qualified students onto the console
            foreach(string student in qualifiedStudents) 
            {               
               Console.WriteLine(student);
            }
        }

        public static void ShowStats(List<Student> allStudents, List<String> discStudents) 
        {
            int total = allStudents.Count;     // take the total number of records in students list
            int discounted = discStudents.Count;   // take the total number of records in discount students list
            int rejected = total - discounted;      // subtract rejected students from the total amount of students
            double percentage = (discounted/total) * 100;       // create a percentage figure of the acceptance rejected rate
            Console.WriteLine("Qualified:\tRejected:\tTotal\tPercentage(Qualified:Non-Qualified):\n");          // display stats on console
            Console.Write($"{discounted}\t{rejected}\t{total}\t{percentage}%\n");

        }
    }
}
    
