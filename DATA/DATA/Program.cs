using System;
using System.Globalization;

class DateParsingDemo
{
    static void Main()
    {
        // Пример строки 
        string dateStr1 = "2024-11-27";
        string dateStr2 = "27.11.2024";
        string invalidDateStr = "invalid date";
        string dateStrExact = "27 ноября 2024";
        string exactFormat = "dd MMMM yyyy";

        // 1. Parse()
        try
        {
            DateTime parsedDate = DateTime.Parse(dateStr1); // Парсинг стандартного формата
            Console.WriteLine($"Parse: {parsedDate}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Parse error: {ex.Message}");
        }

        // 2. ParseExact()
        try
        {
            DateTime parsedExactDate = DateTime.ParseExact(dateStrExact, exactFormat, CultureInfo.CurrentCulture);
            Console.WriteLine($"ParseExact: {parsedExactDate}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"ParseExact error: {ex.Message}");
        }

        // 3. TryParse()
        if (DateTime.TryParse(dateStr2, out DateTime tryParsedDate))
        {
            Console.WriteLine($"TryParse: {tryParsedDate}");
        }
        else
        {
            Console.WriteLine("TryParse: Failed to parse the date.");
        }

        // TryParse с некорректной строкой
        if (DateTime.TryParse(invalidDateStr, out DateTime invalidTryParsedDate))
        {
            Console.WriteLine($"TryParse (invalid): {invalidTryParsedDate}");
        }
        else
        {
            Console.WriteLine("TryParse (invalid): Failed to parse the date.");
        }

        // 4. TryParseExact()
        if (DateTime.TryParseExact(dateStrExact, exactFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tryParsedExactDate))
        {
            Console.WriteLine($"TryParseExact: {tryParsedExactDate}");
        }
        else
        {
            Console.WriteLine("TryParseExact: Failed to parse the date.");
        }
    }
}
