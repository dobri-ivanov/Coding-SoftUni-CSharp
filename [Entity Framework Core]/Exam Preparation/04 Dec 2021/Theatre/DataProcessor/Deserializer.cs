namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var validGenres = new string[] { "Drama", "Comedy", "Romance", "Musical" };
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPlaysDto[] playsDtos = xmlHelper.Deserialize<ImportPlaysDto[]>(xmlString, "Plays");
            ICollection<Play> plays = new HashSet<Play>();

            foreach (var playDto in playsDtos)
            {
                var currentTime = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                TimeSpan timeSpan = TimeSpan.Parse("01:00:00");

                if (currentTime < timeSpan)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validGenres.Contains(playDto.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture),
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };
                plays.Add(play);
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCastsDto[] castsDtos = xmlHelper.Deserialize<ImportCastsDto[]>(xmlString, "Casts");
            ICollection<Cast> casts = new HashSet<Cast>();

            foreach (var castDto in castsDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = bool.Parse(castDto.IsMainCharacter),
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = int.Parse(castDto.PlayId)
                };
                casts.Add(cast);

                string type = String.Empty;
                if (cast.IsMainCharacter)
                {
                    type = "main";
                }
                else
                {
                    type = "lesser";
                }
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, type));
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTheatresDto[] theatresDtos = JsonConvert.DeserializeObject<ImportTheatresDto[]>(jsonString);
            ICollection<Theatre> theatres = new HashSet<Theatre>();

            foreach (var theatreDto in theatresDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!context.Plays.Any(p => p.Id == ticketDto.PlayId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }
                theatres.Add(theatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }
            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
