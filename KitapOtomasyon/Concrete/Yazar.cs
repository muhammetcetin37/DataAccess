using KitapOtomasyon.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapOtomasyon.Concrete
{
    public class Yazar:BaseEntity
    {
        [MaxLength(50)]
        public string Adi { get; set; }
        public string Soyad { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
