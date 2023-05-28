namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
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

            int producerId = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportAlbumsInfo(context, producerId));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var producerInfo = context.Producers
                                .Where(p => p.Id == producerId)
                                .Select(p => new
                                {
                                    Albums = p.Albums
                                        .Select(al => new
                                        {
                                            al.Name,
                                            ReleaseDate = al.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                            ProducerName = al.Producer.Name,
                                            Songs = al.Songs
                                                    .Select(s => new
                                                    {
                                                        s.Name,
                                                        Price = $"{s.Price:f2}",
                                                        WriterName = s.Writer.Name,
                                                    }).OrderByDescending(s => s.Name).ThenBy(x => x.WriterName),
                                            TotalAlbumPrice = $"{al.Price:f2}"
                                        }).OrderByDescending(x => x.TotalAlbumPrice)
                                }).ToList();

            foreach (var producer in producerInfo)
            {
                foreach (var album in producer.Albums)
                {
                    sb.AppendLine($"-AlbumName: {album.Name}");
                    sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                    sb.AppendLine($"-ProducerName: {album.ProducerName}");
                    int counter = 1;
                    foreach (var song in album.Songs)
                    {
                        sb.AppendLine($"---#{counter}");
                        sb.AppendLine($"---SongName: {song.Name}");
                        sb.AppendLine($"---Price: {song.Price}");
                        sb.AppendLine($"---Writer: {song.WriterName}");

                        counter++;
                    }
                    sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
                }
            }
            return sb.ToString().TrimEnd();
        }


        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Select(x => new
                {
                    SongName = x.Name,
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration,
                    PerformerFullName = x.SongPerformers
                .Select(p => p.Performer.FirstName + " " + p.Performer.LastName)
                .FirstOrDefault()
                })
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .OrderBy(s => s.SongName)
                .ThenBy(w => w.WriterName)
                .ThenBy(p => p.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();

            var counter = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
