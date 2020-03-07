using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public async Task HandlesDeleteStudentFailure()
    {
        // Arrange
        A.CallTo(() => _studentRepository.DeleteStudentAsync(A<long>.Ignored))
            .Returns(false);

        // Act
        var result = await _studentService.DeleteStudentAsync(A.Dummy<long>());

        // Assert
        A.CallTo(() => _studentRepository.DeleteStudentAsync(A<long>.Ignored)).MustHaveHappenedOnceExactly();
        Assert.IsFalse(result);
    }

    [Test]
    public async Task DeleteStudent()
    {
        // Arrange
        A.CallTo(() => _studentRepository.DeleteStudentAsync(A<long>.Ignored))
            .Returns(true);

        // Act
        var result = await _studentService.DeleteStudentAsync(A.Dummy<long>());

        // Assert
        A.CallTo(() => _studentRepository.DeleteStudentAsync(A<long>.Ignored)).MustHaveHappenedOnceExactly();
        Assert.IsTrue(result);
    }

    [Test]
    public async Task HandlesCreateStudentFailure()
    {
        // Arrange
        A.CallTo(() => _studentRepository.CreateStudentAsync(A<Student>.Ignored))
            .Returns(false);

        // Act
        var result = await _studentService.CreateStudentAsync(A.Dummy<Student>());

        // Assert
        A.CallTo(() => _studentRepository.CreateStudentAsync(A<Student>.Ignored)).MustHaveHappenedOnceExactly();
        Assert.IsFalse(result);
    }

    [Test]
    public async Task CreateStudent()
    {
        // Arrange
        A.CallTo(() => _studentRepository.CreateStudentAsync(A<Student>.Ignored))
            .Returns(true);

        // Act
        var result = await _studentService.CreateStudentAsync(A.Dummy<Student>());

        // Assert
        A.CallTo(() => _studentRepository.CreateStudentAsync(A<Student>.Ignored)).MustHaveHappenedOnceExactly();
        Assert.IsTrue(result);
    }

    [Test]
    public void HandlesInvalidId()
    {
        // Arrange
        A.CallTo(() => _studentRepository.GetById(A<long>.Ignored))
            .Returns(null);

        // Act
        var student = _studentService.GetById(A.Dummy<long>());

        // Assert
        A.CallTo(() => _studentRepository.GetById(A<long>.Ignored)).MustHaveHappenedOnceExactly();
        Assert.IsNull(student);
    }

    [Test]
    public void ReturnsStudentWithValidId()
    {
        // Arrange
        A.CallTo(() => _studentRepository.GetById(A<long>.Ignored))
            .Returns(new Student
            {
                StudentId = A.Dummy<long>(),
                EmailAddress = "test@test.com"
            });

        // Act
        var student = _studentService.GetById(A.Dummy<long>());

        // Assert
        A.CallTo(() => _studentRepository.GetById(A<long>.Ignored)).MustHaveHappenedOnceExactly();
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