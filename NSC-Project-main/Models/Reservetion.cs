using System.ComponentModel.DataAnnotations;

namespace NSC_project.Models
{
    public class Reservetion
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Status { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }

        public ICollection<ReservedSeat>? ReservedSeats { get; set; }
    }
}
