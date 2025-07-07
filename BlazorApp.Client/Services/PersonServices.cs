using BlazorApp.Client.Abstractions.Models;
using BlazorApp.Client.Models;

namespace BlazorApp.Client.Services
{
    public class PersonServices
    {
        /// <summary>
        /// Prints the name of a person implementing the INamedPerson interface.
        /// </summary>
        /// <param name="person"></param>
        public string PersonPrinter(IPerson person)
        {
            return person switch
            {
                Employee => $"[Employee] {person.Name}",
                Manager => $"[Manager] {person.Name}",
                _ => person.Name
            };
        }

        /// Alternative method using generics
        /// <summary>
        /// Print the name of a person implementing the INamedPerson interface.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="person"></param>
        public string PersonPrinter<T>(T person) where T : IPerson
        {
            return person switch
            {
                Employee => $"[Employee] {person.Name}",
                Manager => $"[Manager] {person.Name}",
                _ => person.Name
            };
        }
    }
}
