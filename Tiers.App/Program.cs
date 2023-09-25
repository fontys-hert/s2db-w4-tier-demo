using System.Text.Json;
using Tiers.App;

string dataLocation = "data.json";
List<Student> students = new List<Student>();

// Data
if (File.Exists("data.json"))
{
    students = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(dataLocation)) ?? throw new InvalidOperationException("This is not supposed to happen");
}

while (true)
{
    // Core (View)
    if (!students.Any())
    {
        Console.WriteLine("Op dit moment zijn er geen studenten aanwezig");
    }
    else
    {
        Console.WriteLine("Overzicht van studenten aanwezig:");
        foreach (var studentPresent in students)
        {
            Console.WriteLine($"{studentPresent.Name} - {studentPresent.GroupNumber}");
        }
        Console.WriteLine();
    }
    
    // View
    Console.WriteLine("Naam:");
    string? nameInput = Console.ReadLine();
    
    Console.WriteLine("Group:");
    string? groupInput = Console.ReadLine();

    if (nameInput == null || groupInput == null || !int.TryParse(groupInput, out int age))
    {
        Console.WriteLine("Hmm er ging iets niet goed met het invullen. Probeer opnieuw!");
        continue;
    }

    Student student = new Student(nameInput, age);

    
    // (View en) Core en DataAccess
    if (!students.Contains(student))
    {
        students.Add(student);
        
        File.WriteAllText(dataLocation, JsonSerializer.Serialize(students));
    }
    else
    {
        Console.WriteLine("Student is al aanwezig in deze group!");
    }
}