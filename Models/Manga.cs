﻿namespace RandaManga.Models
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
        public override string ToString()
        {
            string str= $"class: Manga name:{this.Name} description: {this.Description} type: {this.Type} status: {this.Status} tags[ ";
            foreach (var item in Tags)
            {
                str += item + ", ";
            }
            str = str.Remove(str.Length - 2);
            str += $" ] link:{this.Link} image path: {this.ImagePath}";
            return str ;
        }
    }
    enum MangaType {Manga,Manhwa, Manhua, Unknown };
    enum MangaStatus { Ongoing, Announcement, Completed, Suspended, Unknown };
}
