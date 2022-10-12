namespace csharp_boolflix.Models
{
    public class FilmSerieToInsert
    {
        public Film Film { get; set; }
        public TVSeries TvSerie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<int> SelectedGenres { get; set; }

    }
}
