using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('_');
                Song song = new Song(data[0], data[1], data[2]);
                playlist.Add(song);
            }

            string input = Console.ReadLine();
            if (input == "all")
            {
                foreach (var song in playlist)
                {
                    Console.WriteLine(song.name);
                }
            }
            else
            {
                foreach (var song in playlist)
                {
                    if (song.type == input)
                    {
                        Console.WriteLine(song.name);
                    }
                }
            }

        }
    }

    class Song
    {
        public string type { get; set; }
        public string name { get; set; }
        public string time { get; set; }

        public Song(string type, string name, string time)
        {
            this.type = type;
            this.name = name;
            this.time = time;
        }
    }
}
