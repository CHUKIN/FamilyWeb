﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWeb.Models
{
    public class Cash
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
