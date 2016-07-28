using MangaChecker.Models;
using MangaChecker.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MangaChecker.API.Providers.Tests
{
    [TestClass]
    public class WebtoonsTests
    {
        [TestMethod]
        public void GetChaptersWebtoonsTest()
        {
            var _title = "Tower of God";
            Webtoons.SetRSSLink("http://www.webtoons.com/en/fantasy/tower-of-god/rss?title_no=95");

            var g = Webtoons.GetChapters("Tower of God");

            var e = new List<MangaModel> {
                new MangaModel(Settings.Webtoons,
                    _title,
                    "208",
                    "http://www.webtoons.com/en/fantasy/tower-of-god/season-2-ep-208/viewer?title_no=95&episode_no=289",
                    "http://www.webtoons.com/en/fantasy/tower-of-god/rss?title_no=95",
                    DateTime.Now),
                new MangaModel(Settings.Webtoons,
                    _title,
                    "207",
                    "http://www.webtoons.com/en/fantasy/tower-of-god/season-2-ep-207/viewer?title_no=95&episode_no=288",
                    "http://www.webtoons.com/en/fantasy/tower-of-god/rss?title_no=95",
                    DateTime.Now),
                new MangaModel(Settings.Webtoons,
                    _title,
                    "206",
                    "http://www.webtoons.com/en/fantasy/tower-of-god/season-2-ep-206/viewer?title_no=95&episode_no=287",
                    "http://www.webtoons.com/en/fantasy/tower-of-god/rss?title_no=95",
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

        [TestMethod]
        public void GetChaptersWebtoonsTestTwo()
        {
            var _title = "Tales of the Unusual";
            Webtoons.SetRSSLink("http://www.webtoons.com/en/thriller/tales-of-the-unusual/rss?title_no=68");

            var g = Webtoons.GetChapters("Tales of the Unusual");

            var e = new List<MangaModel> {
                new MangaModel(Settings.Webtoons,
                    _title,
                    "127",
                    "http://www.webtoons.com/en/thriller/tales-of-the-unusual/ep-127-real-implant/viewer?title_no=68&episode_no=128",
                    "http://www.webtoons.com/en/thriller/tales-of-the-unusual/rss?title_no=68",
                    DateTime.Now),
                new MangaModel(Settings.Webtoons,
                    _title,
                    "126",
                    "http://www.webtoons.com/en/thriller/tales-of-the-unusual/ep-126-kiveirus-library-part8/viewer?title_no=68&episode_no=127",
                    "http://www.webtoons.com/en/thriller/tales-of-the-unusual/rss?title_no=68",
                    DateTime.Now),
                new MangaModel(Settings.Webtoons,
                    _title,
                    "125",
                    "http://www.webtoons.com/en/thriller/tales-of-the-unusual/ep-125-kiveirus-library-part7/viewer?title_no=68&episode_no=126",
                    "http://www.webtoons.com/en/thriller/tales-of-the-unusual/rss?title_no=68",
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

        [TestMethod]
        public void GetLastChapterWebtoonsTest()
        {
            var _title = "Tower of God";
            Webtoons.SetRSSLink("http://www.webtoons.com/en/fantasy/tower-of-god/rss?title_no=95");

            var g = Webtoons.GetLastChapter("Tower of God");
            var e = new MangaModel(
                Settings.Webtoons,
                _title,
                "208",
                "http://www.webtoons.com/en/fantasy/tower-of-god/season-2-ep-208/viewer?title_no=95&episode_no=289",
                "http://www.webtoons.com/en/fantasy/tower-of-god/rss?title_no=95",
                DateTime.Now);

            Assert.AreEqual(g.Title, e.Title);
            Assert.AreEqual(g.Chapter, e.Chapter);
            Assert.AreEqual(g.Link, e.Link);
        }
    }
}