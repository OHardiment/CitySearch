using System;
using System.Collections;
using System.IO;

namespace CitySearch
{
    class TestClass
    {

        

        static public void Main(String[] args)
        {
            string[] cities = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\cities.txt");
            
            string search = Console.ReadLine();

            
            //test to give user input a test, can be used to test anything
            TestRun(search, cities);
            //boundary test on very first variable in array
            search = "a";
            TestRun(search, cities);
            //check to ensure upper and lowercase letters are treated the same
            search = "A";
            TestRun(search, cities);
            //boundary test on very last variable in array
            search = "z";
            TestRun(search, cities);
            //check to ensure upper and lowercase letters are treated the same
            search = "Z";
            TestRun(search, cities);
            //check on normal working conditions
            search = "Che";
            TestRun(search, cities);
            //check on normal working conditions but all uppercase
            search = "CHE";
            TestRun(search, cities);
            //check on both boundary and excessive size to see how it handles being given a longer searchstring than city name
            search = "aaaaaaaaaaaaaaaaa";
            TestRun(search, cities);
            //check on both boundary and excessive size to see how it handles being given a longer searchstring than city name
            search = "zzzzzzzzzzzzzzzz";
            TestRun(search, cities);
            //check on accepting on space
            search = " ";
            TestRun(search, cities);
            //check on accepting only -
            search = "-";
            TestRun(search, cities);
            //check on whether it can get cities with spaces
            search = "La ";
            TestRun(search, cities);
            //check on same as above but with lower vs uppercase
            search = "la ";
            TestRun(search, cities);
            //check on whether it can get cities with -
            search = "Winston";
            TestRun(search, cities);
            //check on same as above but with lower vs uppercase
            search = "winston";
            TestRun(search, cities);
            //check response to nonsense (in this case integer) search string
            search = "1";
            TestRun(search, cities);
            //check response to nonsense + long search string
            search = "111111111111111111";
            TestRun(search, cities);
            //check response to zero length search string
            search = "";
            TestRun(search, cities);

            Console.ReadLine();

        }

       

        public static void TestRun(string searchString, string[] cities) 
        {

            Main TestMain = new Main(cities);

            CityResult cr = new CityResult();
            
            cr = (CityResult) TestMain.Search(searchString);

            Console.WriteLine(searchString);
            Console.WriteLine();

            foreach (string letter in cr.NextLetters)
            {
               Console.WriteLine(letter);
            }

            Console.WriteLine();

            foreach (string city in cr.NextCities)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine("-------------------");

        }



    }
}
