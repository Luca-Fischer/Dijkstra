using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LaborDijkstra
{
    public class Kosten
    {
        public Knoten start { get; set; }
        public Knoten ende { get; set; }
        public int kosten { get; set; }

        public Kosten(Knoten _start, Knoten _ende, int _kosten)
        {
            this.start = _start;
            this.ende = _ende;
            this.kosten = _kosten;
        }
    }
}