using System;
using System.Reflection;
using System.Text;

namespace part6.Utilities;

public class StringSerializer
{
    public string Serialize(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();
        var sb = new StringBuilder();

        foreach (PropertyInfo property in properties)
        {
            if (sb.Length > 0)
            {
                sb.Append('#');
            }

            object? value = property.GetValue(obj);
            string? serializedValue = SerializeValue(value);
            sb.Append(serializedValue);
        }

        return sb.ToString();
    }

    public T Deserialize<T>(string input) where T : new()
    {
        var obj = new T();
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();

        string[] values = input.Split('#');

        if (values.Length != properties.Length)
        {
            throw new ArgumentException("Input string does not match the object's structure.");
        }

        for (var i = 0; i < properties.Length; i++)
        {
            PropertyInfo property = properties[i];
            Type propertyType = property.PropertyType;
            string serializedValue = values[i];
            object parsedValue = DeserializeValue(serializedValue, propertyType);
            property.SetValue(obj, parsedValue);
        }

        return obj;
    }

    private string? SerializeValue(object? value)
    {
        if (value is DateOnly dateOnly)
            return dateOnly.ToString();

        return value?.ToString();
    }

    private object DeserializeValue(string serializedValue, Type targetType)
    {
        return targetType == typeof(DateOnly)
            ? DateOnly.Parse(serializedValue)
            : Convert.ChangeType(serializedValue, targetType);
    }
}