using Zadanie7.Models;

namespace Zadanie7.DTO
{
    public class Trips
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public IEnumerable<Countries> Contries { get; set; }
        public IEnumerable<Clients> Clients { get; set; }
    }
}