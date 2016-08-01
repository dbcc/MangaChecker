using System.Collections.Generic;

namespace MangaChecker.API.Providers
{
    class FoolSlide
    {
        private List<MangaModel.MangaModel> _allMangas;
        private List<MangaModel.MangaModel> _getAllMangas()
        {
            // implement
            return _allMangas;
        }

        public List<MangaModel.MangaModel> GetChapters(string title)
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
