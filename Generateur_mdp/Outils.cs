using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//FormationCS.outils.DemanderNombrePositifNonNul

namespace FormationCS
{
  static class Outils
    {
        public static int DemanderNombrePositifNonNul(string question)
        {
            return DemanderNombreEntre(question, 6, 23, "ERREUR : La longueur doit être comprise entre 6 et 23");
        }

        public static int DemanderNombreEntre(string question, int min, int max, string messageErreurPerso = null)
        {
            int nombre = DemanderNombre(question);
            if ((nombre >= min) && (nombre <= max))
            {
                //valide
                return nombre;
            }
            if (messageErreurPerso == null)
            {
                Console.WriteLine("ERREUR : Le nombre doit être compris entre " + min + " et " + max);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(messageErreurPerso);
            }

            return DemanderNombreEntre(question, min, max);
        }

        public static int DemanderNombre(string question)
        {

            while (true) //boucler tant qu'on a pas reçu une réponse valide (qui contient seulement des chiffres)
            {
                //poser la question
                Console.Write(question);

                //récupérer la réponse
                string reponseLongueur = Console.ReadLine();

                try
                {
                    //convertir
                    int reponseInt = int.Parse(reponseLongueur);
                    return reponseInt;
                }
                catch //gérer l'erreur de conversion
                {
                    Console.WriteLine("ERREUR : Renseigner un ou deux caractères numériques");
                    Console.WriteLine();
                }
            }

        }
    }
}
