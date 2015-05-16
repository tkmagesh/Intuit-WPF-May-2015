using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GreetingApp.tests
{
    
    [TestFixture]
    public class GreeterTests
    {
        [TestCase]
        
        public void Should_Initilize_Name_With_Empty_String()
        {
            //Arrange
            var mockery = new Moq.Mock<ITimeService>();
            var timeService = mockery.Object;

            var greeter = new Greeter(timeService);

            //Act

            //Assert
            Assert.AreEqual(string.Empty, greeter.Name);
        }
        [TestCase]
        public void Should_Initilize_Message_With_Empty_String()
        {
            //Arrange
            var mockery = new Moq.Mock<ITimeService>();
            var timeService = mockery.Object;

            var greeter = new Greeter(timeService);


            //Act

            //Assert
            Assert.AreEqual(string.Empty, greeter.Message);
        }

        [TestCase]
        public void Should_Greet_With_Morning_Message_When_Greeted_Before_12()
        {
            //Arrange
            var mockery = new Moq.Mock<ITimeService>();
            mockery.Setup(ts => ts.GetCurrentTime()).Returns(new DateTime(2015, 5, 16, 9, 0, 0));
            var timeService = mockery.Object;

            var greeter = new Greeter(timeService);

            var expectedMessage = "Hi Magesh, Good Morning!";
            //Act
            greeter.Name = "Magesh";
            greeter.Greet();
            //Assert
            Assert.AreEqual(expectedMessage, greeter.Message);

            
        }

        [TestCase]
        public void Should_Greet_With_Evening_Message_When_Greeted_After_12()
        {
            //Arrange
            var mockery = new Moq.Mock<ITimeService>();
            mockery.Setup(ts => ts.GetCurrentTime()).Returns(new DateTime(2015, 5, 16, 19, 0, 0));
            var timeService = mockery.Object;

            var greeter = new Greeter(timeService);

            var expectedMessage = "Hi Magesh, Good Evening!";
            //Act
            greeter.Name = "Magesh";
            greeter.Greet();
            //Assert
            Assert.AreEqual(expectedMessage, greeter.Message);
        }
    }
}
