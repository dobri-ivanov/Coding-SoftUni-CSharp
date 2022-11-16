using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] cardTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < cardTokens.Length; i++)
            {
                string face = cardTokens[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).First();
                string suit = cardTokens[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).First();

                try
                {
                    Validator.ValidateCard(face, suit);
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(" ", cards));
        }
    }
    class Card
    { 
        public string Face { get; set; }
        public string Suit { get; set; }

        public Card(string face, string suit)
        {
            Face = face;
            Suit = GetSuit(suit);
        }
        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }

        public string GetSuit(string suit)
        {
            if (suit == "S") return "\u2660";
            if (suit == "H") return "\u2665";
            if (suit == "D") return "\u2666";
            if (suit == "C") return "\u2663";
            return null;
        }
    }
    class Validator
    {
        public static void ValidateCard(string face, string suit)
        {
            List<string> possibleFaces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            if (!possibleFaces.Any(c => c == face))
            {
                throw new ArgumentException("Invalid card!");
            }

            List<string> possibleSuits = new List<string>() { "S", "H", "D", "C" };
            if (!possibleSuits.Any(c => c == suit))
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }
}
