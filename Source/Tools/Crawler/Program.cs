namespace Crawler
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using AngleSharp;
    using PickUp.Data;
    using PickUp.Data.Common;
    using PickUp.Data.Models;

    public static class Program
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();
            var repo = new DbRepository<Location>(db);

            var streamer = new StreamReader("../../data/cities.txt", Encoding.Default, true);

            using (streamer)
            {
                while (streamer.ReadLine() != null)
                {
                    string currentLine = streamer.ReadLine();

                    var location = new Location()
                    {
                        Name = currentLine
                    };

                    Console.WriteLine(currentLine);

                    db.Locations.Add(location);
                    db.SaveChanges();
                }
            }

            Console.ReadLine();
        }
    }
}
