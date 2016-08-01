using System;
using System.Runtime.InteropServices.WindowsRuntime;
using PropertyChanged;

namespace MangaChecker.MangaModel
{
    [ImplementPropertyChanged]
    public class MangaModel
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        //public string Cover { get; set; }
        public string Name { get; set; }
        public string FullName => $"{Name} {Chapter}";
        public string Chapter { get; set; }
        public string Link { get; set; }
        public string RSS { get; set; }
        public DateTime Updated { get; set; }
        public bool Read { get; set; }

        public MangaModel(string provider, string name, string chapter, string link, string rss = "placeholder", DateTime updated = default(DateTime))
        {
            Provider = provider;
            Name = name;
            Chapter = chapter;
            Link = link;
            RSS = rss;
            Updated = updated;
            Read = false;
        }

        public MangaModel() {
        }
    }
}
