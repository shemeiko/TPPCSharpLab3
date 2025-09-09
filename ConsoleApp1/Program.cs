using System;

class Program
{
    public static void Main()
    {
        // MyDate wrongDate = new("35/5/2025 15:15:15"); // cannot be 35 day in a month, throws exception
        // Console.WriteLine(wrongDate);

        // MyDate wrongTime = new("24/5/2025 35:17:05"); // cannot be 24 hours in a day, throws exception
        // Console.WriteLine(wrongTime);

        // MyDate dateNow = new();
        // Console.WriteLine(); // prints date and time right now

        // DateTime dt = new(2020, 8, 4, 14, 53, 7);
        // MyDate dateByTicks = new(dt.Ticks);
        // Console.WriteLine(dateByTicks); // prints 4/8/2020 14:53:07

        // MyDate date = new("29/12/2025 15:15:15");
        // Console.WriteLine(date); // prints 29/12/2025 15:15:15

        // MyDate dateOnly = new("29/12/2025");
        // Console.WriteLine(dateOnly); // prints 29/12/2025 00:00:00

        // dateOnly.Hour = 3;
        // dateOnly.Minute = 2;

        // dateOnly.Second = 64; // Property Second can be 0 through 59, throws exception
        // dateOnly.Second = 43;
        // Console.WriteLine(dateOnly); // prints 29/12/2025 03:02:43

        // MyDate mydate = new("29/12/2025 14:53:07");
        // MyDate newDate = mydate.AddHours(4).AddMinutes(23).AddSeconds(2); // added 04:23:02 to mydate
        // Console.WriteLine(newDate); // prints 29/12/2025 19:16:09

        // MyDate previousDate = new("31/12/2025 14:53:07");
        // Console.WriteLine(previousDate.NextDay()); // prints 1/1/2026 14:53:07

        // Console.WriteLine(MyDate.IsLeapYear(1900)); // false
        // Console.WriteLine(MyDate.IsLeapYear(2024)); // true
        // Console.WriteLine(MyDate.IsLeapYear(2025)); // false
    }
}