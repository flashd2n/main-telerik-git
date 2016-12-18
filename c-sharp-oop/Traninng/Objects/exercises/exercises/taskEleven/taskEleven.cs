using System;
using System.Text;

namespace taskEleven
{
    class taskEleven
    {
        private static string[] LaudatoryPhrase = new string[] { "The product is excellent.", "This is a great product.", "I use this product constantly.", "This is the best product from this category." };
        private static string[] LaudatoryStory = new string[] { "Now I feel better.", "I managed to change.", "It made some miracle.", "I can’t believe it, but now I am feeling great.", "You should try it, too. I am very satisfied." };
        private static string[] FirstName = new string[] { "Dayan", "Stella", "Hellen", "Kate" };
        private static string[] LastName = new string[] { "Johnson", "Peterson", "Charls" };
        private static string[] Cities = new string[] { "London", "Paris", "Berlin", "New York", "Madrid" };
        private static Random rnd = new Random();

        static void Main()
        {
            var adMessage = new StringBuilder();

            AddRandomPhrase(adMessage);
            adMessage.Append(" ");
            AddRandomStory(adMessage);
            adMessage.Append(" -- ");
            AddRandomName(adMessage);
            adMessage.Append(", ");
            AddRandomCity(adMessage);
            Console.WriteLine(adMessage);
        }

        private static void AddRandomCity(StringBuilder adMessage)
        {
            int index = rnd.Next(Cities.Length);
            adMessage.Append(Cities[index]);
        }

        private static void AddRandomName(StringBuilder adMessage)
        {
            int index = rnd.Next(FirstName.Length);
            adMessage.Append(FirstName[index]);
            adMessage.Append(" ");
            index = rnd.Next(LastName.Length);
            adMessage.Append(LastName[index]);
        }

        private static void AddRandomStory(StringBuilder adMessage)
        {
            int index = rnd.Next(LaudatoryStory.Length);
            adMessage.Append(LaudatoryStory[index]);
        }

        private static void AddRandomPhrase(StringBuilder adMessage)
        {
            int index = rnd.Next(LaudatoryPhrase.Length);
            adMessage.Append(LaudatoryPhrase[index]);
        }


    }
}
