using System;
using System.Collections.Generic;
using System.Linq;

namespace CitySearch
{
    class Main : ICityFinder
   //class Main
    {

        public string[] loadedCities;

        public Main(string[] cities)
        {

            // sort the array first since setup time doesn't matter
            loadedCities = (string[]) cities.Clone();
            Array.Sort(loadedCities);
        }


        public ICityResult Search(string searchString)
        {

            //do a binary search on the cities to find one that matches
            int foundIndex = binarySearch(searchString, 0, loadedCities.Length - 1);
            int startIndex = foundIndex;
            int endIndex = foundIndex;
            
            bool first = false;
            bool last = false;


            //linearly step back from the match until a non match, indicating the first match in the array
            //considered making this multiple binary searches but don't think it would affect the Big O so didn't end up doing it
            //multiple binary searches could've affected the average runtime, i'm not 100% so this would be something to explore.
            if (foundIndex == -1)
            {
                CityResult empty = new CityResult();
                return empty;
            }

            while (first == false)
            {   
                
                if (startIndex == 0)
                {
                    first = true;
                    break;
                }
                if (loadedCities[startIndex - 1].Length < searchString.Length)
                {
                    first = true;
                } 
                else if (loadedCities[startIndex].Substring(0, searchString.Length).Equals(loadedCities[startIndex - 1].Substring(0, searchString.Length)))
                {
                    startIndex -= 1;
                }
                else
                {
                    first = true;
                }
            }
            
            //same as above, but stepping forwards until the end of the matches in the array
            while (last == false)
            {

                if (endIndex == loadedCities.Length - 1)
                {
                    last = true;
                    break;
                }

                if (loadedCities[endIndex + 1].Length < searchString.Length)
                {
                    last = true;
                }
                
                else if (loadedCities[endIndex].Substring(0, searchString.Length).Equals(loadedCities[endIndex + 1].Substring(0, searchString.Length)))
                {
                    endIndex += 1;
                }
                else
                {
                    last = true;
                }
            }

            //create a new array with only the matched cities in it.
            string[] foundCities = new string[endIndex - startIndex + 1];
            Array.Copy(loadedCities, startIndex, foundCities, 0, foundCities.Length);

            //create a CityResult, passing in the array and the searchstring, then return it
            CityResult cr = new CityResult(foundCities, searchString);

            return cr;
        }

        public int binarySearch(string searchString, int l, int r)
        {
            
            //writing my own binary search here.
            string toCompare = searchString;

            if (r >= l) 
            {
                int mid = l + (r - l) / 2;
 
                if (loadedCities[mid].Length < searchString.Length)
                {
                    toCompare = toCompare.Substring(0, loadedCities[mid].Length);
                }
                int comparison = String.Compare(toCompare, loadedCities[mid].Substring(0, toCompare.Length), comparisonType: StringComparison.OrdinalIgnoreCase);
                if (comparison == 0)
                {
                    return mid;
                }
                else if (comparison < 0)
                {
                    return binarySearch(searchString, l, mid - 1);
                }

                return binarySearch(searchString, mid + 1, r);
 
            }
 
        // We reach here when match is not found in array
        return -1;
            
        }

       

        



    }
}
