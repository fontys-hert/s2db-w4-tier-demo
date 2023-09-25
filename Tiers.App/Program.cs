using System.Text.Json;
using Tiers.App;
using Tiers.Core;

StudentController controller = new StudentController();
StudentService service = new StudentService();

while (true)
{
    // Core (View)
    Console.WriteLine(service.GetOverview());

    // View
    if (!controller.TryGet(out Student student))
    {
        Console.WriteLine("Hmm er ging iets niet goed met het invullen. Probeer opnieuw!");
    }

    // (View en) Core en DataAccess
    if (!service.TryAddStudent(student))
    {
        Console.WriteLine("Student is al aanwezig in deze groep!");
    }
}