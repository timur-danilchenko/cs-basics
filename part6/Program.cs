using part6.Utilities;
using part6.Repositories;
using part6.Factories;
using part6.States;
using System.Text;

namespace part6;

internal class Program
{
    static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding(866);
        Console.InputEncoding = Encoding.GetEncoding(866);

        var stringSerializer = new StringSerializer();
        var dataService = new WorkerRepository(stringSerializer);
        var workerFactory = new RandomWorkerFactory(dataService);
        var stateMachine = new ProgramStateMachine(dataService, workerFactory);

        stateMachine.Enter<ModeSelectionState>();
    }
}