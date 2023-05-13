namespace Asgard.Models
{
    public class Comenzi
    {
        public string Agent { get; set; }
        public string Telefon { get; set; }
        public string Model { get; set; }
        public string Semnare { get; set; }

        public Comenzi(string agent, string telefon, string model, string semnare)
        {
            Agent = agent;
            Telefon = telefon;
            Model = model;
            Semnare = semnare;
        }
    }
}
