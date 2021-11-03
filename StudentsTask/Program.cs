using System;

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
                        Controller.GetInstance().AscStudentList();
                        break;
                    case "desc":
                        Console.WriteLine("Sorting students in descending order");
                        Controller.GetInstance().DescStudentList();
                        break;
                    case "delete":
                        Console.WriteLine("Deleting student with lowest average grade");
                        Controller.GetInstance().DeleteStudentWithLowestAvgGrade();
                        break;
                    default:
                        Controller.GetInstance().CreateStudent(inputString);
                        Console.WriteLine("Student inserted into database successfully");
                        break;
                }
            }
        }
    }
}
