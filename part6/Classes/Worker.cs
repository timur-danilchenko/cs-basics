using System;
namespace part6.Classes;

public class Worker
{
	public int ID { get; init; }
	public DateTime CreationTime{ get; init; }
	public string FullName { get; init; } = null!;
	public int Age { get; init; }
	public int Height { get; init; }
	public DateOnly Birthday { get; init; }
	public string BirthPlace { get; init; } = null!;

	public override string ToString() => $"{ID} {FullName} {CreationTime:dd.MM.yyyy hh:mm} {Age} {Height} {Birthday:dd.MM.yyyy} {BirthPlace}";
}