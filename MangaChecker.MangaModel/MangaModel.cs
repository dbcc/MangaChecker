using System;

namespace MangaChecker.Models
{
    public class MangaModel
    {
        public string Provider { get; set; }
        //public string Cover { get; set; }
        public string Title { get; set; }
        public string Chapter { get; set; }
        public string Link { get; set; }
        public string RSS { get; set; }
        public DateTime Updated { get; set; }
        public bool Read { get; set; }

        public MangaModel(string provider, string title, string chapter, string link, string rss, DateTime updated)
        {
            Provider = provider;
            Title = title;
            Chapter = chapter;
            Link = link;
            RSS = rss;
            Updated = updated;
            Read = false;
        }

        public MangaModel()
        {
        }
    }
}
