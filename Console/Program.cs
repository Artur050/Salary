using Domain.Persons;
using Repository;
using Service;

class Program
{

    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Create\n" +
                              "2. Read\n" +
                              "3. Update\n" +
                              "4. Delete");
            Console.WriteLine("Введите команду:");
            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    await Create();
                    break;
                case "2":
                    await Read();
                    break;
                case "3":
                    await Update();
                    break;
                case "4":
                    await Delete();
                    break;
                default:
                    return;
            }
        }
    }

    static async Task Create()
    {
        var personService = new PersonService(new PersonRepository());

        Console.WriteLine("Введите имя");
        string name = Console.ReadLine();

        Console.WriteLine("Введите должность");
        int role = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите зарплату");
        decimal salary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Дату устройства гггг.мм.дд");
        string date = Console.ReadLine();
        var parseDate = DateTime.Parse(date);

        var person = await personService.CreateUser(name, role, salary, parseDate);

        Console.WriteLine(person.Message);
        Console.ReadKey();
    }

    static async Task Read()
    {
        var personService = new PersonService(new PersonRepository());

        Console.WriteLine("Введите имя:");
        var name = Console.ReadLine();

        var person = (await personService.GetUser(name)).Data as Person;
        Console.WriteLine(person?.ToString());
    }

    static async Task Update()
    {
        var personService = new PersonService(new PersonRepository());

        Console.WriteLine("Введите имя:");
        var name = Console.ReadLine();

        Console.WriteLine("Введите новое имя:");
        var newName = Console.ReadLine();

        var response = await personService.Update(name, newName);
        Console.WriteLine(response.Message);
    }

    static async Task Delete()
    {
        var personService = new PersonService(new PersonRepository());

        Console.WriteLine("Введите имя:");
        var name = Console.ReadLine();

        var response = await personService.Delete(name);
        Console.WriteLine(response.Message);
    }
}