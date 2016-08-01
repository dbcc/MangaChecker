using MangaChecker.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MangaChecker.Providers.Tests
{
    [TestClass]
    public class YoMangaTests
    {
        [TestMethod]
        public void GetChaptersYoMangaTest()
        {
            var _title = "Lady Garden";
            YoManga.SetRSSLink("http://yomanga.co/reader/feeds/rss");
            YoManga.SetTitle(_title);
            var g = YoManga.GetChapters(_title);

            var e = new List<MangaModel.MangaModel> {
                new MangaModel.MangaModel(
                    Settings.YoManga,
                    _title,
                    "10",
                    "http://yomanga.co/reader/read/lady_garden/en/0/10/",
                    "",
                    DateTime.Now),
                new MangaModel.MangaModel(
                    Settings.YoManga,
                    _title,
                    "9",
                    "http://yomanga.co/reader/read/lady_garden/en/0/9/",
                    "",
                    DateTime.Now),
                new MangaModel.MangaModel(
                    Settings.YoManga,
                    _title,
                    "8",
                    "http://yomanga.co/reader/read/lady_garden/en/0/8/",
                    "",
                    DateTime.Now),
            };

            if (g.Count == 0)
            {
                Assert.Fail();
            }

            var count = 0;
            foreach (var ex in e)
            {
                Assert.AreEqual(ex.Name, g[count].Name);
                Assert.AreEqual(ex.Chapter, g[count].Chapter);
                Assert.AreEqual(ex.Link, g[count].Link);
                count++;
            }
        }

        [TestMethod]
        public void GetLastChapterYoMangaTest()
        {
            var _title = "Lady Garden";
            YoManga.SetRSSLink("http://yomanga.co/reader/feeds/rss");
            YoManga.SetTitle(_title);
            var g = YoManga.GetChapters(_title);

            var e = new List<MangaModel.MangaModel> {
                new MangaModel.MangaModel(
                    Settings.YoManga,
                    _title,
                    "10",
                    "http://yomanga.co/reader/read/lady_garden/en/0/10/",
                    "",
                    DateTime.Now),
            };

             if (g.Count == 0)
            {
                Assert.Fail();
            }
            Assert.AreEqual(g[0].Name, e[0].Name);
            Assert.AreEqual(g[0].Chapter, e[0].Chapter);
        }
    }
}