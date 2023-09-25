using Tiers.Core;

namespace Tiers.App;

public class StudentController
{
    public bool TryGet(out Student? newStudent)
    {
        Console.WriteLine("Naam:");
        string? nameInput = Console.ReadLine();

        Console.WriteLine("Group:");
        string? groupInput = Console.ReadLine();

        if (nameInput == null || groupInput == null || !int.TryParse(groupInput, out int age))
        {
            newStudent = null;
            return false;
        }
        
        newStudent = new Student(nameInput, age);
        return true;
    }
}