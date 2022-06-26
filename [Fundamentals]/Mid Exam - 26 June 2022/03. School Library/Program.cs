using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = new List<string>();
            shelf = Console.ReadLine().Split('&').ToList();

            while (true)
            {
                string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0].Trim();
                if (command == "Done")
                {
                    break;
                }
                switch (command)
                {
                    case "Add Book":
                        string book = input[1].Trim();
                        Add(shelf, book);
                        break;
                    case "Take Book":
                        string book2 = input[1].Trim();
                        Take(shelf, book2);
                        break;
                    case "Swap Books":
                        string firstBook = input[1].Trim();
                        string secondBook = input[2].Trim();
                        Swap(shelf, firstBook, secondBook);
                        break;
                    case "Insert Book":
                        string newBook = input[1].Trim();
                        InsertBook(shelf, newBook);
                        break;
                    case "Check Book":
                        int index = int.Parse(input[1].Trim());
                        CheckBook(shelf, index);
                        break;
                    default:
                        break;
                }
            }
            Print(shelf);
        }

        static void Print(List<string> shelf)
        {
            Console.WriteLine(String.Join(", ", shelf));
        }

        static void CheckBook(List<string> shelf, int index)
        {
            if (index >= 0 && index < shelf.Count)
            {
                Console.WriteLine(shelf[index]);
            }
        }

        static void InsertBook(List<string> shelf, string book)
        {
            foreach (string checkedBook in shelf)
            {
                if (checkedBook == book)
                {
                    return;
                }
            }
            shelf.Add(book);
        }

        static void Swap(List<string> shelf, string firstBook, string secondBook)
        {
            bool hasBothBooks = false;
            int firstBookIndex = -1;
            int secondBookIndex = -1;

            for (int i = 0; i < shelf.Count; i++)
            {
                if (shelf[i] == firstBook)
                {
                    firstBookIndex = i;
                }

                if (shelf[i] == secondBook)
                {
                    secondBookIndex = i;
                }
            }

            if (firstBookIndex != -1 && secondBookIndex != -1)
            {
                hasBothBooks = true;
            }

            //Code
            if (hasBothBooks)
            {
                shelf[secondBookIndex] = firstBook;
                shelf[firstBookIndex] = secondBook;
            }
        }

        static void Take(List<string> shelf, string book)
        {
            for (int i = shelf.Count - 1; i >= 0; i--)
            {
                if (shelf[i] == book)
                {
                    shelf.Remove(book);
                    return;
                }
            }
        }

        static void Add(List<string> shelf, string book)
        {
            foreach (string checkedBook in shelf)
            {
                if (checkedBook == book)
                {
                    return;
                }
            }
            shelf.Insert(0, book);
        }
    }
}
