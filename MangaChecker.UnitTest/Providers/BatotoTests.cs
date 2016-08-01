using MangaChecker.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MangaChecker.API.Providers.Tests
{
    [TestClass]
    public class BatotoTests
    {
        [TestMethod]
        public void GetChaptersBatotoTest()
        {
            var _title = "Fire Punch";
            var _rss = "http://bato.to/myfollows_rss?secret=YEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE=English";
            Batoto.SetRSSLink(_rss);

            var g = Batoto.GetChapters(_title);

            var e = new List<MangaModel.MangaModel>{
                new MangaModel.MangaModel(
                    Settings.Batoto,
                    _title,
                    "14",
                    "http://bato.to/reader#03c2b117a84a707c",
                    _rss,
                    DateTime.Now
                ),
                new MangaModel.MangaModel(
                    Settings.Batoto,
                    _title,
                    "13",
                    "http://bato.to/reader#555aea8e301ece19",
                    _rss,
                    DateTime.Now
                ),
            };

            if (g.Count == 0)
            {
                Assert.Fail();
            }

            var count = 0;
            foreach (var got in g)
            {
                Assert.AreEqual(got.Name, e[count].Name);
                Assert.AreEqual(got.Chapter, e[count].Chapter);
                Assert.AreEqual(got.Link, e[count].Link);
                count++;
            }
        }

        [TestMethod]
        public void GetLastChapterBatotoTest()
        {
            var _title = "Fire Punch";
            var _rss = "http://bato.to/myfollows_rss?secret=YEEEEEEEEEEEEEEEEEEEEEEEEE=English";
            Batoto.SetRSSLink(_rss);

            var g = Batoto.GetLastChapter(_title);

            var e = new MangaModel.MangaModel(
                    Settings.Batoto,
                    _title,
                    "14",
                    "http://bato.to/reader#03c2b117a84a707c",
                    _rss,
                    DateTime.Now
                );

            if (g == null)
            {
                Assert.Fail();
            }

            Assert.AreEqual(g.Name, e.Name);
            Assert.AreEqual(g.Chapter, e.Chapter);
            Assert.AreEqual(g.Link, e.Link);
        }
    }
}