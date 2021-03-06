using System.Collections.Generic;
using System.Threading.Tasks;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository) 
    {
        _studentRepository = studentRepository;
    }

    private bool IsSpecial(Student student)
    {
        return student.EmailAddress.StartsWith('a');
    }

    public List<StudentViewModel> GetAllStudents()
    {
        var students = _studentRepository.GetAll();
        var models = new List<StudentViewModel>();

        students.ForEach(student => {
            var newModel = new StudentViewModel
            {
                StudentId = student.StudentId,
                Email = student.EmailAddress,
                IsSpecial = IsSpecial(student)
            };

            models.Add(newModel);
        });

        return models;
    }

    public StudentViewModel GetById(long studentId)
    {
        var student = _studentRepository.GetById(studentId);

        if (student == null)
        {
            return null;
        }

        var viewModel = new StudentViewModel
        {
            Email = student.EmailAddress,
            StudentId = student.StudentId,
            IsSpecial = IsSpecial(student)
        };

        return viewModel;
    }

    public async Task<bool> CreateStudentAsync(Student student)
    {
        var result = await _studentRepository.CreateStudentAsync(student);
        return result;
    }

    public async Task<bool> DeleteStudentAsync(long studentId)
    {
        var result = await _studentRepository.DeleteStudentAsync(studentId);
        return result;
    }
}