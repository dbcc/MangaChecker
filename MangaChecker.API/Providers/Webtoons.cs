using MangaChecker.Models;
using MangaChecker.Utility;
using System;
using System.Collections.Generic;

namespace MangaChecker.API.Providers
{
    public static class Webtoons
    {
        private static List<MangaModel> _allMangas;
        private static string _RSSURL;
        private static string _title;

        public static void SetTitle(string title)
        {
            if (title != "")
            {
                _title = title;
            }
        }

        public static void SetRSSLink(string link)
        {
            if (link != "")
            {
                _RSSURL = link;
            }
        }

        private static List<MangaModel> _getAllMangas()
        {
            _allMangas = new List<MangaModel>();
            var _rss = Tools.GetFeed(_RSSURL, Settings.Webtoons);

            foreach (var item in _rss.Items)
            {
                var _manga = new MangaModel(Settings.Webtoons, item.Title.Text, item.Title.Text, item.Links[0].Uri.AbsoluteUri, Settings.Webtoons, DateTime.Now);
                _manga = Parse.Chapter(Settings.Webtoons, _manga);
                _allMangas.Add(_manga);
            }

            return _allMangas;
        }

        public static List<MangaModel> GetChapters(string title)
        {
            _allMangas = _getAllMangas();
            _allMangas.ForEach((m) => { m.Title = _title; });
            return _allMangas;
        }

        public static MangaModel GetLastChapter(string title)
        {
            _allMangas = _getAllMangas();
            _allMangas.ForEach((m) => { m.Title = _title; });
            return _allMangas[0];
        }
    }
}
