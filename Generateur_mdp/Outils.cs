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
        static bool VerifierMotDePasse(string motDePasse, int choixAlphabet)
        {
            bool contientMinuscule = motDePasse.Any(char.IsLower);
            bool contientMajuscule = motDePasse.Any(char.IsUpper);
            bool contientChiffre = motDePasse.Any(char.IsDigit);
            bool contientCaractereSpecial = motDePasse.Any(ch => "&~#$£*µ%§!?€|-_@.".Contains(ch));

            if (choixAlphabet == 2)
                return contientMinuscule && contientMajuscule;
            else if (choixAlphabet == 3)
                return contientMinuscule && contientMajuscule && contientChiffre;
            else if (choixAlphabet == 4)
                return contientMinuscule && contientMajuscule && contientChiffre && contientCaractereSpecial;

            return true;
        }

        public static int DemanderNombrePositifNonNul(string question)
        {
            return DemanderNombreEntre(question, 8, 50, "ERREUR : La longueur doit être comprise entre 8 et 50");
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
