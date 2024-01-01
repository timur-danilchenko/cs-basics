using System;
using part6.Extensions;
using part6.Factories;
using part6.Repositories;

namespace part6.States;

internal class DataEntryState : IState
{
    private readonly WorkerRepository _repository;
    private readonly WorkerFactory _workerFactory;
    private readonly ProgramStateMachine _stateMachine;

    public DataEntryState(WorkerRepository repository, WorkerFactory workerFactory, ProgramStateMachine stateMachine)
    {
        _repository = repository;
        _workerFactory = workerFactory;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Console.WriteLine("1. Добавить запись" +
                          "\n2. Удалить запись");

        switch (ConsoleExtension.ReadInt())
        {
            case 1:
                AddRecord();
                break;
            case 2:
                DeleteRecord();
                break;
        }

        _stateMachine.Enter<ModeSelectionState>();
    }

    private void DeleteRecord()
    {
        Console.WriteLine("Введите ID записи: ");
        int id = ConsoleExtension.ReadInt();

        _repository.RemoveWorker(id);
    }

    private void AddRecord()
    {
        _workerFactory.CreateWorker();
    }
}