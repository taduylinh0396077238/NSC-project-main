using System.ComponentModel.DataAnnotations;

namespace NSC_project.Models
{
    public class Theater
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Location { get; set; }

        public int TheaterAddressId { get; set; }
        public TheaterAddress TheaterAddress { get; set; }

        public ICollection<Auditorium>? Auditoriums
        { get; set; }
        public ICollection<Screening>? Screenings { get; set; }

    }
}
