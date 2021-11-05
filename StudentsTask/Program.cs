using System;
using System.Threading;

namespace StudentsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To insert a new student to the database please type the following information separated by a comma sign (,):");
            Console.WriteLine("Id,Name,Surname,Date of birth(mm/dd/yyyy),Exam1,Exam2,Exam3");
            Console.WriteLine("If you want to list the students in ascending mark order type 'asc'");
            Console.WriteLine("If you want to list the students in descending mark order type 'desc'");
            Console.WriteLine("If you want to delete the student with the lowest mark average type 'delete'");
            

            while (true)
            {
                string inputString = Console.ReadLine();
                switch (inputString.ToLower())
                {
                    case "asc":
                        Console.WriteLine("Sorting students in ascending order");
                        Thread t1 = new Thread(Controller.GetInstance().AscStudentList);
                        t1.Start();
                        break;
                    case "desc":
                        Console.WriteLine("Sorting students in descending order");
                        Thread t2 = new Thread(Controller.GetInstance().DescStudentList);
                        t2.Start();
                        break;
                    case "delete":
                        Console.WriteLine("Deleting student with lowest average grade");
                        Thread t3 = new Thread(Controller.GetInstance().DeleteStudentWithLowestAvgGrade);
                        t3.Start();
                        break;
                    default:
                        Thread t4 = new Thread(() => Controller.GetInstance().CreateStudent(inputString));
                        t4.Start();
                        Console.WriteLine("Student inserted into database successfully");
                        break;
                }
            }
        }
    }
}
