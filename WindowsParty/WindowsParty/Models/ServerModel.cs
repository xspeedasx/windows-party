﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsParty.Models
{
    public class ServerModel
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public string DistanceKm => Distance + " km";
    }
}
