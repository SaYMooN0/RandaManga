
using System.ComponentModel.DataAnnotations.Schema;


namespace RandaManga.Models
{
    [Table("MangaCatalog")]
    public class Manga
    {
        public int Id { get; set; } 
        public string Name { get; private set; } = "Default_Manga_Name";
        public string Description { get; private set; } = "Default_Manga_Description";
        public string Author { get; private set; } = "Default_Author";
        
        public MangaType Type { get; private set; } = MangaType.Unknown;
        public MangaStatus Status { get; private set; } = MangaStatus.Unknown;
        public string Link { get; private set; } = "No_Link_Was_Found";
        public string ImagePath { get; private set; } = @"/images/mangaCovers/Default.png";
        public string AgeLimit { get; private set; } = "Default_Age_Limit";
        public int ReleaseYear { get; private set; } = -1;
        [NotMapped]
        public string[] Tags { get; private set; } = new string[0];
        private string _tagsString = "No tags";
        public string TagsString
        {
            get { return _tagsString; }
            set
            {
                _tagsString = value;
                Tags = _tagsString.Split(',');
            }
        }
        public Manga(string name, string description, MangaType type, MangaStatus status, string TagsString, string link, string imagePath, string author, string AgeLimit, int ReleaseYear)
        {
            Name = name;
            Description = description;
            Type = type;
            Status = status;
            this.TagsString = TagsString;
            Tags = TagsString.Split(",");
            Link = link;
            ImagePath = imagePath;
            Author = author;
            this.AgeLimit = AgeLimit;
            this.ReleaseYear = ReleaseYear;
        }


        public override string ToString()
        {
            string str = $"class: Manga name:{this.Name}  description: {this.Description} type: {this.Type} status: {this.Status} tags[ {this.TagsString} ] link:{this.Link} image path: {this.ImagePath} author: {this.Author} age limit: {this.AgeLimit} release year: {this.ReleaseYear}";
            return str;
        }
    }
    public enum MangaType { Manga, Manhwa, Manhua, Unknown };
    public enum MangaStatus { Ongoing, Announcement, Completed, Suspended, Unknown };
}
