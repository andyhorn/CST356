using System.Collections.Generic;

namespace Database
{
    public static class InMemory
    {
        public static List<Student> Students = new List<Student>
        {
            new Student
            {
                Id = 1,
                StudentId = "123456789",
                EmailAddress = "john.doe@oit.edu"
            },
            new Student
            {
                Id = 2,
                StudentId = "987654321",
                EmailAddress = "jane.doe@oit.edu"
            },
            new Student
            {
                Id = 3,
                StudentId = "24681012",
                EmailAddress = "jon.snow@oit.edu"
            },
            new Student
            {
                Id = 4,
                StudentId = "135791113",
                EmailAddress = "sam.smith@oit.edu"
            }
        };

        public static List<Instructor> Instructors = new List<Instructor>
        {
            new Instructor
            {
                FirstName = "John",
                MiddleInitial = 'A',
                LastName = "Doe"
            },
            new Instructor
            {
                FirstName = "Jane",
                MiddleInitial = 'B',
                LastName = "Doe"
            },
            new Instructor
            {
                FirstName = "Billy",
                MiddleInitial = 'B',
                LastName = "Smith"
            },
            new Instructor
            {
                FirstName = "George",
                MiddleInitial = 'X',
                LastName = "Jones"
            },
            new Instructor
            {
                FirstName = "Sarah",
                MiddleInitial = 'S',
                LastName = "Smith"
            }
        };
    }
}