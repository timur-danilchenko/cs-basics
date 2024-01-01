using System;
using part6.Classes;
using System.Text;

namespace part6.Extensions;

internal static class ConsoleExtension
{
    internal static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine()!.Trim(), out int result))
            {
                return result;
            }

            WriteError("Введите целое число.");
        }
    }

    public static string ReadLine()
    {
        while (true)
        {
            string? fullName = Console.ReadLine();
            if (fullName != null && !string.IsNullOrEmpty(fullName))
                return fullName;

            WriteError("Строка не может быть пустой.");
        }
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static DateOnly ReadDate()
    {
        while (true)
        {
            if (DateOnly.TryParse(Console.ReadLine()!.Trim(), out DateOnly result))
                return result;

            WriteError("Введите дату в формате ДД.ММ.ГГГГ.");
        }
    }

    public static string ToStringTable(this Worker[] workers)
    {
        if (!workers.Any())
            return string.Empty;

        var sb = new StringBuilder();

        const string idColumn = "ID";
        const string creationDateColumn = "Creation Date";
        const string fullNameColumn = "Full Name";
        const string ageColumn = "Age";
        const string heightColumn = "Height";
        const string dateColumn = "Birth Date";
        const string birthPlaceColumn = "Birth Place";

        int idColumnWidth = Math.Max(workers.Max(x => x.ID).ToString().Length, idColumn.Length);
        int creationDateColumnWidth = Math.Max(workers.Max(x => x.CreationTime.ToString("dd.MM.yyyy hh:mm").Length), creationDateColumn.Length);
        int fullNameColumnWidth = Math.Max(workers.Max(x => x.FullName.Length), fullNameColumn.Length);
        int ageColumnWidth = Math.Max(workers.Max(x => x.Age.ToString().Length), ageColumn.Length);
        int heightColumnWidth = Math.Max(workers.Max(x => x.Height.ToString().Length), heightColumn.Length);
        int birthDateColumnWidth = Math.Max(workers.Max(x => x.Birthday.ToString().Length), dateColumn.Length);
        int birthPlaceColumnWidth = Math.Max(workers.Max(x => x.BirthPlace.Length), birthPlaceColumn.Length);

        sb.AppendLine(string.Join(" | ",
            idColumn.PadRight(idColumnWidth),
            creationDateColumn.PadRight(creationDateColumnWidth),
            fullNameColumn.PadRight(fullNameColumnWidth),
            ageColumn.PadRight(ageColumnWidth),
            heightColumn.PadRight(heightColumnWidth),
            dateColumn.PadRight(birthDateColumnWidth),
            birthPlaceColumn.PadRight(birthPlaceColumnWidth)
        ));

        foreach (Worker repositoryWorker in workers)
        {
            sb.AppendLine(string.Join(" | ",
                repositoryWorker.ID.ToString().PadRight(idColumnWidth),
                repositoryWorker.CreationTime.ToString("dd.MM.yyyy hh:mm").PadRight(creationDateColumnWidth),
                repositoryWorker.FullName.PadRight(fullNameColumnWidth),
                repositoryWorker.Age.ToString().PadRight(ageColumnWidth),
                repositoryWorker.Height.ToString().PadRight(heightColumnWidth),
                repositoryWorker.Birthday.ToString("dd.MM.yyyy").PadRight(birthDateColumnWidth),
                repositoryWorker.BirthPlace.PadRight(birthPlaceColumnWidth))
            );
        }

        return sb.ToString();
    }

    public static bool ReadYesNo()
    {
        while (true)
        {
            string input = Console.ReadLine()!.ToLower();

            bool inputYes = input.Equals("y");
            bool inputNo = input.Equals("n");

            if (inputYes || inputNo)
                return inputYes;

            WriteError("Введите y или n.");
        }
    }
}
