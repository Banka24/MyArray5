namespace ConsoleApp2;

internal class Program
{
    private static void Main()
    {
        Console.Write("Введите кол-во спортсменов: ");
        if (!int.TryParse(Console.ReadLine(), out var countOfSportsmens))
        {
            Console.WriteLine("Введите число");
            return;
        }

        var sportsmens = new Sportsmen[countOfSportsmens];
        InputSportsmens(ref sportsmens);
        PrintSwimmer(sportsmens);
    }

    private static void InputSportsmens(ref Sportsmen[] sportsmens)
    {
        for (var i = 0; i < sportsmens.Length; i++)
        {
            sportsmens[i] = new Sportsmen();
            Console.Write("Введите фамилию спортсмена: ");
            sportsmens[i].LastName = Console.ReadLine();
            Console.Write("Введите имя спортсмена: ");
            sportsmens[i].FirstName = Console.ReadLine();
            Console.Write("Введите дату рождения: ");
            sportsmens[i].BirthDate = DateTime.Parse(Console.ReadLine()).ToShortDateString();
            Console.Write("Вид спорта: ");
            sportsmens[i].SportName = Console.ReadLine();
            Console.Write("Сколько лет занимается видом спорта: ");
            sportsmens[i].YearInSport = uint.Parse(Console.ReadLine());
        }
    }

    private static void PrintSwimmer(in Sportsmen[] sportsmens)
    {
        var sportsmenSelector = sportsmens.Where(i => i.SportName is "плавание" or "Плавание");

        foreach (var sportsmen in sportsmenSelector)
        {
            Console.WriteLine($"Спортсмен {sportsmen.LastName} {sportsmen.FirstName}.\n" +
                              $"Возраст: {DateTime.Today.Year - DateTime.Parse(sportsmen.BirthDate).Year}.Занимается спортом: {sportsmen.YearInSport}");
        }
            
    }
}