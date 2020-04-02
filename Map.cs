using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaborDijkstra
{
    public class Map
    {
        public static int[,] Fill_Array(List<Knoten> knoten, List<Kosten> kosten)
        {
            int[,] map = new int[knoten.Count, knoten.Count];
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            foreach (var k in kosten)
            {
                int x = alphabet.IndexOf(k.start.name[0]);
                int y = alphabet.IndexOf(k.ende.name[0]);
                map[x, y] = k.kosten;
                map[y, x] = k.kosten;
            }
            
            return map;
        }
    }
}