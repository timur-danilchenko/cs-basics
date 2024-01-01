using System;
using part6.Classes;
using part6.Repositories;

namespace part6.Factories;

internal class RandomWorkerFactory : WorkerFactory
{
    private readonly string[] _names = new[]
    {
        "John", "James", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas", "Christopher",
        "Daniel", "Paul", "Mark", "Donald", "George", "Kenneth", "Steven", "Edward", "Brian"
    };

    private readonly string[] _surnames = new[]
    {
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez",
        "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White"
    };

    private readonly string[] _cities = new[]
    {
        "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware",
        "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky",
    };

    public RandomWorkerFactory(WorkerRepository repository) : base(repository)
    {
    }

    public override Worker CreateWorker()
    {
        var random = new Random();
        int age = random.Next(0, 100);
        var worker = new Worker
        {
            ID = GetUniqueId(),
            FullName = _names[random.Next(0, _names.Length)] + " " + _surnames[random.Next(0, _surnames.Length)],
            CreationTime = DateTime.Now,
            Age = age,
            Height = random.Next(50, 250),
            Birthday = DateOnly.FromDateTime(DateTime.Now.AddYears(-age)),
            BirthPlace = _cities[random.Next(0, _cities.Length)]
        };

        workerRepository.AddWorker(worker);

        return worker;
    }
}

