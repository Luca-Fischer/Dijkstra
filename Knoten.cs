namespace LaborDijkstra
{
    public class Knoten
    {
        public int id { get; set; }
        public string name { get; set; }


        public Knoten() { }
        
        public Knoten(int _id, string _name)
        {
            this.id = _id;
            this.name = _name;
        }
    }
}