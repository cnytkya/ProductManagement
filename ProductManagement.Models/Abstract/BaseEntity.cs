using ProductManagement.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models.Abstract
{
    class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public string Yazar { get; set; }
        public string Baslik { get; set; }
        public int SayfaSayisi { get; set; }
    }
}
