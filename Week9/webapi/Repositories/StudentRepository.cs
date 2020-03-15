using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext _schoolContext;
    public StudentRepository(SchoolContext schoolContext)
    {
        _schoolContext = schoolContext;
    }

    public List<Student> GetAll()
    {
        return _schoolContext.Student.ToList();
    }

    public Student GetById(long studentId)
    {
        var student = _schoolContext.Student.SingleOrDefault(x => x.StudentId == studentId);
        return student;
    }

    public async Task<bool> CreateStudentAsync(Student student)
    {
        await _schoolContext.Student.AddAsync(student);
        await _schoolContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateStudentAsync(long studentId, Student update)
    {
        _schoolContext.Student.Update(update);
        await _schoolContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteStudentAsync(long studentId)
    {
        var student = GetById(studentId);

        if (student == null)
        {
            return false;
        }

        _schoolContext.Remove(student);
        await _schoolContext.SaveChangesAsync();
        return true;
    }
}