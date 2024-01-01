using System.Reflection;
using part6.Repositories;
using part6.Classes;
using part6.Extensions;

namespace part6.States;

internal class DataViewState : IState
{
    private readonly WorkerRepository _repository;
    private readonly ProgramStateMachine _stateMachine;

    public DataViewState(WorkerRepository repository, ProgramStateMachine stateMachine)
    {
        _repository = repository;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        int mode = ReadViewMode();

        switch (mode)
        {
            case 1:
                PrintAll();
                break;
            case 2:
                PrintRecordWithId();
                break;
            case 3:
                PrintRecordsInDateRange();
                break;
            default:
                Console.WriteLine("Неверный ввод. Попробуйте ещё раз.");
                break;
        }

        _stateMachine.Enter<ModeSelectionState>();
    }

    private static int ReadViewMode()
    {
        Console.WriteLine("1. Все записи" +
                          "\n2. Запись с заданным ID" +
                          "\n3. Записи в выбранном диапазоне дат");

        int mode = ConsoleExtension.ReadInt();
        return mode;
    }

    private void PrintRecordsInDateRange()
    {
        Console.WriteLine("Введите начальную дату: ");
        DateOnly startDate = ConsoleExtension.ReadDate();

        Console.WriteLine("Введите конечную дату: ");
        DateOnly endDate = ConsoleExtension.ReadDate();

        IEnumerable<Worker> workers = _repository.GetWorkersCreatedBetween(startDate, endDate);
        Console.WriteLine(ApplySort(workers).ToArray().ToStringTable());
    }

    private void PrintRecordWithId()
    {
        Console.WriteLine("Введите ID записи: ");
        int id = ConsoleExtension.ReadInt();

        Console.WriteLine(_repository.TryGetWorker(id, out Worker? worker)
            ? worker!.ToString()
            : "Запись с таким ID не найдена."
        );
    }

    private IEnumerable<Worker> ApplySort(IEnumerable<Worker> workers)
    {
        Console.WriteLine("Выполнить сортировку? (y/n)");
        if (!ConsoleExtension.ReadYesNo())
            return workers;

        Console.WriteLine("Выберите поле для сортировки: ");
        PropertyInfo[] properties = typeof(Worker).GetProperties();

        for (var i = 0; i < properties.Length; i++)
            Console.WriteLine($"{i + 1}. {properties[i].Name}");

        int sortField = ConsoleExtension.ReadInt() - 1;

        if (sortField < 0 || sortField >= properties.Length)
            return workers;

        return workers.OrderBy(x => properties[sortField].GetValue(x));
    }

    private void PrintAll()
    {
        IEnumerable<Worker> workers = _repository.Workers;
        Console.WriteLine(ApplySort(workers).ToArray().ToStringTable());
    }
}