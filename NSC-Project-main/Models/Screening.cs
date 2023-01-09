using System.ComponentModel.DataAnnotations;

namespace NSC_project.Models
{
    public class Screening
    {
        public int Id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required]
        public int TheaterId { get; set; }
        public Theater? Theater { get; set; }

        [Required]
        public int AuditoriumId { get; set; }
        public Auditorium? Auditorium { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public ICollection<ReservedSeat>? ReservedSeats { get; set; }
        public ICollection<Reservetion>? Reservetions { get; set; }


    }
}
