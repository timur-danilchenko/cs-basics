using System.ComponentModel.DataAnnotations;
using part6.States;

namespace part6.States;

internal class ModeSelectionState : IState
{
    private readonly ProgramStateMachine _stateMachine;

    public ModeSelectionState(ProgramStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Console.WriteLine(
            "Выберите режим работы программы:" +
            "\n1. Вывести данные на экран" +
            "\n2. Заполнить данные и добавить новую запись в конец файла"
        );

        MoveToNextState();
    }

    private void MoveToNextState()
    {
        ConsoleKeyInfo key = Console.ReadKey();

        Console.Clear();

        switch (key)
        {
            case { Key: ConsoleKey.D1 }:
                _stateMachine.Enter<DataViewState>();
                break;
            case { Key: ConsoleKey.D2 }:
                _stateMachine.Enter<DataEntryState>();
                break;
            default:
                Console.WriteLine("\nНеверный ввод. Попробуйте ещё раз.");
                _stateMachine.Enter<ModeSelectionState>();
                break;
        }
    }
}