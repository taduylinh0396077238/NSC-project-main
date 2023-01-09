using System.Collections.ObjectModel;

namespace NSC_project.Models
{
    public class TheaterAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public ICollection<Theater>? Theaters { get; set; }
    }
}
