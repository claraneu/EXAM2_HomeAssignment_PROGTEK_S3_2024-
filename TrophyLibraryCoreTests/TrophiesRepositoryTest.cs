using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrophyLibrary.Core;

namespace TrophyLibraryCoreTests
{
    [TestClass]
    public class TrophiesRepositoryTest
    {
        //
        [TestMethod]
        public void Get_ShouldReturnTrophiesFilteredbyYear()
        {
            //Arrange
        
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            int testYear = 2003;
            
                //Expected Output
            List<Trophy> expectedOutput = new List<Trophy>
                {
                new Trophy("Iron Man", 2003)
                };

            //Act
            List<Trophy> result = trophiesRepository.Get(year: testYear);


            //Assert
            Assert.AreEqual(expectedOutput.Count, result.Count, "The count of trophies returned does not match.");
            Assert.AreEqual(expectedOutput[0].Competition, result[0].Competition, "The competition name does not match.");
            Assert.AreEqual(expectedOutput[0].Year, result[0].Year, "The trophy year does not match.");
        }


        [TestMethod]
        public void Get_ShouldReturnTrophiesSortedbyYear()
        {
            //Arrange
            TrophiesRepository trophiesRepository = new TrophiesRepository();
                //Expected Output
                List<Trophy> expectedOutput = new List<Trophy> 
                { 
                new Trophy("Iron Man", 1995),
                new Trophy("CPH Halfmarathon", 2000),
                new Trophy("Iron Man", 2003),
                new Trophy("Berlin Marathon", 2007),
                new Trophy("CPH Marathon", 2022)
                };
        

            //Act: Call the Get() method with "Year" as the sortBy parameter
            List<Trophy> result = trophiesRepository.Get(null, "Year");

            // Assert: Compare each trophy in the result with the expected output to ensure sorting is correct
                //for each index, check that both Competition and Year match
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                Assert.AreEqual(expectedOutput[i].Competition, result[i].Competition, $"Trophy at index {i} does not have the expected competition.");
                Assert.AreEqual(expectedOutput[i].Year, result[i].Year, $"Trophy at index {i} does not have the expected year.");
            }

        }

        [TestMethod]
        public void Get_ShouldReturnTrophiesSortedbyCompetition()
        {
            //Arrange
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            //Expected Output
            List<Trophy> expectedOutput = new List<Trophy>
                {
                new Trophy("Berlin Marathon", 2007),
                new Trophy("CPH Halfmarathon", 2000),
                new Trophy("CPH Marathon", 2022),
                new Trophy("Iron Man", 2003),                
                new Trophy("Iron Man", 1995)
         
                };


            //Act: Call the Get() method with "Year" as the sortBy parameter
            List<Trophy> result = trophiesRepository.Get(null, "Competition");

            // Assert: Compare each trophy in the result with the expected output to ensure sorting is correct
            //for each index, check that both Competition and Year match
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                Assert.AreEqual(expectedOutput[i].Competition, result[i].Competition, $"Trophy at index {i} does not have the expected competition.");
                Assert.AreEqual(expectedOutput[i].Year, result[i].Year, $"Trophy at index {i} does not have the expected year.");
            }

        }


    }

    

    
}
