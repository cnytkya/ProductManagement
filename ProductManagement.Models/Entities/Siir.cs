using ProductManagement.Models.Abstract;

namespace ProductManagement.Models.Entities
{
    public class Siir : BaseEntity
    {
        //public int Id { get; set; }
        //public string Yazar { get; set; }
        //public string Baslik { get; set; }
        //public int SayfaSayisi { get; set; }
        public string Tur { get; set; } // Lirik, Epik, Pastoral vs.
    }
}
