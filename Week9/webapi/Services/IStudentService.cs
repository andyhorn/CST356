using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentService
{
    List<StudentViewModel> GetAllStudents();
    StudentViewModel GetById(long studentId);
    Task<bool> CreateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(long studentId);
}