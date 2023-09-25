using System.Text.Json;

namespace Tiers.DataAccess;

public class StudentRepository
{
    string dataLocation = "data.json";

    public List<StudentDto> GetAll()
    {
        List<StudentDto> students = new List<StudentDto>();

        if (File.Exists("data.json"))
        {
            students = JsonSerializer.Deserialize<List<StudentDto>>(File.ReadAllText(dataLocation)) ??
                       throw new InvalidOperationException("This is not supposed to happen");
        }

        return students;
    }

    public bool TryAdd(StudentDto student)
    {
        List<StudentDto> students = GetAll();

        if (!students.Contains(student))
        {
            students.Add(student);

            File.WriteAllText(dataLocation, JsonSerializer.Serialize(students));
            return true;
        }

        return false;
    }
}