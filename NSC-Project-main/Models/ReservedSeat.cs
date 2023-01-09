using System.ComponentModel.DataAnnotations;

namespace NSC_project.Models
{
    public class ReservedSeat
    {
        public int Id { get; set; }

        [Required]
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }

        [Required]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        [Required]
        public int ReservetionId { get; set; }
        public Reservetion Reservetion { get; set; }
    }
}
