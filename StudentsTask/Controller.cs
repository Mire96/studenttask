using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTask
{
    public class Controller
    {
        private static Controller instance { get; set; }
        private StudentService studentService { get; set; }

        private List<Student> studentList { get; set; }
        private Controller()
        {
            studentService = new StudentService();
        }

        public static Controller GetInstance()
        {
            if (instance == null)
            {
                instance = new Controller();
            }
            return instance;
        }

        public List<Student> GetAllStudents()
        {
            return studentService.GetAllStudents();
        }

        internal void CreateStudent(string inputString)
        {
            string[] studentString = inputString.Split(",");
            if (studentString.Length != 7)
            {
                Console.WriteLine("Please input the student information in the correct format, separated by a comma sign");
                Console.WriteLine("Id,Name,Surname,Date of birth(mm/dd/yyyy),Exam1,Exam2,Exam3");
                return;
            }

            studentService.CreateStudent(studentString);
        }

        internal void AscStudentList()
        {
            this.studentService.AscStudentList();
        }

        internal void DescStudentList()
        {
            this.studentService.DescStudentList();
        }

        internal void DeleteStudentWithLowestAvgGrade()
        {
            this.studentService.DeleteStudentWithLowestAvgGrade();
        }
    }
}
