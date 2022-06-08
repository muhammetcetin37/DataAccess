using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapOtomasyon.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        private DateTime _CreteDate=DateTime.Now;

        public  DateTime CreteDate
        {
            get { return CreteDate; }
            set { CreteDate = value; }
        }

    }
}
