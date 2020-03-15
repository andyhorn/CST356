using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentRepository
{
    List<Student> GetAll();
    Student GetById(long studentId);
    Task<bool> CreateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(long studentId);
    Task<bool> UpdateStudentAsync(long studentId, Student student);
}