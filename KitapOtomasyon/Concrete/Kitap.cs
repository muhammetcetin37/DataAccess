using KitapOtomasyon.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapOtomasyon.Concrete
{
    public enum Tur
    {
        Roman,
        Siir,
        Ani,
        Deneme,
        Hikaye,
        Tarih
    }

    public class Kitap:BaseEntity
    {
        [MaxLength(50)]
        public  string KitapAdi { get; set; }
        [MaxLength(50)]
        public string Aciklama { get; set; }
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        public Tur Tur { get; set; }
    }
}
