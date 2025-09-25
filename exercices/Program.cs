using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace exercices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // les armes dispos avec differents degats infligenants

            Arme scalpel = new Arme("Scalpel", 20);
            Arme barreau = new Arme("Barreau", 15); 
            Arme m4 = new Arme("M4", 35);
            Arme ak47 = new Arme("AK47", 40);
            Arme deagle = new Arme("Deagle", 50);
            Arme glock17 = new Arme("Glock 17", 25);
            Arme rpg7 = new Arme("RPG-7", 80);
            Arme mac10 = new Arme("MAC-10", 30);
            Arme scarh = new Arme("SCAR-H", 45);
            Arme famas = new Arme("FAMAS", 38);

            Arme[] toutesArmes = { scalpel, barreau, m4, ak47, deagle, glock17, rpg7, mac10, scarh, famas };
            // persos
            Personnage dexter = new Personnage("Dexter Morgan", 100, scalpel);
            Personnage harvey = new Personnage("Harvey Specter", 100, barreau);

            string derniereAction = "Début de la partie";

            while (true)
            {
                Console.Clear();//effacer la console

                // pvs afficher avec actio derniere
                Console.ForegroundColor = ConsoleColor.Magenta; // couleur violette
                Console.WriteLine("--- État des personnages ---");
                Console.ResetColor(); // effacer la couleur
                dexter.AfficherInfos(); // infos perso
                harvey.AfficherInfos();// infos perso

                Console.ForegroundColor = ConsoleColor.Green; // couleur verte
                Console.WriteLine($"\nDernière action : {derniereAction}"); // afficher derniere action
                Console.ResetColor(); // effacer la couleur

                Console.ForegroundColor = ConsoleColor.Cyan; // couleur cyan
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║              MENU DU JEU              ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.ResetColor(); // effacer la couleur

                Console.ForegroundColor = ConsoleColor.Yellow;// couleur jaune
                Console.WriteLine(" 1. Dexter attaque Harvey");
                Console.WriteLine(" 2. Harvey attaque Dexter");
                Console.WriteLine(" 3. Dexter se soigne");
                Console.WriteLine(" 4. Harvey se soigne");
                Console.WriteLine(" 5. Changer arme de Dexter");
                Console.WriteLine(" 6. Changer arme de Harvey");
                Console.WriteLine(" 0. Quitter");
                Console.ResetColor();// effacer la couleur

                Console.Write("\nVotre choix : ");
                string choix = Console.ReadLine();// lire le choix  

                switch (choix)//choix le choix
                {
                    case "1":
                        harvey.DiminuerVie(dexter.Arme.Degats);// infliger des degats
                        derniereAction = $"Dexter attaque Harvey avec {dexter.Arme.Nom} (-{dexter.Arme.Degats} PVs à Harvey)";
                        break;
                    case "2":
                        dexter.DiminuerVie(harvey.Arme.Degats);// infliger des degats
                        derniereAction = $"Harvey attaque Dexter avec {harvey.Arme.Nom} (-{harvey.Arme.Degats} PVs à Dexter)";
                        break;
                    case "3":
                        dexter.AugmenterVie(10);// soin de 10 pvs
                        derniereAction = "Dexter se soigne (+10 PVs)";
                        break;
                    case "4":
                        harvey.AugmenterVie(10);// soin de 10 pvs
                        derniereAction = "Harvey se soigne (+10 PVs)";
                        break;
                    case "5":
                        dexter.Arme = ChoisirArme(toutesArmes); // changer arme
                        derniereAction = $"Dexter a changé d'arme pour {dexter.Arme.Nom}";
                        break;
                    case "6":
                        harvey.Arme = ChoisirArme(toutesArmes);// changer arme
                        derniereAction = $"Harvey a changé d'arme pour {harvey.Arme.Nom}";
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;// couleur rouge
                        Console.WriteLine("Choix invalide.");// message erreur
                        Console.ResetColor();// effacer la couleur
                        derniereAction = "Choix invalide";// message erreur
                        break;
                }
            }
        }

        static Arme ChoisirArme(Arme[] armes)// methode pour choisir l'arme
        {
            Console.ForegroundColor = ConsoleColor.Green;// couleur verte
            Console.WriteLine("\n╔════════════════════════════╗");
            Console.WriteLine("║      Sélection d'arme     ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.ResetColor();// effacer la couleur

            for (int i = 0; i < armes.Length; i++)// afficher les armes
            {
                Console.WriteLine($"{i + 1}. {armes[i].Nom} (dégâts : {armes[i].Degats})");// afficher les armes avec les degats que elles infligent
            }
            int choix;// variable choix
            while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > armes.Length)// verifier le choix
            {
                Console.ForegroundColor = ConsoleColor.Red;// couleur rouge
                Console.WriteLine("Choix invalide, recommencez.");
                Console.ResetColor();// effacer la couleur
            }
            return armes[choix - 1];// retourner l'arme choisie
        }
    }

   
}
