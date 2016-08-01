using System.Collections.Generic;
using MangaChecker.Utility;

namespace MangaChecker.API.Providers
{
    public static class Batoto
    {
        private static string _RSSURL;
        public static void SetRSSLink(string link)
        {
            if (link != "")
            {
                _RSSURL = link;
            }
        }
        private static List<MangaModel.MangaModel> _allMangas;
        private static List<MangaModel.MangaModel> _getAllMangas()
        {
            _allMangas = new List<MangaModel.MangaModel>();
            var _rss = Tools.GetFeed(_RSSURL, Settings.Batoto);

            foreach (var item in _rss.Items)
            {
                var _manga = new MangaModel.MangaModel(Settings.Batoto, item.Title.Text, item.Title.Text, item.Links[0].Uri.AbsoluteUri, Settings.Batoto, item.PublishDate.DateTime);
                _manga = Parse.Chapter(Settings.Batoto, _manga);
                _allMangas.Add(_manga);
            }

            return _allMangas;
        }

        public static List<MangaModel.MangaModel> GetChapters(string title)
        {
            var _mangas = new List<MangaModel.MangaModel>();

            _allMangas = _getAllMangas();

            foreach (var manga in _allMangas)
            {
                if (manga.Name.Contains(title))
                {
                    _mangas.Add(manga);
                }
            }
            return _mangas;
        }

        public static MangaModel.MangaModel GetLastChapter(string title)
        {
            _allMangas = _getAllMangas();

            foreach (var manga in _allMangas)
            {
                if (manga.Name == title)
                {
                    return manga;
                }
            }
            // implement
            return null;
        }
    }
}
