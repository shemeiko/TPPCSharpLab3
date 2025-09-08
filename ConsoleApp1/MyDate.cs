using System;

public class MyDate
{
    private int day;
    private int month;
    private int year;
    private int hour;
    private int minute;
    private int second;

    public int Hour
    {
        get => hour;
        set
        {
            if (value < 0 || value > 23)
                throw new ArgumentOutOfRangeException("Hours should be >= 0 and <= 23!");
            hour = value;
        }
    }

    public int Minute
    {
        get => minute;
        set
        {
            if (value < 0 || value > 59)
                throw new ArgumentOutOfRangeException("Minutes should be >= 0 and <= 59!");
            minute = value;
        }
    }

    public int Seconds
    {
        get => second;
        set
        {
            if (value < 0 || value > 59)
                throw new ArgumentException("Seconds should be >= 0 and <= 59!");
            second = value;
        }
    }

    public MyDate()
    {
        DateTime date = DateTime.Now;
        day = date.Day;
        month = date.Month;
        year = date.Year;
        hour = date.Hour;
        minute = date.Minute;
        second = date.Second;
    }

    public MyDate(long ticks)
    {
        DateTime date = new(ticks);
        year = date.Year;
        month = date.Month;
        day = date.Day;
        hour = date.Hour;
        minute = date.Minute;
        second = date.Second;
    }

    public MyDate(string strdate)
    {
        if (strdate.Length < 1)
            throw new ArgumentException("Invalid date!");

        string[] o = strdate.Split(" ");

        string[] date = o[0].Split("/");
        if (date.Length != 3)
            throw new ArgumentException("Invalid date format! Use / as separator");

        day = int.Parse(date[0]);
        month = int.Parse(date[1]);
        year = int.Parse(date[2]);

        if (o.Length > 1)
        {
            string[] time = o[1].Split(":");
            if (time is null || time.Length != 3)
                throw new ArgumentException("Invalid time format! Use : as separator");
            else
            {
                hour = int.Parse(time[0]);
                minute = int.Parse(time[1]);
                second = int.Parse(time[2]);
            }
        }
        CheckFormat();
    }

    public MyDate AddSeconds(int seconds)
    {
        if (seconds < 0) throw new ArgumentException("seconds cannot be negative!");

        MyDate newDate = ShallowCopy();
        newDate.second += seconds;
        newDate.NormalizeTime();

        return newDate;
    }

    public MyDate AddMinutes(int minutes)
    {
        if (minutes < 0) throw new ArgumentException("minutes cannot be negative!");

        MyDate newDate = ShallowCopy();
        newDate.minute += minutes;
        newDate.NormalizeTime();

        return newDate;
    }

    public MyDate AddHours(int years)
    {
        if (years < 0) throw new ArgumentException("years cannot be negative!");

        MyDate newDate = ShallowCopy();
        newDate.year += years;
        newDate.NormalizeTime();

        return newDate;
    }

    public MyDate AddDays(int days)
    {
        if (days < 0) throw new ArgumentException("days cannot be negative!");

        MyDate newDate = ShallowCopy();
        newDate.day += days;
        newDate.NormalizeDate();

        return newDate;
    }
    
    public MyDate AddMonths(int months)
    {
        if (months < 0) throw new ArgumentException("months cannot be negative!");

        MyDate newDate = ShallowCopy();
        newDate.month += months;
        newDate.NormalizeDate();

        return newDate;
    }

    public MyDate AddYears(int years)
    {
        if (years < 0) throw new ArgumentException("years cannot be negative!");

        MyDate newDate = ShallowCopy();
        newDate.year += years;

        return newDate;
    }
    
    public MyDate NextDay()
    {
        MyDate newDate = ShallowCopy();
        newDate.day++;
        newDate.NormalizeDate();

        return newDate;
    }

    static int DaysInMonth(int month, int year) => month switch
    {
        1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
        4 or 6 or 9 or 11 => 30,
        2 => IsLeapYear(year) ? 29 : 28,
        _ => throw new ArgumentOutOfRangeException("Month should be 1 through 12")
    };

    public static bool IsLeapYear(int year) =>
        (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0));

    public override string ToString() =>
        $"{day}/{month}/{year} {hour:D2}:{minute:D2}:{second:D2}";

    private void NormalizeDate()
    {
        while (day > DaysInMonth(month, year))
        {
            int daysInMonth = DaysInMonth(month, year);
            day -= daysInMonth;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }
    }

    private void NormalizeTime()
    {
        minute += second / 60;
        second %= 60;

        hour += minute / 60;
        minute %= 60;

        day += hour / 24;
        hour %= 24;

        NormalizeDate();
    }

    private bool IsDateInvalid()
    {
        if (month > 12 || year < 0 || (day > DaysInMonth(month, year)))
            return true;
        return false;
    }

    private bool IsTimeInvalid()
    {
        if (second > 59 || second < 0
            || minute < 0 || minute > 59 
            || hour < 0 || hour > 24)
            return true;
        return false;
    }

    private void CheckFormat()
    {
        if (IsDateInvalid()) throw new ArgumentException("Wrong date!");
        if (IsTimeInvalid()) throw new ArgumentException("Wrong time!");
    }

    private MyDate ShallowCopy() => (MyDate)MemberwiseClone();
}