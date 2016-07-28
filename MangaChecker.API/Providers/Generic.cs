using MangaChecker.Models;
using System.Collections.Generic;

namespace MangaChecker.Providers
{
    class Generic
    {
        private IList<MangaModel> _allMangas;
        private IList<MangaModel> _getAllMangas()
        {
            // implement
            return _allMangas;
        }

        public IList<MangaModel> GetChapters(string title)
        {
            var _mangas = new List<MangaModel>();
            // implement
            return _mangas;
        }

        public MangaModel GetLastChapter(string title)
        {
            var _chapter = new MangaModel();
            // implement
            return _chapter;
        }
    }
}
