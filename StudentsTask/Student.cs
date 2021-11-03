using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTask
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Exam1 { get; set; }
        public int Exam2 { get; set; }
        public int Exam3 { get; set; }

        public double AverageMark { get; set; }

        public Student(int id, string name, string surname, DateTime dateOfBirth, int exam1, int exam2, int exam3)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Exam1 = exam1;
            Exam2 = exam2;
            Exam3 = exam3;
            AverageMark = CalculateAverageMark();
        }

        public double CalculateAverageMark()
        {
            double average = (Exam1 + Exam2 + Exam3) / 3.0;
            return average;
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Surname}, Average mark: {AverageMark}";
        }
    }
}
