namespace Question5
{
    using System;
    using System.Collections.Generic;


    public delegate bool IsEligibleForScholarship(Student student);

    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }
    }

    public class Program
    {

        public static bool ScholarshipEligibility(Student student)
        {
            return student.Marks > 80 && student.SportsGrade == 'A';
        }


        public static string GetEligibleStudents(List<Student> studentsList, IsEligibleForScholarship isEligible)
        {
            string eligibleStudents = "";
            foreach (Student student in studentsList)
            {
                if (isEligible(student))
                {
                    eligibleStudents += student.Name + ", ";
                }
            }

            eligibleStudents = eligibleStudents.TrimEnd(',', ' ');
            return eligibleStudents;
        }

        public static void Main()
        {
            IsEligibleForScholarship isEligible = ScholarshipEligibility;
            List<Student> studentsList = new List<Student>
     {
         new Student { RollNo = 1, Name = "Raj", Marks = 75, SportsGrade = 'A' },
         new Student { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' },
         new Student { RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B' },
         new Student { RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A' }
     };

            string eligibleStudents = GetEligibleStudents(studentsList, isEligible);
            Console.WriteLine(eligibleStudents);
        }
    }

}
