using FormationCS;
using System;

namespace Generateur_mdp
{
    class Program
    {
        static void Main(string[] args)
        {

            int combienMotDePasse = Outils.DemanderNombre(" Vous souhaitez générer combien de mot de passe ? ");
            Console.WriteLine();

            int longueurMotDePasse = Outils.DemanderNombrePositifNonNul(" Longueur du mot de passe : ");
            Console.WriteLine();

            int choixAlphabet = Outils.DemanderNombreEntre(" Vous voulez un mot de passe avec : \n" +
                " 1 - Uniquement des caractères en minuscules\n" +
                " 2 - Des caractères en minuscules et majuscules\n" +
                " 3 - Des caractères minuscules, majuscules et des chiffres\n" +
                " 4 - Des caractères minuscules, majuscules, des chiffres et des caractères spéciaux \n" +
                "\n" +
                " Votre choix (mettre seulement le numéro de ligne souhaité) : ", 1, 4);

            for (int r = 0; r < combienMotDePasse; r++)
            {
                string minuscules = "abcdefghijklmnopqrstuvwxyz";
                string majuscules = minuscules.ToUpper();
                string chiffres = "0123456789";
                string caracteresSpeciaux = "&~#$£*µ%§!?€|-_@.";
                string alphabet;
                string motDePasse = "";
                Random rand = new();

                if (choixAlphabet == 1)
                    alphabet = minuscules;
                else if (choixAlphabet == 2)
                    alphabet = minuscules + majuscules;
                else if (choixAlphabet == 3)
                    alphabet = minuscules + majuscules + chiffres;
                else
                    alphabet = minuscules + majuscules + chiffres + caracteresSpeciaux;

                int longueurAlphabet = alphabet.Length;

                //boucle sur longueurMotDePasse
                for (int i = 0; i < longueurMotDePasse; i++)
                {
                    int index = rand.Next(0, longueurAlphabet);
                    motDePasse += alphabet[index]; //Génére le mot de passe
                }
                Console.WriteLine();
                Console.WriteLine(" Mot de passe : " + motDePasse);
            }
            Console.WriteLine("\nAppuyez sur une touche pour fermer.");
            Console.ReadKey();
        }
    }
}
