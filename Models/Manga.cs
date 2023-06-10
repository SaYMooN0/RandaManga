namespace RandaManga.Models
{
    class Manga
    {
        public string Name { get; private set; } = "Default_Manga_Name";
        public string Description { get; private set; } = "Default_Manga_Description";
        public MangaType Type { get; private set; }= MangaType.Unknown;
        public MangaStatus Status { get; private set; }= MangaStatus.Unknown;
        public string[] Tags { get; private set; }=new string[1] { "No tags were found" };
        public string Link { get; private set; } = "No_Link_Was_Found";
        public string ImagePath { get; private set; } = @"~/images/mangaCovers/Default.png";
    }
    enum MangaType {Manga,Manhwa, Manhua, Unknown };
    enum MangaStatus { Ongoing, Announcement, Completed, Suspended, Unknown };
}
