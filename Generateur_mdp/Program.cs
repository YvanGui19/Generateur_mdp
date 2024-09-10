using FormationCS;
using System;
using System.Linq;

namespace Generateur_mdp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;

            while (continuer)
            {
                int combienMotDePasse;
                do
                {
                    combienMotDePasse = Outils.DemanderNombre(" Vous souhaitez générer combien de mot de passe (entre 1 et 100) ? ");
                    if (combienMotDePasse < 1 || combienMotDePasse > 100)
                    {
                        Console.WriteLine("Le nombre de mots de passe doit être compris entre 1 et 100. Veuillez réessayer.");
                    }
                } while (combienMotDePasse < 1 || combienMotDePasse > 100);

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

                    bool motDePasseValide;
                    do
                    {
                        motDePasse = "";
                        for (int i = 0; i < longueurMotDePasse; i++)
                        {
                            int index = rand.Next(0, longueurAlphabet);
                            motDePasse += alphabet[index]; //Génére le mot de passe
                        }

                        motDePasseValide = VerifierMotDePasse(motDePasse, choixAlphabet);
                    } while (!motDePasseValide);

                    Console.WriteLine();
                    Console.WriteLine(" Mot de passe : " + motDePasse);
                }

                Console.WriteLine("\nAppuyez sur ÉCHAP pour fermer ou ENTRÉE pour générer d'autres mots de passe.");
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
            }
        }
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
    }
}
