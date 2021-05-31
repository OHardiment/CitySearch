
using System.Collections.Generic;
using System.Linq;

namespace CitySearch
{

    

    class CityResult : ICityResult
    {

        string[] foundCities;
        string searchString;
        List<string> letters = new List<string>();
        List<string> cities = new List<string>();

        public CityResult(string[] passedCities, string passedString)
        {

            foundCities = (string[]) passedCities.Clone();
            searchString = passedString;
            letters = FindLetters();
            cities = foundCities.ToList();
            
        }
        public CityResult()
        {

        }
        //this works out what the next potential letters are
        public ICollection<string> NextLetters { 
            get
            {
                return letters;
            }
            set 
            {
                letters = FindLetters();
            }
        }
        //this just returns the array of found cities as a list
        public ICollection<string> NextCities { 
            get
            {
                return cities;
            }
            set
            {
                cities = foundCities.ToList();
            } }
        //if the search string and city string length are the same, then the search string already is the city name, so there are no extra characters
        //if the found city has a letter at the end of the substring of searchstring that is unique to all the potential letters before, add it to the list
        //if not unique, just ignore, as the letter has already been counted.
        private List<string> FindLetters() 
        {
            

            for (int i = 0; i < foundCities.Length; i++)
            {

                if (foundCities[i].Length == searchString.Length)
                {
                    continue;
                }

                if (i == 0)
                {
                    letters.Add(foundCities[i].Substring(searchString.Length, 1).ToLower());
                }
                else if (!letters.Contains(foundCities[i].Substring(searchString.Length, 1).ToLower()))
                {
                    letters.Add(foundCities[i].Substring(searchString.Length, 1).ToLower());
                }
                // this is a test that would check if all possible character are already in the list, since if they are, we can end early
                // this would probably require more computation and input checking than it would save in niche situations, so is probably unnecessary
                /*if (letters.Count == 28)
                {
                    break;
                }*/
            }

            return letters;
        }
    }
}