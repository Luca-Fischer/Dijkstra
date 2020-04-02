using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LaborDijkstra
{
    public class TextFile
    {
        public string file_name { get; set; }
        public string[] file_content { get; set; }
        public List<Knoten> knoten_liste { get; set; }
        public List<Kosten> kosten_liste { get; set; }
        
        public TextFile(string _file_name)
        {
            this.file_name = _file_name;
            ReadFile();
        }

        public string[] ReadFile()
        {
            this.file_content = File.ReadAllLines(file_name);
            return file_content;
        }

        public List<Knoten> Fill_Knoten_Liste()
        {
            this.knoten_liste = new List<Knoten>();
            foreach (var line in file_content)
            {
                if (line.Contains("="))
                {
                    string[] parts = line.Split("=");
                    parts[0] = parts[0].Trim();
                    parts[1] = parts[1].Replace(";", "").Trim();
                    Knoten tmp_knoten = new Knoten(Convert.ToInt16(parts[1]), Convert.ToString(parts[0]));
                    this.knoten_liste.Add(tmp_knoten);
                }
            }
            
            return this.knoten_liste;
        }

        public List<Kosten> Fill_Kosten_Liste()
        {
            this.kosten_liste = new List<Kosten>();

            foreach (var line in file_content)
            {
                if (line.Contains(":"))
                {
                    string[] parts = line.Split(":");
                    string[] parts_split = parts[0].Split("-");
                    parts_split[0] = parts_split[0].Trim();
                    parts_split[1] = parts_split[1].Trim();
                    parts[1] = parts[1].Replace(";", "").Trim();

                    Knoten tmp_knoten1 = new Knoten();
                    Knoten tmp_knoten2 = new Knoten();
                    
                    foreach (Knoten k in knoten_liste)
                    {
                        if (k.name.Equals(parts_split[0]))
                        {
                            tmp_knoten1 = k;
                        }

                        if (k.name.Equals(parts_split[1]))
                        {
                            tmp_knoten2 = k;
                        }
                    }

                    Kosten tmp_kosten = new Kosten(tmp_knoten1, tmp_knoten2,Convert.ToInt16(parts[1]));
                    kosten_liste.Add(tmp_kosten);
                }
            }
            return this.kosten_liste;
        }
    }
}