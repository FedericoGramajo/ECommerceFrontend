﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Models.Cart
{
    public class ProcessCart
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
