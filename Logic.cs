using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LaborDijkstra
{
    public class Logic
    {
        public static int[] dijkstraAlg(List<Knoten> knoten, List<Kosten> kosten, int[,] map)
        {
            bool[] knotenChecker = new bool[knoten.Count];
            int[] knotenKosten = new int[knoten.Count];
            int[] knotenKostenDouble = new int[knoten.Count];
            int[] vorganger = new int[knoten.Count];

          
           string s = getRoot(knoten);
           
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int row = alphabet.IndexOf(s);
            int start = row;
            
            bool done = false;

            while (done == false) {
                if (Array.Exists(knotenChecker, element => element == false)) {
                    knotenChecker[row] = true;
                    for (int column = 0; column < knoten.Count; column++) {
                        if (map[row, column] > 0) {
                            if (knotenKosten[column] > knotenKosten[row] + map[row, column] || knotenKosten[column] == 0) {
                                knotenKosten[column] = knotenKosten[row] + map[row, column];
                                knotenKostenDouble[column] = knotenKosten[row] + map[row, column];
                                vorganger[column] = row;
                            }
                        }
                    }
                    //Suche den kleinsten Wert von knotenKosten
                    int minValue;
                    int indexKK;
                    bool check = true;
                               
                    while (check) {
                        minValue = 11100;
                        indexKK = 0;
                        foreach (var item in knotenKostenDouble)
                        {
                            if (item < minValue && item > 0) {
                                minValue = item;
                                row = indexKK;
                            }
                            indexKK++;
                        }
                        bool check1 = true;
                        if (knotenChecker[row] == true) {
                            foreach (var item in knotenKostenDouble)
                            {
                                if (item != 11100) {
                                    check1 = false;
                                }
                            }
                            if (check1) {         //wenn jedes element in knotenkostendouble == 11100
                                check = false;
                            }                            
                            knotenKostenDouble[row] = 11100;
                        }
                        else {
                            check = false;
                        }
                    }
                }
                else {
                    done = true;
                }
            }
            knotenKosten[start] = 0;
            vorganger[start] = 0;

            return vorganger;
        }
        
        public static string getRoot(List<Knoten> knoten) 
        {
            string s = "";
            foreach (var k in knoten)
            {
                if (k.id == knoten.Min(num => num.id))
                {
                    s = k.name;
                }
            }
            
            return s;
        }
    }
    
    
}