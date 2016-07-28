using MangaChecker.Models;
using MangaChecker.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MangaChecker.API.Providers.Tests
{
    [TestClass]
    public class MangastreamTests
    {

        //<title>Bleach 683</title>
        //<link>http://mangastream.com/read/bleach/683/3549/1</link>
        //<pubDate>Thu, 21 Jul 2016 2:42:14 -0700</pubDate>
        //<description>The Dark Side of Two World Ends</description>
        //<guid isPermaLink = "true" > http://mangastream.com/r/bleach/683/3549/1</guid>

        [TestMethod]
        public void GetChaptersMangastreamTest()
        {
            var _title = "The Seven Deadly Sins";

            var g = Mangastream.GetChapters(_title);

            var e = new List<MangaModel> {
                new MangaModel(
                    Settings.Mangastream,
                    _title,
                    "185",
                    "http://mangastream.com/r/the_seven_deadly_sins/185/3560/1",
                    Settings.MangastreamURL,
                    DateTime.Now),
                new MangaModel(
                    Settings.Mangastream,
                    _title,
                    "Special",
                    "http://mangastream.com/r/the_seven_deadly_sins/Special/3546/1",
                    Settings.MangastreamURL,
                    DateTime.Now),
                new MangaModel(
                    Settings.Mangastream,
                    _title,
                    "184",
                    "http://mangastream.com/r/the_seven_deadly_sins/184/3542/1",
                    Settings.MangastreamURL,
                    DateTime.Now),
            };

            if (g.Count == 0)
            {
                Assert.Fail();
            }

            var count = 0;
            foreach (var got in g)
            {
                Assert.AreEqual(got.Title, e[count].Title);
                Assert.AreEqual(got.Chapter, e[count].Chapter);
                Assert.AreEqual(got.Link, e[count].Link);
                count++;
            }
        }

        [TestMethod]
        public void GetLastChapterMangastreamTest()
        {
            var _title = "Bleach";

            var g = Mangastream.GetChapters(_title);

            var e = new List<MangaModel> {
                new MangaModel(Settings.Mangastream, _title, "683", "http://mangastream.com/read/bleach/683/3549/1", Settings.MangastreamURL, DateTime.Now),
            };

            if (g.Count == 0)
            {
                Assert.Fail();
            }
            Assert.AreEqual(g[0].Title, e[0].Title);
            Assert.AreEqual(g[0].Chapter, e[0].Chapter);
        }
    }
}