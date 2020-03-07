using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;

public class ProductServiceTests
{
    private StudentService _studentService; // System Under Test
    private IStudentRepository _studentRepository; // Mock

    [SetUp]
    public void Setup()
    {
        _studentRepository = A.Fake<IStudentRepository>();

        _studentService = new StudentService(_studentRepository);
    }

    [Test]
    public void ReturnsThreeSpecialStudents()
    {
        // Arrange
        A.CallTo(() => _studentRepository.GetAll()).Returns(
            new List<Student>
            {
                new Student()
                {
                    StudentId = 1,
                    EmailAddress = "andrew.horn@oit.edu"
                },
                new Student()
                {
                    StudentId = 2,
                    EmailAddress = "another.student@oit.edu"
                },
                new Student()
                {
                    StudentId = 3,
                    EmailAddress = "andanother.student@oit.edu"
                },
                new Student()
                {
                    StudentId = 4,
                    EmailAddress = "not.a.special.student@oit.edu"
                }
            }
        );

        // Act
        var students = _studentService.GetAllStudents();

        // Assert
        Assert.That(students.Where(x => x.IsSpecial).Count, Is.EqualTo(3));
    }

    [Test]
    public void ReturnsNoSpecialStudents()
    {
        // Arrange
        A.CallTo(() => _studentRepository.GetAll()).Returns(
            new List<Student>()
            {
                new Student()
                {
                    StudentId = 1,
                    EmailAddress = "student.one@oit.edu"
                },
                new Student()
                {
                    StudentId = 2,
                    EmailAddress = "student.two@oit.edu"
                },
                new Student()
                {
                    StudentId = 3,
                    EmailAddress = "student.three@oit.edu"
                },
                new Student()
                {
                    StudentId = 4,
                    EmailAddress = "student.four@oit.edu"
                }
            }
        );

        // Act
        var students = _studentService.GetAllStudents();

        // Assert
        Assert.That(students.Where(x => x.IsSpecial).Count, Is.EqualTo(0));
    }
}