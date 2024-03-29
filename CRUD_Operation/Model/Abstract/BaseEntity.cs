﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operation.Abstract
{
    
        public enum Status
        {
            Active=1,
            Modify=2,
            Passive=3

        }
    public abstract class BaseEntity
    {
        

        public int Id { get; set; }

        private DateTime _createData = DateTime.Now;

        public DateTime CreteaData
        {
            get { return _createData; }
            set { _createData = value; }
        }
        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        private Status _status=Status.Active;

        public Status Status
        {
            get { return _status; }
            set { _status=value; }
        }


    }
}
