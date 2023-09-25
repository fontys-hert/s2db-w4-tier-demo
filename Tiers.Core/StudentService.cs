using System.Text;
using Tiers.DataAccess;

namespace Tiers.Core;

public class StudentService
{
    private StudentRepository repository = new();

    public List<Student> GetAll()
    {
        List<StudentDto> studentDtos = repository.GetAll();

        return studentDtos.Select(s => new Student(s.Name, s.GroupNumber)).ToList();
    }

    public string GetOverview()
    {
        StringBuilder builder = new StringBuilder();
        var students = GetAll();
        
        if (!students.Any())
        {
            builder.AppendLine("Op dit moment zijn er geen studenten aanwezig");
        }
        else
        {
            builder.AppendLine("Overzicht van studenten aanwezig:");
            foreach (var studentPresent in students)
            {
                builder.AppendLine($"{studentPresent.Name} - {studentPresent.GroupNumber}");
            }
        }

        return builder.ToString();
    }

    public bool TryAddStudent(Student student)
    {
        return repository.TryAdd(new StudentDto
        {
            Name = student.Name,
            GroupNumber = student.GroupNumber
        });
    }
}