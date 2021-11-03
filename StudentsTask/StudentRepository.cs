using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

namespace StudentsTask
{
    public class StudentRepository
    {

        internal void SaveStudent(Student student)
        {
            string connectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=studentdb;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string dateOfBirth = student.DateOfBirth.ToString("yyyy-MM-dd");
                string insertStudent = $"INSERT INTO student.student(id, name, surname, dateofbirth, exam1, exam2, exam3)VALUES ({student.Id}, '{student.Name}', '{student.Surname}', '{dateOfBirth}', {student.Exam1}, {student.Exam2}, {student.Exam3});";
                connection.Execute(insertStudent);
            }
        }

        internal List<Student> SelectAll()
        {
            string connectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=studentdb;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string selectStudents = $"SELECT * FROM student.student;";
                List<Student> students = (List<Student>)connection.Query<Student>(selectStudents);
                return students;
            }
        }

        internal void Delete(Student minGradeStudent)
        {
            string connectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=studentdb;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string deleteStudent = $"DELETE FROM student.student WHERE id = {minGradeStudent.Id};";
                connection.Execute(deleteStudent);
            }
        }
    }
}
