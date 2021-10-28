using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ3
{
    class City {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPopulation { get; set; }
    }

    enum CityType { City,Settlemnt}
    class Program
    {


        static List<City> list=new List<City>();
        static void Main(string[] args)
        {
            list.Add(new City() { Id = 1, Name = "Jerusalem", NumberOfPopulation = 1000000 });
            list.Add(new City() { Id = 2, Name = "Kiryat Shmonah", NumberOfPopulation = 23000 });

            //var query = list.Select(c => new {c.Name, IsCity = c.NumberOfPopulation > 25000 });
            var listOfCS = GetListOfCitiesAnSettlemnts();

            foreach (dynamic item in listOfCS)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static IEnumerable GetListOfCitiesAnSettlemnts()
        {
            var query = list.Select(city => new 
            { 
                city.Name,
                CityType = city.NumberOfPopulation > 25000 ?
                         CityType.City : CityType.Settlemnt 
            });
            var listOfAnonymus = query.ToList();
            return listOfAnonymus;
        }
    }
}
