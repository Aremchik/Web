using System;
using System.Collections.Generic;
using System.IO;
using oop_lab3;
using DataAccess;

namespace oop_lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University university = new();
            List<Student> loadedStudents = StudentsRepository.LoadStudents();

            Student student1 = new() { FirstName = "Иван", LastName = "Иванов", Age = 20, AverageGrade = 4.0};
            Student student2 = new() { FirstName = "Петр", LastName = "Петров", Age = 22, AverageGrade = 4.5 };
            Student student3 = new() { FirstName = "Иван", LastName = "Иванов", Age = 20, AverageGrade = 4.0 };
            Student student4 = new() { FirstName = "Дмитрий", LastName = "Петров", Age = 22, AverageGrade = 4.5 };

            university.AddStudent(student1);
            university.AddStudent(student2);
            university.AddStudent(student3);
            university.AddStudent(student4);

            StudentsRepository.SaveStudentData(university.GetData());

            foreach (Student student in loadedStudents)
            {
                university.AddStudent(student);
            }

            foreach (Student student in university.GetData())
            {
                Console.WriteLine(student.ShowStudentData());
            }

            Student foundStudent = university.FindStudents(1);
            Console.WriteLine("Найденный студент: " + foundStudent.ShowStudentData());
            

            university.RemoveStudent(1);
            StudentsRepository.SaveStudentData(university.GetData());
        }
    }

    public class Student
    {
        private string firstName = "";
        private string lastName = "";
        private int age;
        private double averageGrade;
        private int id;
        private static int incremented_id = 0;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0) { age = value; }
                else { Console.WriteLine("Возраст не может быть отрицательным"); }
            }
        }

        public double AverageGrade
        {
            get { return averageGrade; }
            set {
                if (value >= 0 && value <= 100) { averageGrade = value; }
                else { Console.WriteLine("Неверный средний балл"); }

            }
        }

        public int Id
        {
            get { return id; }
            set 
            { 
                id = incremented_id; 
                incremented_id = id + 1; 
            }
        }

        public string ShowStudentData()
        {
            return ($"{LastName} {FirstName} {age} лет ср. балл {AverageGrade}");
        }
    }

    public class University
    {
        public List<Student> students;

        public University()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (student != null) { 
                students.Add(student);
                student.Id++;
            }
            else { Console.WriteLine("Не может быть null"); }
        }

        public Student FindStudents(int id)
        {

            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
        public void RemoveStudent(int id)
        {
            Student student = FindStudents(id);

            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Студент {student.LastName} {student.FirstName} удален");
            }
            else { Console.WriteLine("Студент не найден"); }

        }
        public List<Student> GetData()
        {
            return students;
        }

    }
  
}   

namespace DataAccess
   { 
    public class StudentsRepository  
    {    
        private static string filePath = "D:\\prod\\Prilo\\Labs\\ConsoleApp2\\students.txt";
        public static List<Student> LoadStudents() 
        {   
            List<Student> students = new List<Student>();  
            using (StreamReader reader = new StreamReader(filePath))   
            {    
                string line;    
                while ((line = reader.ReadLine()) != null)  
                {  
                    string[] data = line.Split(' '); 
                    string firstName = data[0];
                    string lastName = data[1];
                    int age = int.Parse(data[2]);
                    double averageGrade = double.Parse(data[3]); 
                    
                    Student student = new Student() 
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        AverageGrade = averageGrade   
                    };
                    students.Add(student);  
                }  
            }     
            return students;
        }
        public static void SaveStudentData(List<Student> students)
        {
           using (StreamWriter writer = new StreamWriter(filePath))
           {
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.LastName} {student.FirstName} {student.Age} {student.AverageGrade} {student.Id}");
                }
           }
                Console.WriteLine("Сохранено");
            }

        }
    }
