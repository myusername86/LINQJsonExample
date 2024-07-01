using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LINQJsonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData =
            """ 
            [{"Id":1,"ReducedVenue":false,"Date":"2022-10-16T00:00:00","Performer":"Ondricka, Walsh and Morissette","BeginsAt":18,"FullCapacitySales":1832880},
            {"Id":2,"ReducedVenue":false,"Date":"2023-07-09T00:00:00","Performer":"Ryan-Lynch","BeginsAt":12,"FullCapacitySales":1365810},
            {"Id":3,"ReducedVenue":false,"Date":"2023-06-19T00:00:00","Performer":"Williamson Group","BeginsAt":12,"FullCapacitySales":1691580},
            {"Id":4,"ReducedVenue":false,"Date":"2023-09-23T00:00:00","Performer":"Collier-Witting","BeginsAt":10,"FullCapacitySales":1913370},
            {"Id":5,"ReducedVenue":true,"Date":"2023-11-21T00:00:00","Performer":"Hettinger-Greenholt","BeginsAt":20,"FullCapacitySales":1089590},
            {"Id":6,"ReducedVenue":true,"Date":"2025-04-18T00:00:00","Performer":"Hansen Group","BeginsAt":13,"FullCapacitySales":1076040},
            {"Id":7,"ReducedVenue":true,"Date":"2022-10-15T00:00:00","Performer":"Schmidt, Witting and Skiles","BeginsAt":17,"FullCapacitySales":2713630},
            {"Id":8,"ReducedVenue":false,"Date":"2023-05-16T00:00:00","Performer":"Gibson, Hintz and Hagenes","BeginsAt":15,"FullCapacitySales":2050350},
            {"Id":9,"ReducedVenue":false,"Date":"2024-05-12T00:00:00","Performer":"Kirlin LLC","BeginsAt":19,"FullCapacitySales":1203390},
            {"Id":10,"ReducedVenue":true,"Date":"2025-09-01T00:00:00","Performer":"Weimann-Rippin","BeginsAt":14,"FullCapacitySales":1267490},
            {"Id":11,"ReducedVenue":true,"Date":"2025-09-21T00:00:00","Performer":"Hilll-Farrell","BeginsAt":19,"FullCapacitySales":979280},
            {"Id":12,"ReducedVenue":false,"Date":"2023-01-02T00:00:00","Performer":"Kuvalis Group","BeginsAt":14,"FullCapacitySales":2210270},
            {"Id":13,"ReducedVenue":false,"Date":"2025-02-13T00:00:00","Performer":"Jakubowski, Hagenes and Brekke","BeginsAt":14,"FullCapacitySales":2411540},
            {"Id":14,"ReducedVenue":true,"Date":"2024-05-09T00:00:00","Performer":"Kozey-Cruickshank","BeginsAt":13,"FullCapacitySales":2420460},
            {"Id":15,"ReducedVenue":false,"Date":"2023-03-07T00:00:00","Performer":"Green, Krajcik and Beahan","BeginsAt":12,"FullCapacitySales":3146700},
            {"Id":16,"ReducedVenue":false,"Date":"2024-08-22T00:00:00","Performer":"Gusikowski, Kertzmann and Stamm","BeginsAt":10,"FullCapacitySales":770840},
            {"Id":17,"ReducedVenue":false,"Date":"2023-09-11T00:00:00","Performer":"Prosacco Group","BeginsAt":15,"FullCapacitySales":3107510},
            {"Id":18,"ReducedVenue":true,"Date":"2023-01-13T00:00:00","Performer":"Stokes, Hackett and Wiza","BeginsAt":11,"FullCapacitySales":2138240},
            {"Id":19,"ReducedVenue":true,"Date":"2023-03-17T00:00:00","Performer":"Nolan-Stehr","BeginsAt":12,"FullCapacitySales":2319230},
            {"Id":20,"ReducedVenue":true,"Date":"2023-05-22T00:00:00","Performer":"Swift-Prosacco","BeginsAt":13,"FullCapacitySales":1660550},
            {"Id":21,"ReducedVenue":true,"Date":"2023-12-02T00:00:00","Performer":"Boehm, Mohr and Kohler","BeginsAt":10,"FullCapacitySales":1736830},
            {"Id":22,"ReducedVenue":true,"Date":"2024-04-21T00:00:00","Performer":"Cartwright, McDermott and Stracke","BeginsAt":18,"FullCapacitySales":1862910},
            {"Id":23,"ReducedVenue":false,"Date":"2024-06-25T00:00:00","Performer":"Wunsch-Becker","BeginsAt":18,"FullCapacitySales":1736780},
            {"Id":24,"ReducedVenue":true,"Date":"2025-06-28T00:00:00","Performer":"Lehner-Crist","BeginsAt":13,"FullCapacitySales":827960},
            {"Id":25,"ReducedVenue":false,"Date":"2024-04-15T00:00:00","Performer":"Kutch, Schmitt and Schmitt","BeginsAt":18,"FullCapacitySales":1138840}] 
            """;

            // Deserialize JSON data
            List<Event> events = JsonSerializer.Deserialize<List<Event>>(jsonData);

            // Perform LINQ operations
            var orderedEvents = events.OrderBy(e => e.Date).ToList();

            //1.Return a new List<Concert>order by Date value,going from the present date.
            Console.WriteLine("1.Events ordered by date:");
            Console.WriteLine("------------------------");
            foreach (var evt in orderedEvents)
            {
                Console.WriteLine($"Id: {evt.Id}, Performer: {evt.Performer}, Date: {evt.Date}, Sales: {evt.FullCapacitySales}");
            }

            //2.Reduced venue set to true

            var reducedVenueConcert = events.Where(e => e.ReducedVenue).ToList();

            

            Console.WriteLine("2.Concerts of reduced venue");
            Console.WriteLine("---------------------------");
            foreach (var RE in reducedVenueConcert)
            {
                Console.WriteLine($"Id:{RE.Id},Performer: {RE.Performer}, Date: {RE.Date}, Sales: {RE.FullCapacitySales}");
            }

            //3.Return a new List<Concert> with all concerts during 2024
            var During2024 = events.Where(e => e.Date.Year == 2024).ToList();
            Console.WriteLine("3.Event Happened in 2024");
            Console.WriteLine("------------------------");

            foreach (var D in During2024)
            {
                Console.WriteLine($"Id:{D.Id},Performer: {D.Performer}, Date: {D.Date}, Sales: {D.FullCapacitySales}");
            }

            //4.Return a new List<Concert> with the five biggest projected sales figures (the FullCapacitysale value)

            Console.WriteLine("4.Top five concerts by sales");
            Console.WriteLine("-----------------------------");


            var topFiveConcertsBySales = events
                .OrderByDescending(e => e.FullCapacitySales)
                .Take(5)
                .ToList();

            foreach (var TF in topFiveConcertsBySales)
            {
                Console.WriteLine($"Id:{TF.Id},Performer: {TF.Performer}, Date: {TF.Date}, Sales: {TF.FullCapacitySales}");
            }

            //5.Return a new list<Concert>with all concerts taking place on a Friday.

            Console.WriteLine("All the concerts took place on Friday");
            Console.WriteLine("-------------------------------------");

            
            var fridayConcerts = events
                .Where(e => e.Date.DayOfWeek == DayOfWeek.Friday)
                .ToList();

            foreach (var fri in topFiveConcertsBySales)
            {
                Console.WriteLine($"Id:{fri.Id},Performer: {fri.Performer}, Date: {fri.Date}, Sales: {fri.FullCapacitySales}");
            }








        }
    }

    public class Event
    {
        public int Id { get; set; }
        public bool ReducedVenue { get; set; }
        public DateTime Date { get; set; }
        public string Performer { get; set; }
        public int BeginsAt { get; set; }
        public int FullCapacitySales { get; set; }
    }
}
