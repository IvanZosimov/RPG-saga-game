namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class NamesGenerator
    {
        private readonly List<string> pullOfNames = new List<string>()
        {
            "Homer", "Bart", "Marge", "Mr.Burns", "Lisa", "Ned Flanders", "Millhouse", "Moe", "Nelson", "Krusty",
            "Principal Skinner", "Ralph", "Dr.Hilbert", "Martin Prince", "Willie", "Fat Tony", "Grandpa", "Selma",
            "Eric Cartman", "Kenny", "Stan", "Kyle", "Chef", "Morty", "Rick Sanchez", "Summer", "Bird Person",
            "SpongeBob", "Patrick Star", "Squidward", "Sandy Cheeks", "Mr.Krabs", "Plankton", "Gary", "Mrs.Puff",
        };

        public string GetRandomName()
        {
            return pullOfNames[Game.Rand.Next(pullOfNames.Count)];
        }
    }
}
