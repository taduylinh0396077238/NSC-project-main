namespace NSC_project.Models.NSCViewModels
{
    public class TicketData
    {
        public IEnumerable<Movie>? Movies { get; set; }
        public IEnumerable<Theater>? Theaters { get; set; }
        public IEnumerable<TheaterAddress>? TheaterAddresses { get; set; }
        public IEnumerable<Auditorium>? Auditoriums { get; set; }
        public IEnumerable<Screening>? Screenings { get; set; }
        public IEnumerable<Seat>? Seats { get; set; }
    }
}
