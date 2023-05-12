
using System;

namespace MyProject
{
    // Define an abstract class Person
    public abstract class Person
    {
        // Properties
        public string Name { get; set; }
        public int Age { get; set; }

        // Parameterized constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Copy constructor
        public Person(Person other)
        {
            Name = other.Name;
            Age = other.Age;
        }

        // Override ToString method to display object as a string
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

        // Define an abstract method
        public abstract void Greet();
    }

    // Define a sealed class Student that inherits from Person
    public sealed class Student : Person
    {
        // Properties
        public string Major { get; set; }
        public double GPA { get; set; }

        // Parameterized constructor
        public Student(string name, int age, string major, double gpa)
            : base(name, age)
        {
            Major = major;
            GPA = gpa;
        }

        // Copy constructor
        public Student(Student other)
            : base(other)
        {
            Major = other.Major;
            GPA = other.GPA;
        }

        // Override ToString method to display object as a string
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Major: {Major}, GPA: {GPA}";
        }

        // Indexer
        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Name;
                    case 1:
                        return Age.ToString();
                    case 2:
                        return Major;
                    case 3:
                        return GPA.ToString();
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        Name = value;
                        break;
                    case 1:
                        Age = int.Parse(value);
                        break;
                    case 2:
                        Major = value;
                        break;
                    case 3:
                        GPA = double.Parse(value);
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        // Operator overloading
        public static Student operator +(Student s1, Student s2)
        {
            Student result = new Student(s1.Name + " " + s2.Name, (s1.Age + s2.Age) / 2,
                                         s1.Major + " & " + s2.Major, (s1.GPA + s2.GPA) / 2);
            return result;
        }

        // Implement the abstract method Greet
        public override void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name} and I'm a student.");
        }
    }

    // Define a class Teacher that inherits from Person
    public class Teacher : Person
    {
        // Properties
        public string Subject { get; set; }
        public int YearsExperience { get; set; }

        // Parameterized constructor
        public Teacher(string name, int age, string subject, int yearsExperience)
            : base(name, age)
        {
            Subject = subject;
            YearsExperience = yearsExperience;
        }

        // Copy constructor
        public Teacher(Teacher other)
            : base(other)
        {
            Subject = other.Subject;
            YearsExperience = other.YearsExperience;
        }


        // Override ToString method to display object as a string
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Subject: {Subject}, Years of Experience: {YearsExperience}";
        }

        // Implement the abstract method Greet
        public override void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name} and I'm a teacher.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a Student object using parameterized constructor
            Student s1 = new Student("Ayman", 20, "Computer Science", 3.8);

            // Create another Student object using copy constructor
            Student s2 = new Student(s1);

            // Print s1 and s2 using ToString method
            Console.WriteLine(s1.ToString());
            Console.WriteLine(s2.ToString());

            // Modify s2's properties using indexer
            s2[0] = "Mohammed";
            s2[1] = "21";
            s2[2] = "Electrical Engineering";
            s2[3] = "3.5";

            // Print s2 using ToString method
            Console.WriteLine(s2.ToString());

            // Create a new Student object using operator overloading
            Student s3 = s1 + s2;

            // Print s3 using ToString method
            Console.WriteLine(s3.ToString());

            // Create a Teacher object using parameterized constructor
            Teacher t1 = new Teacher("Dr. Smith", 40, "Mathematics", 10);

            // Create another Teacher object using copy constructor
            Teacher t2 = new Teacher(t1);

            // Print t1 and t2 using ToString method
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());

            // Call the Greet method on s1, s2, s3, t1, and t2
            s1.Greet();
            s2.Greet();
            s3.Greet();
            t1.Greet();
            t2.Greet();
        }
    }
}