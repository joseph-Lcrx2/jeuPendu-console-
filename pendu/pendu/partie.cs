using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pendu
{
    class partie
    {
        int a;
        int win = 0;
        bool b;
        bool c = false;
        char lettre;
        int erreurs=0;
        List<char> Ltrouvée = new List<char> { };
        List<char> Lratée = new List<char> { };
        List<words> mots = new List<words> { };
        words mot;
        Random aleat = new Random();
        Random A = new Random();

        public partie()
        {

            StreamReader sr = new StreamReader("liste.txt");
            string mot_fichier = sr.ReadLine();
            while(mot_fichier!=null)
            {
                words w1 = new words(mot_fichier);
                mots.Add(w1);
                mot_fichier = sr.ReadLine();
            }
        }
        public void play()
        {
            mot = mots[aleat.Next(mots.Count)];  //random pour avoir un mot au hasard dans la liste.
            Console.WriteLine("======== JEU DU PENDU ========");
            Console.WriteLine("");
            do
            {
                win = 0;
                Console.WriteLine("nombre d'erreur(s) : " + erreurs); //debut de la parie
                Console.WriteLine("");
                Console.Write("Lettres testées mais non-présentes : ");
                Console.WriteLine("");
                for (int i = 0; i < Lratée.Count; i++)
                {
                    Console.WriteLine(Lratée[i]);
                }
                for (int i = 0; i < mot.get_longueur(); i++)
                    {
                        b = false;
                        for (int j = 0; j < Ltrouvée.Count; j++)
                        {
                            
                            if (mot.get_mot()[i] == Ltrouvée[j])
                                b = true;
                        }
                        if (b == true)
                        {
                            Console.Write(mot.get_mot()[i]);
                        }
                        else if (b == false)
                            Console.Write("_ ");   
                }
                    Console.WriteLine("");
                    Console.Write("Proposer une lettre :");
                    Console.WriteLine("");
                    lettre = char.Parse(Console.ReadLine());
                    int res_lettre = mot.place(lettre);

                    if (res_lettre != -1)
                    {
                        Ltrouvée.Add(lettre);    
                    }
                    else
                    {
                        erreurs += 1;
                        Lratée.Add(lettre);
                    }
                    for (int i = 0; i < mot.get_longueur(); i++)
                    {
                        for (int j = 0; j < Ltrouvée.Count; j++)
                        {
                            if (mot.get_mot()[i] == Ltrouvée[j])
                                win += 1;
                        }
                    }
            } while (win != mot.get_longueur() && erreurs!=10);

            if (win == mot.get_longueur() && erreurs<10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bravo ! Vous avez gagné !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Le mot était " + mot.get_mot());
                
            }
            else if (erreurs==10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Perdu !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Le mot était " + mot.get_mot());
            }
        }
    }

}
