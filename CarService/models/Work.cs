﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Work
    {
        public int Id { get; set; }        
        public string CarNumber { get; set; }
        public string WorkType { get; set; }
        public string Date { get; set; }
    }
}
