using BlazorApp.Client.Abstractions.Models;
using BlazorApp.Client.Services;
using Moq;

namespace BlazorApp.UnitTests
{
    public class PersonServiceTests
    {
        [Fact]
        public void PrintNameTesting()
        {
            // Arrange
            var person = new Mock<IPerson>();
            person.SetupProperty(p => p.Name, "George");
            var service = new PersonServices();

            using var sw = new System.IO.StringWriter();
            Console.SetOut(sw);

            // Act
            service.PersonPrinter(person.Object);

            // Assert
            var output = sw.ToString().Trim();
            Assert.Equal("Name: George", output);
        }

        [Fact]
        public void PrintName_GenericType_WritesCorrectOutput()
        {
            // Arrange
            var person = new TestNamedPerson { Name = "George" };
            var service = new PersonServices();

            using var sw = new System.IO.StringWriter();
            Console.SetOut(sw);

            // Act
            service.PersonPrinter<TestNamedPerson>(person);

            // Assert
            var output = sw.ToString().Trim();
            Assert.Equal("Name: George", output);
        }

        private class TestNamedPerson : IPerson
        {
            public string Name { get; set; } = string.Empty;
        }
    }
}