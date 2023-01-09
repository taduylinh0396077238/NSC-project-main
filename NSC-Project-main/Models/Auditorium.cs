using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NSC_project.Models
{
    public class Auditorium
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        public int Seats_no { get; set; }

        [Required]
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

        public ICollection<Screening>? Screenings { get; set; }
        public ICollection<Seat>? Seats { get; set; }

    }
}
