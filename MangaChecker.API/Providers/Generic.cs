using System.Collections.Generic;

namespace MangaChecker.API.Providers
{
    class Generic
    {
        private IList<MangaModel.MangaModel> _allMangas;
        private IList<MangaModel.MangaModel> _getAllMangas()
        {
            // implement
            return _allMangas;
        }

        public IList<MangaModel.MangaModel> GetChapters(string title)
        {
            var _mangas = new List<MangaModel.MangaModel>();
            // implement
            return _mangas;
        }

        public MangaModel.MangaModel GetLastChapter(string title)
        {
            var _chapter = new MangaModel.MangaModel();
            // implement
            return _chapter;
        }
    }
}
