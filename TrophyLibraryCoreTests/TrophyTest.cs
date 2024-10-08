using System.Security.Principal;
using TrophyLibrary.Core;

namespace TrophyLibraryCoreTests
{
    [TestClass]
    public class TrophyTest
    {
        //test less than 3 char
        [TestMethod]
        public void validateCompetition_lessThan3Characters()
        {
            //Arrange
            string name_less3 = "IM";
            Trophy trophy = new Trophy(name_less3, 90);

            //Act & Assert
            Assert.ThrowsException<System.ArgumentException>(() => trophy.validateCompetition(name_less3));
            
        }

        //test char
        [TestMethod]
        public void validateCompetition_null()
        {
            //Arrange
            string? is_null = null;
            Trophy trophy = new Trophy(is_null, 1994);
            //Act & Assert
            Assert.ThrowsException<System.ArgumentException>(() => trophy.validateCompetition(is_null));

        }

        //Test Year b4 1969 or after 2024
        [TestMethod]
        public void validateYear_before1970()
        {
            //Arrange
            int year1 = 1969;
            Trophy trophy = new Trophy("Iron Man", year1);

            //Act&Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => trophy.validateYear(year1));
        }

        //Test Year after 2024

        [TestMethod]
        public void validateYear_after2024()
        {
            //Arrange
            int year2 = 2025;
            Trophy trophy = new Trophy("Iron Man", year2);

            //Act&Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => trophy.validateYear(year2));
        }

        //ToString
        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var trophy = new Trophy("Nordic Race", 2003);
            var expectedOutput = "{Id=1, Competition=Nordic Race, Year=2003}";

            // Act
            var result = trophy.ToString();

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

    }
}