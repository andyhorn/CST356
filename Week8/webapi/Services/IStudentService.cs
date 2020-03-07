using System.Collections.Generic;

public interface IStudentService
{
    List<StudentViewModel> GetAllStudents();
    StudentViewModel GetById(long studentId);
}