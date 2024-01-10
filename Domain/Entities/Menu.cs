﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Menu : Product_BaseEntity
    {
        public Menu()
        {
            Condiments= new List<Condiment>();
            Burgers= new List<Burger>();
            Beverages= new List<Beverage>();
        }
        public Size Size { get; set; }
        public ICollection<Condiment> Condiments { get; set; }
        public ICollection<Burger> Burgers { get; set;}
        public ICollection<Beverage> Beverages { get; set; }


    }
}
