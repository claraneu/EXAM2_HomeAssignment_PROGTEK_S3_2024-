using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLibrary.Core
{
    public class TrophiesRepository
    {
        private readonly List<Trophy> _trophies = new();

        public TrophiesRepository() 
        {
            _trophies.Add(new Trophy("Iron Man", 2003));
            _trophies.Add(new Trophy("Iron Man", 1995));
            _trophies.Add(new Trophy("CPH Marathon", 2022));
            _trophies.Add(new Trophy("Berlin Marathon", 2007));
            _trophies.Add(new Trophy("CPH Halfmarathon", 2000));
        }


        //Returns list of all Trophy objects, filtered by year and/or sorted by year or competition
        public List<Trophy> Get(int? year = null, string sortBy = null) //optional parameters for sorting
        {
            //create deep copy
            List<Trophy> cTrophies = new List<Trophy>();
            foreach (Trophy trophy in _trophies)
            {
                cTrophies.Add(new Trophy(trophy));
            }

            /* // using LINQ instead
            return _trophies.Select(t => new Trophy(t)).ToList(); */

            // Filter by year if provided
            if (year.HasValue) //skipped if year = null
            {
                cTrophies = cTrophies.Where(t => t.Year == year.Value).ToList();
            }

            // Sort by Competition or Year based on the sortBy parameter
            cTrophies = sortBy switch
            {
                "Competition" => cTrophies.OrderBy(t => t.Competition).ToList(),
                "Year" => cTrophies.OrderBy(t => t.Year).ToList(),
                _ => cTrophies // No sorting if sortBy is not provided
            };


            return cTrophies;

        }

        public Trophy? GetById(int id)
        {
            if (id == 0)
            { return null;}
            Trophy trophy = _trophies.Find(t => t.Id == id);
            return trophy;
        }

        public Trophy? Add(Trophy trophy)
        {
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            Trophy trophy = GetById(id);

            //check if trophy is found with given Id
            if (trophy == null) 
            { return null; }

            //else remove trophy
            _trophies.Remove(trophy);
            return trophy;

        }

        public Trophy? Update(int id, Trophy newItem)
        {
            Trophy existingTrophy = GetById(id);
            if (existingTrophy == null)
            { return null;  }

            //else
            existingTrophy.Competition = newItem.Competition;
            existingTrophy.Year = newItem.Year;
            return newItem;

        }

    }
}
