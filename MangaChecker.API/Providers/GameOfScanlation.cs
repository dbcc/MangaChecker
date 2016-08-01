using System.Collections.Generic;
using MangaChecker.Utility;

namespace MangaChecker.API.Providers
{
    public static class GameOfScanlation
    {
        private static List<MangaModel.MangaModel> _allMangas;
        private static string _RSSURL;
        private static string _title;

        public static void SetRSSLink(string link)
        {
            if (link != "")
            {
                _RSSURL = link;
            }
        }

        private static List<MangaModel.MangaModel> _getAllMangas()
        {
            _allMangas = new List<MangaModel.MangaModel>();
            var _rss = Tools.GetFeed(_RSSURL, Settings.GameOfScanlation);

            foreach (var item in _rss.Items)
            {
                var _manga = new MangaModel.MangaModel(Utility.Settings.GameOfScanlation, _rss.Title.Text, item.Title.Text, item.Links[0].Uri.AbsoluteUri, Settings.GameOfScanlation, System.DateTime.Now);
                _manga = Parse.Chapter(Settings.GameOfScanlation, _manga);
                _allMangas.Add(_manga);
            }

            return _allMangas;
        }

        public static List<MangaModel.MangaModel> GetChapters(string title)
        {
            _allMangas = _getAllMangas();
            return _allMangas;
        }

        public static MangaModel.MangaModel GetLastChapter(string title)
        {
            _allMangas = _getAllMangas();
            return _allMangas[0];
        }
    }
}
