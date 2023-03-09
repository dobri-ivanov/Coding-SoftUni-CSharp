namespace MusicHub;

using System;
using System.Globalization;
using System.Text;
using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        //Database initializing
        DbInitializer.ResetDatabase(context);

        //Test your solutions here

        //Problem 2
        Console.WriteLine(ExportAlbumsInfo(context, 9));
        //Problem 3
        Console.WriteLine(ExportSongsAboveDuration(context, 4));
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {

        var albums = context.Albums
            .Where(a => a.ProducerId == producerId)
            .Select(a => new
            {
                Name = a.Name,
                ReleaseDate = a.ReleaseDate,
                ProducerName = a.Producer.Name,
                Songs = a.Songs.Select(s => new
                {
                    Name = s.Name,
                    Price = s.Price,
                    WriterName = s.Writer.Name
                })
                .OrderByDescending(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray(),
                TotalAlbumPrice = a.Price
            })
            .ToArray()
            .OrderByDescending(a => a.TotalAlbumPrice)
            .ToArray();

        StringBuilder sb = new StringBuilder();
        foreach (var a in albums)
        {
            sb.AppendLine($"-AlbumName: {a.Name}");
            sb.AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"-ProducerName: {a.ProducerName}");
            sb.AppendLine($"-Songs:");

            int songNumber = 1;
            foreach (var s in a.Songs)
            {
                sb.AppendLine($"---#{songNumber}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Price: {s.Price:f2}");
                sb.AppendLine($"---Writer: {s.WriterName}");
                songNumber++;
            }
            sb.AppendLine($"-AlbumPrice: {a.TotalAlbumPrice:f2}");
        }

        return sb.ToString().TrimEnd();


    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {

        var songs = context.Songs
            .AsEnumerable()
            .Where(s => s.Duration.TotalSeconds > duration)
            .Select(s => new
            {
                Name = s.Name,
                Performers = s.SongPerformers
                .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                .OrderBy(name => name)
                .ToList(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album.Producer.Name,
                Duration = s.Duration
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName)
            .ToList();


        StringBuilder sb = new StringBuilder();

        int songNumber = 1;
        foreach (var s in songs)
        {
            sb.AppendLine($"-Song #{songNumber++}");
            sb.AppendLine($"---SongName: {s.Name}");
            sb.AppendLine($"---Writer: {s.WriterName}");

            if (s.Performers.Any())
            {
                sb.AppendLine(String.Join(Environment.NewLine, s.Performers.Select(p => $"---Performer: {p}")));
            }

            sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
            sb.AppendLine($"---Duration: {s.Duration.ToString("c")}");
        }

        return sb.ToString().TrimEnd();

    }
}
