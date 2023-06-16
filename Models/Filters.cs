namespace RandaManga.Models
{
    public class Filters
    {
        public SortedDictionary<string, bool> Tags { get; set; } = new();
        public int MinYear { get; set; } = 1970;
        public int MaxYear { get; set; } = 2023;
        public bool AgeRating18 { get; set; }
        public bool AgeRating16 { get; set; }
        public bool AgeRatingAbsent { get; set; }
        public bool Manga { get; set; }
        public bool Manhwa { get; set; }
        public bool Manhua { get; set; }
        public bool CheckByReleaseYear(int year)
        {
            if (year < MinYear) { return false; }
            if (year > MaxYear) { return false; }
            return true;
        }
        public bool CheckByAgeRaiting(AgeLimitType age) {
            if (!AgeRating18 && !AgeRating16 && !AgeRatingAbsent)
                return true;
            if (age==AgeLimitType.NoAgeLimit&& AgeRatingAbsent)
                return true;
            if (age == AgeLimitType.Age16 && AgeRating16)
                return true;
            if (age == AgeLimitType.Age18 && AgeRating18)
                return true;
            return false;
        }
        public bool CheckByType(MangaType type)
        {
            if (!Manga && !Manhwa && !Manhua)
                return true;
            if (type == MangaType.Manga && Manga)
                return true;
            if (type == MangaType.Manhwa && Manhwa)
                return true;
            if (type == MangaType.Manhua && Manhua)
                return true;
            return false;
        }


    }
}
