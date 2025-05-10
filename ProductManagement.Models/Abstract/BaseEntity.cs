using ProductManagement.Models.Interface;

namespace ProductManagement.Models.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public string Yazar { get; set; }
        public string Baslik { get; set; }
        public int SayfaSayisi { get; set; }
    }
}
