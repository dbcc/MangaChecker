using System;
using System.Collections.Generic;
using MangaChecker.Models;
using MangaChecker.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangaChecker.Providers.Tests
{
    [TestClass()]
    public class GameOfScanlationTests
    {
        [TestMethod()]
        public void GetChaptersGameOfScanlationTest()
        {
            var _title = "Trinity Wonder";
            GameOfScanlation.SetRSSLink("https://gameofscanlation.moe/projects/trinity-wonder/index.rss");

            var g = GameOfScanlation.GetChapters("Trinity Wonder");

            var e = new List<MangaModel> {
                new MangaModel(Settings.GameOfScanlation,
                    _title,
                    "20",
                    "https://gameofscanlation.moe/projects/trinity-wonder/chapter-20.2016/",
                    "https://gameofscanlation.moe/projects/trinity-wonder/index.rss",
                    DateTime.Now),
                new MangaModel(Settings.GameOfScanlation,
                    _title,
                    "19",
                    "https://gameofscanlation.moe/projects/trinity-wonder/chapter-19.1988/",
                    "https://gameofscanlation.moe/projects/trinity-wonder/index.rss",
                    DateTime.Now),
                new MangaModel(Settings.GameOfScanlation,
                    _title,
                    "18",
                    "https://gameofscanlation.moe/projects/trinity-wonder/chapter-18.1966/",
                    "https://gameofscanlation.moe/projects/trinity-wonder/index.rss",
                    DateTime.Now),
            };

            if (g.Count == 0)
            {
                Assert.Fail();
            }

            var count = 0;
            foreach (var expected in e)
            {
                Assert.AreEqual(expected.Title, g[count].Title);
                Assert.AreEqual(expected.Chapter, g[count].Chapter);
                Assert.AreEqual(expected.Link, g[count].Link);
                count++;
            }
        }

        [TestMethod()]
        public void GetLastChapterGameOfScanlationTest()
        {
            var _title = "Trinity Wonder";
            GameOfScanlation.SetRSSLink("https://gameofscanlation.moe/projects/trinity-wonder/index.rss");

            var g = GameOfScanlation.GetLastChapter("Trinity Wonder");
            var e = new MangaModel(
                Utility.Settings.GameOfScanlation,
                _title,
                "20",
                "https://gameofscanlation.moe/projects/trinity-wonder/chapter-20.2016/",
                "https://gameofscanlation.moe/projects/trinity-wonder/index.rss",
                DateTime.Now);

            Assert.AreEqual(g.Title, e.Title);
            Assert.AreEqual(g.Chapter, e.Chapter);
            Assert.AreEqual(g.Link, e.Link);
        }
    }
}