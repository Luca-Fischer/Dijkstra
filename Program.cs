using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LaborDijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFile textFile = new TextFile("graphBeispiel.txt");
            List<Knoten> knoten = textFile.Fill_Knoten_Liste(); 
            List<Kosten> kosten = textFile.Fill_Kosten_Liste();
            int[,] map = Map.Fill_Array(knoten, kosten);
            int[] vorganger = Logic.dijkstraAlg(knoten, kosten, map);

            string Root = Logic.getRoot(knoten);
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int t = alphabet.IndexOf(Root);
            int counter = 0;
            Console.WriteLine("Root: " + Root);
            foreach (var item in vorganger)
            {
                if (counter != t) {
                    Console.WriteLine(alphabet[counter] + " -> " + alphabet[item]);
                }
                counter++;
            }
        }
    }
}
