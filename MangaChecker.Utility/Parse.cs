using System.Linq;

namespace MangaChecker.Utility
{
    public static class Parse
    {
        public static MangaModel.MangaModel Chapter(string provider, MangaModel.MangaModel manga)
        {

            switch (provider)
            {
                case Settings.Mangastream:
                    return mangastream(manga);
                case Settings.Webtoons:
                    return webtoons(manga);
                case Settings.Batoto:
                    return batoto(manga);
                case Settings.YoManga:
                    return yoManga(manga);
                case Settings.GameOfScanlation:
                    return gameOfScanlation(manga);
                default:
                    break;
            }
            return manga;
        }

        private static MangaModel.MangaModel mangastream(MangaModel.MangaModel manga)
        {
            var _splitTitle = manga.Name.Split(' ').ToList();
            manga.Chapter = _splitTitle.Last().ToString();
            _splitTitle.RemoveAt(_splitTitle.Count - 1);
            manga.Name = string.Join(" ", _splitTitle);
            return manga;
        }

        private static MangaModel.MangaModel webtoons(MangaModel.MangaModel manga)
        {
            if (manga.Chapter.IndexOf("Ep.") > 0)
            {
                var _splitChapter = manga.Chapter.Split('.');
                manga.Chapter = _splitChapter.Last().Trim(' ');
            }
            else
            {
                var _splitChapter = manga.Chapter.Split('.');
                manga.Chapter = _splitChapter[1].Split('-')[0].Trim(' ');
            }

            return manga;
        }

        private static MangaModel.MangaModel batoto(MangaModel.MangaModel manga)
        {
            // Boku no Hero Academia - English - Ch.100: Whip Up Some Super Moves
            // Fire Punch - English - Ch.13 Read Online
            // Dead Dead Demon's Dededededestruction - English - Vol.5 Ch.39 Read Online
            // Love is Hard for Otaku - English - Vol.2 Ch.7.2 Read Online
            var _titleToParse = manga.Name;
            int _titleEnd;

            _titleEnd = _titleToParse.IndexOf(" - English - ");
            manga.Name = _titleToParse.Substring(0, _titleEnd);

            int _chapterStart;
            int _chapterEnd;

            var _titleToParsev1 = _titleToParse.Replace(":", "");
            _chapterStart = _titleToParsev1.IndexOf("Ch.") + 3;
            _chapterEnd = _titleToParsev1.IndexOf(" ", _chapterStart);
            manga.Chapter = _titleToParsev1.Substring(_chapterStart, _chapterEnd - _chapterStart);

            return manga;
        }

        private static MangaModel.MangaModel yoManga(MangaModel.MangaModel manga)
        {
            // Lady Garden Chapter 10
            var _splitTitle = manga.Name.Split(' ').ToList();
            manga.Chapter = _splitTitle.Last().ToString();
            _splitTitle.RemoveAt(_splitTitle.Count - 1);
            _splitTitle.RemoveAt(_splitTitle.Count - 1);
            manga.Name = string.Join(" ", _splitTitle);
            return manga;
        }

         private static MangaModel.MangaModel gameOfScanlation(MangaModel.MangaModel manga)
        {
            // Lady Garden Chapter 10
            var _splitTitle = manga.Chapter.Split(' ').ToList();
            manga.Chapter = _splitTitle.Last().ToString();
            return manga;
        }
    }
}
