using MangaChecker.Models;
using MangaChecker.Utility;
using System;
using System.Collections.Generic;

namespace MangaChecker.API.Providers
{
    public static class Mangastream
    {
        private static List<MangaModel> _allMangas;
        private static List<MangaModel> _getAllMangas()
        {
            _allMangas = new List<MangaModel>();
            var _rss = Tools.GetFeed(Settings.MangastreamURL, Settings.Mangastream);

            foreach (var item in _rss.Items)
            {
                var _manga = new MangaModel(Settings.Mangastream, item.Title.Text, item.Title.Text, item.Id, Settings.MangastreamURL, DateTime.Now);
                _manga = Parse.Chapter(Settings.Mangastream, _manga);
                _allMangas.Add(_manga);
            }

            return _allMangas;
        }

        public static List<MangaModel> GetChapters(string title)
        {
            var _mangas = new List<MangaModel>();

            _allMangas = _getAllMangas();

            foreach (var manga in _allMangas)
            {
                if (manga.Title == title)
                {
                    _mangas.Add(manga);
                }
            }
            return _mangas;
        }

        public static MangaModel GetLastChapter(string title)
        {
            _allMangas = _getAllMangas();

            foreach (var manga in _allMangas)
            {
                if (manga.Title == title)
                {
                    return manga;
                }
            }
            // implement
            return null;
        }
    }
}

