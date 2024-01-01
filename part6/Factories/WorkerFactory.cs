using System;
using part6.Classes;
using part6.Repositories;
using part6.Extensions;

namespace part6.Factories;

internal class WorkerFactory
{
    protected readonly WorkerRepository workerRepository;

    public WorkerFactory(WorkerRepository repository)
    {
        workerRepository = repository;
    }

    public virtual Worker CreateWorker()
    {
        var worker = new Worker
        {
            ID = GetUniqueId(),
            FullName = ReadFullName(),
            CreationTime = DateTime.Now,
            Age = ReadAge(),
            Height = ReadHeight(),
            Birthday = ReadBirthDate(),
            BirthPlace = ReadBithPlace()
        };

        workerRepository.AddWorker(worker);

        return worker;
    }

    protected int GetUniqueId() =>
        workerRepository.Workers.Any() ? workerRepository.Workers.Max(x => x.ID) + 1 : 0;

    private string ReadFullName()
    {
        Console.WriteLine("ФИО: ");
        return ConsoleExtension.ReadLine();
    }

    private int ReadAge()
    {
        Console.WriteLine("Возраст: ");
        return ConsoleExtension.ReadInt();
    }

    private int ReadHeight()
    {
        Console.WriteLine("Рост: ");
        return ConsoleExtension.ReadInt();
    }

    private DateOnly ReadBirthDate()
    {
        Console.WriteLine("Дата рождения: ");
        return ConsoleExtension.ReadDate();
    }

    private string ReadBithPlace()
    {
        Console.WriteLine("Место рождения: ");
        return ConsoleExtension.ReadLine();
    }
}