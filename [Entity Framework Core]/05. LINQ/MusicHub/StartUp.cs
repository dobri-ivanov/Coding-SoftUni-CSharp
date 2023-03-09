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

        DbInitializer.ResetDatabase(context);

        //Test your solutions here
        Console.WriteLine(ExportAlbumsInfo(context, 9));
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
        throw new NotImplementedException();
    }
}
