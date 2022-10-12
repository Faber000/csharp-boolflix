namespace csharp_boolflix.Models
{
    public class FilmSerie
    {
        public List<MediaInfo> MediaInfos { get; set; }
        public List<Film> Films { get; set; }  
        public List<TVSeries> TvSeries { get; set; }

        public FilmSerie()
        {
            MediaInfos = new List<MediaInfo>();
            Films = new List<Film>();
            TvSeries = new List<TVSeries>();    

        }
    }
    
}
