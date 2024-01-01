using part6.Repositories;
using part6.Factories;

namespace part6.States;

internal class ProgramStateMachine
{
    private readonly Dictionary<Type, IState> _states;

    public ProgramStateMachine(WorkerRepository repository, WorkerFactory workerFactory)
    {
        _states = new Dictionary<Type, IState>()
        {
            { typeof(ModeSelectionState), new ModeSelectionState(this) },
            { typeof(DataViewState), new DataViewState(repository, this) },
            { typeof(DataEntryState), new DataEntryState(repository, workerFactory, this) },
        };
    }

    internal void Enter<TState>() where TState : class, IState
    {
        if (_states.TryGetValue(typeof(TState), out IState? state))
            state.Enter();
        else
            throw new ArgumentException($"State {typeof(TState).Name} not found.");
    }
}