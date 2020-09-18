using System;
using System.IO;

class Coronatest
{
    PriorityQueue<Aanvraag> testaanvragen = new PriorityQueue<Aanvraag>();
    Random random = new Random();

    public void Add(Aanvraag A) {
        testaanvragen.Enqueue(BepaalPrioriteit(A), A);
    }

    public bool Empty() {
        if (testaanvragen.Count == 0 ) return true;
        return false;
    }

    public void UpdatePrioriteit (Aanvraag A, int nieuwePrioriteit) {
        testaanvragen.UpdatePriority(A, nieuwePrioriteit);
    }

    public Uitslag Test() {
        Aanvraag aanvraag = testaanvragen.Dequeue();
        Uitslag uitslag = new Uitslag(aanvraag);

        if (random.Next(0, 30) % 2 == 0) {
            uitslag.Positief = true;
        }

        return uitslag;
    }

    private int BepaalPrioriteit(Aanvraag aanvraag) {
        string[] hogePrioriteitBeroepen = File.ReadAllLines("priolijst_beroepen.txt");

        foreach (string beroep in hogePrioriteitBeroepen) {
            if (beroep.ToLower() == aanvraag.Beroep.ToLower()) return 2;
        }

        return 1;
    }
}


class Aanvraag
{
    public string Naam { get; set; }
    public string Beroep { get; set; }
    public DateTime AanvraagDatum { get; set; }

    public Aanvraag(String naam, String beroep)
    {
        Naam = naam;
        Beroep = beroep;
        AanvraagDatum = DateTime.Now;
    }
}

class Uitslag 
{
    public bool Positief { get; set; }
    public Aanvraag Aanvraag { get; set; }

    public Uitslag(Aanvraag aanvraag)
    {
        Aanvraag = aanvraag;
        Positief = false;
    }

    public override string ToString()
    {
        return String.Format("Is {0} ({1}) positief? {2}", Aanvraag.Naam, Aanvraag.Beroep, Positief.ToString());
    }
}