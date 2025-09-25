using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercices
{
    public class Arme
    {
        public string Nom { get; }// nom de l'arme
        public int Degats { get; }// degats de l'arme

        public Arme(string nom, int degats)// constructeur
        {
            Nom = nom;
            Degats = degats;
        }
    }
}
