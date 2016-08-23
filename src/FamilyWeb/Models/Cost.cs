﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWeb.Models
{
    public class Cost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Money { get; set; }
        

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
