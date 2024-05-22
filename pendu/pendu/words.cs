using System;
using System.Collections.Generic;
using System.Text;

namespace pendu
{
    class words
    {
        private string Mot;
        private int longueur;
        

        public words(string mot)
        {
            Mot = mot;
            longueur = mot.Length;
        }
        public int get_longueur()
        {
            return longueur;
        }
        public string get_mot()
        { 
            return Mot;
        }
        public int place (char p_var)
        {
            return Mot.IndexOf(p_var);
            // retourne -1 si la lettre pas dans le mot 
        }
    }
}
