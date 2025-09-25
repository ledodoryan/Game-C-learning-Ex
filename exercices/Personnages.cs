using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercices
{

        public class Personnage
        {
            private string nom;
            private int vie;
            public Arme Arme { get; set; }// arme du personnage

            public Personnage(string nom, int vie, Arme arme)
            {
                this.nom = nom;
                this.vie = vie;
                this.Arme = arme;
            }

            public void DiminuerVie(int valeur)
            {
                vie -= valeur;
                if (vie < 0) vie = 0;// vie min 0
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(nom + " perd " + valeur + " PVs. (vie restante : " + vie + ")");
                Console.ResetColor();
            }

            public void AugmenterVie(int valeur)
            {
                vie += valeur;
                if (vie > 100) vie = 100;// vie max 100
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(nom + " gagne " + valeur + " PVs. (vie : " + vie + ")");
                Console.ResetColor();
            }

            public void AfficherInfos()
            {
                Console.WriteLine("nom : " + nom + " / vie : " + vie + " / arme : " + Arme.Nom + " (dégâts : " + Arme.Degats + ")");
            }
        }
    }

