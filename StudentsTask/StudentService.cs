using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTask
{
    public class StudentService
    {
        private StudentRepository studentRepository { get; set; }

        public StudentService()
        {
            this.studentRepository = new StudentRepository();
        }

        internal void CreateStudent(string[] studentString)
        {
            try
            {
                int id = Int32.Parse(studentString[0]);
                string name = studentString[1];
                string surname = studentString[2];
                DateTime dateOfBirth = DateTime.Parse(studentString[3]);
                int exam1 = Int32.Parse(studentString[4]);
                int exam2 = Int32.Parse(studentString[5]);
                int exam3 = Int32.Parse(studentString[6]);
                Student student = new Student(id, name, surname, dateOfBirth, exam1, exam2, exam3);
                studentRepository.SaveStudent(student);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect formatting. Check if you've inputed the numbers or date in the correct format");
                return;
            }


        }

        internal List<Student> GetAllStudents()
        {
            return this.studentRepository.SelectAll();
        }

        

        internal void DeleteStudentWithLowestAvgGrade()
        {
            List<Student> students = this.studentRepository.SelectAll();
            Student minGradeStudent = students.ElementAt(0);
            foreach (Student student in students)
            {
                if (student.AverageMark < minGradeStudent.AverageMark)
                {
                    minGradeStudent = student;
                }
            }
            this.studentRepository.Delete(minGradeStudent);
            Console.WriteLine("Student deleted successfully");

        }

        internal void AscStudentList()
        {
            List<Student> students = this.studentRepository.SelectAll();
            Console.WriteLine("Unsorted students");
            PrintStudentList(students);

            ShellSortAsc(students);
            Console.WriteLine("Sorted Students");
            PrintStudentList(students);

        }

        internal void DescStudentList()
        {
            List<Student> students = this.studentRepository.SelectAll();
            Console.WriteLine("Unsorted students");
            PrintStudentList(students);

            ShellSortDesc(students);
            Console.WriteLine("Sorted Students");
            PrintStudentList(students);

        }

        private void PrintStudentList(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }

        private void ShellSortAsc(List<Student> students)
        {
            int n = students.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    Student temp = students.ElementAt(i);

                    int j;
                    for (j = i; j >= gap && students.ElementAt(j - gap).AverageMark > temp.AverageMark; j -= gap)
                    {
                        students.RemoveAt(j);
                        students.Insert(j, students.ElementAt(j - gap));
                    }

                    students.RemoveAt(j);
                    students.Insert(j, temp);
                }
            }
        }
        
        private void ShellSortDesc(List<Student> students)
        {
            int n = students.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    Student temp = students.ElementAt(i);
                    int j;

                    for (j = i; j >= gap && students.ElementAt(j - gap).AverageMark < temp.AverageMark; j -= gap)
                    {
                        students.RemoveAt(j);
                        students.Insert(j, students.ElementAt(j - gap));
                    }

                    students.RemoveAt(j);
                    students.Insert(j, temp);
                }
            }
        }

    }
}
