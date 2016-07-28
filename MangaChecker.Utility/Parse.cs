using MangaChecker.Models;
using System.Linq;

namespace MangaChecker.Utility
{
    public static class Parse
    {
        public static MangaModel Chapter(string provider, MangaModel manga)
        {

            switch (provider)
            {
                case Settings.Mangastream:
                    return mangastream(manga);
                case Settings.Webtoons:
                    return webtoons(manga);
                case Settings.Batoto:
                    return batoto(manga);
                default:
                    break;
            }
            return manga;
        }

        private static MangaModel mangastream(MangaModel manga)
        {
            var _splitTitle = manga.Title.Split(' ').ToList();
            manga.Chapter = _splitTitle.Last().ToString();
            _splitTitle.RemoveAt(_splitTitle.Count - 1);
            manga.Title = string.Join(" ", _splitTitle);
            return manga;
        }

        private static MangaModel webtoons(MangaModel manga)
        {
            if (manga.Title.IndexOf("Ep.") > 0)
            {
                var _splitTitle = manga.Title.Split('.');
                manga.Chapter = _splitTitle.Last().Trim(' ');
            }
            else
            {
                var _splitTitle = manga.Title.Split('.');
                manga.Chapter = _splitTitle[1].Split('-')[0].Trim(' ');
            }

            return manga;
        }

        private static MangaModel batoto(MangaModel manga)
        {
            // Boku no Hero Academia - English - Ch.100: Whip Up Some Super Moves
            // Fire Punch - English - Ch.13 Read Online
            // Dead Dead Demon's Dededededestruction - English - Vol.5 Ch.39 Read Online
            // Love is Hard for Otaku - English - Vol.2 Ch.7.2 Read Online
            var _titleToParse = manga.Title;
            int _titleEnd;

            _titleEnd = _titleToParse.IndexOf(" - English - ");
            manga.Title = _titleToParse.Substring(0, _titleEnd);

            int _chapterStart;
            int _chapterEnd;

            var _titleToParsev1 = _titleToParse.Replace(":", "");
            _chapterStart = _titleToParsev1.IndexOf("Ch.") + 3;
            _chapterEnd = _titleToParsev1.IndexOf(" ", _chapterStart);
            manga.Chapter = _titleToParsev1.Substring(_chapterStart, _chapterEnd - _chapterStart);

            return manga;
        }
    }
}
