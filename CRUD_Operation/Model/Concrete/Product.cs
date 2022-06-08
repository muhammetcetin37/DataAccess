using CRUD_Operation.Abstract;
using CRUD_Operation.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operation.Model.Concrete
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        //Navigation Property olarak kullanılacak
        //burasi database de her hangi bir field alanı olarak tutulmaz
        public Category Category { get; set; }
    }
}
