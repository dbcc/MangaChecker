﻿using System.Collections.Generic;
using MangaChecker.Utility;

namespace MangaChecker.Providers
{
    public static class YoManga
    {
        private static List<MangaModel.MangaModel> _allMangas;
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

        private static List<MangaModel.MangaModel> _getAllMangas()
        {
            _allMangas = new List<MangaModel.MangaModel>();
            var _rss = Tools.GetFeed(_RSSURL, Settings.YoManga);

            foreach (var item in _rss.Items)
            {
                var _manga = new MangaModel.MangaModel(Settings.YoManga, item.Title.Text, item.Title.Text, item.Links[0].Uri.AbsoluteUri, Settings.YoManga, System.DateTime.Now);
                _manga = Parse.Chapter(Settings.YoManga, _manga);
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
                if (manga.Name == title)
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
            return null;
        }
    }
}
