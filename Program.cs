using System;

namespace Queuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Coronatest testlocatie = new Coronatest();

            Aanvraag aanvraag1 = new Aanvraag("Persoon1", "Zorg");
            Aanvraag aanvraag2 = new Aanvraag("Persoon2", "Militair");
            Aanvraag aanvraag3 = new Aanvraag("Persoon3", "Docent");
            Aanvraag aanvraag4 = new Aanvraag("Persoon4", "Docent");
            Aanvraag aanvraag5 = new Aanvraag("Persoon5", "iets");
            Aanvraag aanvraag6 = new Aanvraag("Persoon6", "geen");
            Aanvraag aanvraag7 = new Aanvraag("Persoon7", "Straatventer");
            Aanvraag aanvraag8 = new Aanvraag("Persoon8", "Zorg");

            testlocatie.Add(aanvraag1);
            testlocatie.Add(aanvraag2);
            testlocatie.Add(aanvraag3);
            testlocatie.Add(aanvraag4);
            testlocatie.Add(aanvraag5);
            testlocatie.Add(aanvraag6);
            testlocatie.Add(aanvraag7);
            testlocatie.Add(aanvraag8);

            testlocatie.UpdatePrioriteit(aanvraag7, 4);

            do {
                Uitslag uitslag = testlocatie.Test();

                Console.WriteLine(uitslag.ToString());
            } while (testlocatie.Empty() == false);
                
        }
    }
}
