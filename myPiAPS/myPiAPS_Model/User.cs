﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPiAPS_Model
{
    public class User
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }


       // public int? StockId { get; set; }
        public int? ShopHallId { get; set; }


      //  public virtual Stock Stock { get; set; }

        public virtual ShopHall ShopHall { get; set; }
    }
}
