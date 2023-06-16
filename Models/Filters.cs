namespace RandaManga.Models
{
    public class Filters
    {
        public int MinYear { get; set; } = 1970;
        public int MaxYear { get; set; } = 2023;
        public bool AgeRating18 { get; set; }
        public bool AgeRating16 { get; set; }
        public bool AgeRatingAbsent { get; set; }
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


    }
}
