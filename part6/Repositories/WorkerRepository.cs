using System;
using part6.Classes;
using part6.Utilities;

namespace part6.Repositories;

class WorkerRepository
{
	private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "data.txt");

	private StringSerializer _stringSerializer;

	private readonly List<Worker> _workers;
	public IEnumerable<Worker> Workers => _workers;

    public WorkerRepository(StringSerializer stringSerializer)
    {
        _stringSerializer = stringSerializer;
        if (!File.Exists(_filePath))
            File.Create(_filePath).Close();

        _workers = LoadAllWorkers().ToList();
    }

    public bool TryGetWorker(int id, out Worker? worker)
    {
        worker = _workers.FirstOrDefault(x => x.ID == id);

        return worker is not null;
    }

    public void RemoveWorker(int id)
    {
        _workers.RemoveAll(x => x.ID == id);
        Save();
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        using var writer = new StreamWriter(_filePath, true);
        string strData = _stringSerializer.Serialize(worker);
        writer.WriteLine(strData);
    }

    public IEnumerable<Worker> GetWorkersCreatedBetween(DateOnly start, DateOnly end) =>
        _workers.Where(x => DateOnly.FromDateTime(x.CreationTime) >= start && DateOnly.FromDateTime(x.CreationTime.Date) <= end);

    private IEnumerable<Worker> LoadAllWorkers()
    {
        using var reader = new StreamReader(_filePath);
        while (reader.ReadLine() is { } line)
            yield return _stringSerializer.Deserialize<Worker>(line);
    }

    private void Save()
    {
        File.WriteAllText(_filePath, string.Empty);

        using var writer = new StreamWriter(_filePath);
        foreach (string data in _workers.Select(worker => _stringSerializer.Serialize(worker)))
        {
            writer.WriteLine(data);
        }
    }
}