namespace Library.DataValidations
{
    public class DataConstants
    {
        public class Book
        {
            public const int BookMinTitle = 10;
            public const int BookMaxTitle = 50;

            public const int BookMinAuthor = 5;
            public const int BookMaxAuthor = 50;

            public const int BookMinDescription = 5;
            public const int BookMaxDescription = 5000;

            public const double BookMinRating = 0.00;
            public const double BookMaxRating = 10.00;
        }
        public class Category
        {
            public const int CategoryMinName = 5;
            public const int CategoryMaxName = 50;
        }
    }
}
