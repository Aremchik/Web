using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Laba3
{
    using Laba3.UniversityManagement;
    using System;
    using System.Collections.Generic;
    using System.IO;

    namespace UniversityManagement
    {
        // Класс "Студент" для хранения информации о студенте
        public class Student
        {
            private string firstName;
            private string lastName;
            private int age;
            private double averageGrade;

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
                    if (value >= 0)
                        age = value;
                    else
                        throw new ArgumentException("Возраст не может быть отрицательным");
                }
            }

            public double AverageGrade
            {
                get { return averageGrade; }
                set { averageGrade = value; }
            }
        }

        // Класс "Университет" для управления студентами
        public class University
        {
            private List<Student> students;

            public University()
            {
                students = new List<Student>();
            }

            public void AddStudent(Student student)
            {
                if (student != null)
                    students.Add(student);
                else
                    throw new ArgumentNullException("Студент не может быть null");
            }

            public void RemoveStudent(Student student)
            {
                students.Remove(student);
            }

            public List<Student> FindStudents(string searchQuery)
            {
                List<Student> foundStudents = new List<Student>();
                foreach (Student student in students)
                {
                    if (student.FirstName.Contains(searchQuery) || student.LastName.Contains(searchQuery))
                    {
                        foundStudents.Add(student);
                    }
                }
                return foundStudents;
            }
        }

        // Класс "StudentsRepository" для доступа к данным о студентах
        namespace DataAccess
        {
            public class StudentsRepository
            {
                private string filePath = "students.txt";

                public void SaveStudents(List<Student> students)
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (Student student in students)
                        {
                            string line = $"{student.FirstName},{student.LastName},{student.Age},{student.AverageGrade}";
                            writer.WriteLine(line);
                        }
                    }
                }

                public List<Student> LoadStudents()
                {
                    List<Student> students = new List<Student>();
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] data = line.Split(',');
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
            }
        }
class Program
    {
        static void Main()
        {
            University university = new University();
            DataAccess.StudentsRepository studentsRepository = new DataAccess.StudentsRepository();

            // Создаем новых студентов
            Student student1 = new Student() { FirstName = "Иван", LastName = "Иванов", Age = 20, AverageGrade = 4.0 };
            Student student2 = new Student() { FirstName = "Петр", LastName = "Петров", Age = 22, AverageGrade = 4.5 };

            // Добавляем студентов в университет
            university.AddStudent(student1);
            university.AddStudent(student2);

            // Сохраняем список студентов в файл
            studentsRepository.SaveStudents(university.Students);

            // Загружаем список студентов из файла
            List<Student> loadedStudents = studentsRepository.LoadStudents();

            // Выводим информацию о студентах
            foreach (Student student in loadedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}, Возраст: {student.Age}, Средний балл: {student.AverageGrade}");
            }
        }
    }

    }

    


}
