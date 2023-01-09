using System.ComponentModel.DataAnnotations;

namespace NSC_project.Models
{
    public class Seat
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }

        public ICollection<ReservedSeat>? ReservedSeats { get; set; }
    }
}
