using System;
using System.Collections;

class Concert : IComparer<Concert>
{
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public double Price { get; set; }

    public Concert()
    {
        
    }

    public Concert(string title, string location, DateTime date, TimeSpan time, double price)
    {
        Title = title;
        Location = location;
        Date = date;
        Time = time;
        Price = price;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nLocation: {Location}\nDate: {Date.ToShortDateString()} Time: {Time}\nPrice: {Price}\n";
    }

    public static bool operator ==(Concert concert1, Concert concert2)
    {
        if (ReferenceEquals(concert1, null))
            return ReferenceEquals(concert2, null);

        return concert1.Equals(concert2);
    }
    
    public static bool operator !=(Concert concert1, Concert concert2)
    {
        return !(concert1 == concert2);
    }

    public static bool operator <(Concert concert1, Concert concert2)
    {
        return concert1.Price < concert2.Price;
    }

    public static bool operator >(Concert concert1, Concert concert2)
    {
        return concert1.Price > concert2.Price;
    }

    public static Concert operator ++(Concert concert)
    {
        concert.Price += 5;
        return concert;
    }

    public static Concert operator --(Concert concert)
    {
        concert.Price -= 5;
        return concert;
    }

    public int Compare(Concert concert1, Concert concert2)
    {
        return concert1.Price.CompareTo(concert2.Price);
    }


}

class ConcertComparer : IComparer
{
    public int Compare(object x, object y)
    {
        if (x is Concert && y is Concert)
        {
            return ((Concert)x).Price.CompareTo(((Concert)y).Price);
        }
        throw new ArgumentException();
    }
}


class Program
{
    static void Main()
    {
        ArrayList concerts = new ArrayList
        {
            new Concert("haloo helsinki", "helsinki", DateTime.Now, TimeSpan.Parse("19:00"), 50.0),
            new Concert("cledos", "ruotsin laiva", DateTime.Now, TimeSpan.Parse("20:00"), 40.0),
            new Concert("robin", "roskis", DateTime.Now, TimeSpan.Parse("21:00"), 60.0),
            new Concert("egezulu", "vaasa", DateTime.Now, TimeSpan.Parse("18:30"), 35.0),
            new Concert("puistopojat", "olumpiastadion", DateTime.Now, TimeSpan.Parse("19:30"), 100.0)
        };

        Console.WriteLine("Original List of Concerts:");
        foreach (Concert concert in concerts)
        {
            Console.WriteLine(concert);
        }

        // Sort the list by price (ascending)
        concerts.Sort(new ConcertComparer());

        Console.WriteLine("\nConcerts Sorted by Price:");
        foreach (Concert concert in concerts)
        {
            Console.WriteLine(concert);
        }

        Console.WriteLine("\noperators and methods:");
        Concert concert1 = (Concert)concerts[0];
        Concert concert2 = (Concert)concerts[1];

        // == operator
        Console.WriteLine("concert1 == concert2: " + (concert1 == concert2));

        // < and > operators
        Console.WriteLine("concert1 < concert2: " + (concert1 < concert2));
        Console.WriteLine("concert1 > concert2: " + (concert1 > concert2));

        // ++ and -- operators
        Console.WriteLine("price of concert1: " + concert1.Price);
        concert1++;
        Console.WriteLine("price of concert1 after ++: " + concert1.Price);
        concert1--;
        Console.WriteLine("price of concert1 after --: " + concert1.Price);
    }
}
