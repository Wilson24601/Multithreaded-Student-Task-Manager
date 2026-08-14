using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultithreadedStudentTaskManager
{
    // Student class
    public class Student
    {
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public int Marks { get; set; }

        public Student(string name, string studentNumber, int marks)
        {
            Name = name;
            StudentNumber = studentNumber;
            Marks = marks;
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            // Create at least 5 students
            students.Add(new Student("Lefa", "ST001", 75));
            students.Add(new Student("Naledi", "ST002", 60));
            students.Add(new Student("Thabo", "ST003", 82));
            students.Add(new Student("Kabelo", "ST004", 55));
            students.Add(new Student("Ayanda", "ST005", 71));

            // Create threads for tasks
            Thread infoThread = new Thread(DisplayStudentInfo);
            Thread averageThread = new Thread(CalculateAverage);
            Thread reportThread = new Thread(DisplayReport);

            // Start threads
            infoThread.Start();
            averageThread.Start();
            reportThread.Start();

            // Wait for threads to finish
            infoThread.Join();
            averageThread.Join();
            reportThread.Join();

            Console.WriteLine("\nAll tasks completed.");
        }

        // Task 1: Display student information
        static void DisplayStudentInfo()
        {
            Console.WriteLine("\nStudent Information Thread Started...");
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}");
                Console.WriteLine($"Student Number: {student.StudentNumber}");
                Console.WriteLine($"Marks: {student.Marks}\n");
                Thread.Sleep(500); // Simulate work
            }
        }

        // Task 2: Calculate average mark
        static void CalculateAverage()
        {
            Console.WriteLine("\nCalculating Average Thread Started...");
            int total = 0;
            foreach (var student in students)
            {
                total += student.Marks;
                Thread.Sleep(200); // Simulate work
            }
            double average = (double)total / students.Count;
            Console.WriteLine($"Average Mark: {average:F2}");
        }

        // Task 3: Display report
        static void DisplayReport()
        {
            Console.WriteLine("\nReport Thread Started...");
            Thread.Sleep(1000); // Simulate report generation
            Console.WriteLine("Report Generation Complete.");
        }
    }
}