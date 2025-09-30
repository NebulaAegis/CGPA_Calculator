using System;
using Nida_CGPA_Calculator;

namespace Nida_EAD_Assignment1
{
    //This is the student class
    class Student
    {
        private string stu_name;
        private int totalCourses;

        public string Name
        {
            get 
            {
                return stu_name; 
            }
            set 
            { 
                stu_name = value;
            }
        }

        public int TotalCourses
        {
            get { 
                return totalCourses; 
            }
            set
            {
                if (value < 0)
                    totalCourses = 0;
                else
                    totalCourses = value;
 }
        }
    }

    // This is the class for course
    class Course
    {
        private string courseName;
        private double gpa;
        private int creditHours;

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public double GPA
        {
            get { return gpa; }
            set { gpa = value; }
        }

        public int CreditHours
        {
            get { return creditHours; }
            set { creditHours = value; }
        }
    }


    class Nida_GPA_Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Welcome to Nida's GPA Calculator =====\n");
            Console.ResetColor();

            Student student = new Student();

            Console.Write("Enter your name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter number of courses: ");
            student.TotalCourses = Convert.ToInt32(Console.ReadLine());

            Course[] courseList = new Course[student.TotalCourses];
            var courses = new (double gpa, int credit_hours)[student.TotalCourses];

            for (int i = 0; i < student.TotalCourses; i++)
            {
                Console.WriteLine($"\nCourse {i + 1}:");

                Console.Write("Enter Course Name: ");
                string cname = Console.ReadLine();

                Console.Write("Enter GPA (e.g. 3.5): ");
                double gpa = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Credit Hours: ");
                int credit = Convert.ToInt32(Console.ReadLine());

                courseList[i] = new Course { CourseName = cname, GPA = gpa, CreditHours = credit };
                courses[i] = (gpa, credit);
            }

            // Calling  my NuGet library function(Nida_Library_Assignment1)
            double semesterGPA = Uet_Calculator.calculateGPA(courses);

            Console.WriteLine("\n========== Semester GPA Report ==========");

            Console.WriteLine($"Student Name : {student.Name}");
            Console.WriteLine($"Total Courses: {student.TotalCourses}\n");

            Console.WriteLine("Courses Details:");
            Console.WriteLine("-----------------------------------------");
            foreach (var c in courseList)
            {
                Console.WriteLine($"{c.CourseName} -> GPA: {c.GPA}, Credit Hours: {c.CreditHours}");
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Your Semester GPA is: {semesterGPA:F2}");
            Console.ResetColor();
            Console.WriteLine("=========================================\n");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
