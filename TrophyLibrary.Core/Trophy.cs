namespace TrophyLibrary.Core
{
   
    public class Trophy
    {
        private int _nextId = 1;
        
        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public Trophy(string competition, int year) 
        {
            Id = _nextId++;
            Competition = competition;
            Year = year;
        }

        //Copy constructor
        public Trophy(Trophy trophy)
        {
            Id = trophy.Id;
            Competition = trophy.Competition;
            Year = trophy.Year;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Competition)}={Competition}, {nameof(Year)}={Year.ToString()}}}";
        }

        //Competition, tekst-streng, min 3 tegn langt, må ikke være *null*
        public void validateCompetition(string competitionName)
        {
                if (string.IsNullOrEmpty(competitionName) || competitionName.Length < 3)
                    throw new ArgumentException("Competition must be at least 3 characters long and cannot be null: ", nameof(competitionName));
        }

        // Year, tal, 1970 <= year <= 2024
        public void validateYear(int year)
        {
            if (year <= 1970 || year >= 2024)
                throw new ArgumentOutOfRangeException("Year must be between 1970 and 2024");
        }
    }
}
//random comment to test Github
