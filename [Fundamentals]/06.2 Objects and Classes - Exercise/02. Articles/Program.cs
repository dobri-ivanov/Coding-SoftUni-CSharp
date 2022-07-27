using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split(": ",StringSplitOptions.RemoveEmptyEntries);
                string command = token[0];
                string data = token[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(data);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(data);
                        break;
                    case "Rename":
                        article.Rename(data);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(article.ToString()); ;
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return String.Format($"{Title} - {Content}: {Author}");
        }
    }
}
