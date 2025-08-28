using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransposerDeMatrice
{
    internal class Program
    {
        static double Determinant(double[,] m)
        {
            return m[0,0] * (m[1, 1]*m[2,2] - m[1,2]*m[2,1]) + m[0,1] * (m[1, 0]*m[2,2] - m[1, 2]*m[2,0]) + m[2,0] * (m[1, 0]*m[2,1] - m[1, 1]*m[2,0]);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Nombre de lignes: ");
            int lignes = int.Parse(Console.ReadLine());

            Console.WriteLine("Nombre de colonnes: ");
            int colonnes = int.Parse(Console.ReadLine());

            int[ , ] matrice = new int[lignes, colonnes];

            int[,] matriceT = new int[colonnes, lignes];

            int[,] A = new int[colonnes, colonnes];


            int[,] B = new int[lignes, lignes];



            Console.WriteLine("Entrez les éléments ligne par ligne: ");

            for (int i = 0; i < lignes; i++) {
                Console.WriteLine($"Ligne{i + 1} : ");

                for(int j = 0; j < colonnes; j++)
                {
                    Console.Write($"A[{i}][{j}]");
                    matrice[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nMatrice A :");
            for (int i = 0; i < lignes; i++) {
                for(int j =0; j < colonnes; j++)
                {
                    Console.Write(matrice[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nMatrice transposé de A:");
            for(int j = 0; j < colonnes; j++)
            {
                for(int i = 0; i < lignes; i++)
                {
                    matriceT[j,i] = matrice[i, j];
                    Console.Write(matriceT[j, i] + "\t");
                }
                Console.WriteLine();
            }

            //Console.WriteLine("\nLe produit scalaire");
            //for (int i = 0; i < lignes; i++) { 
            //    for (int j = 0;j < colonnes; j++)
            //    {
            //        som = som + (matrice[i, j] * matriceT[j, i]);
            //    }
            //}

            //Console.WriteLine(som);

            Console.WriteLine("Matrices symétriques ou non");
            for (int i = 0; i < lignes; i++) { 
                for( int j = 0; j < colonnes; j++)
                {
                    if (matrice[i, j] == matriceT[j, i])
                    {
                        Console.WriteLine("A est symétrie");
                    }
                    else
                    {
                        Console.WriteLine("A n'est pas symétrie");
                    }
                }
            }

            Console.WriteLine("Calculons X transposé fois X");


            for (int i = 0; i < colonnes; i++) { 
                for(int j = 0; j < colonnes; j++)
                {
                    int som = 0;
                    for(int k = 0; k < lignes; k++)
                    {
                        som = som + matriceT[i, k] * matrice[k, j];
                    }
                    A[i, j] = som;
                }
            }

            for (int i = 0; i < colonnes; i++)
            {
                for (int j = 0; j < colonnes; j++)
                {
                    Console.Write(A[i,j] + "\t");
                }
                Console.WriteLine();
            }



            Console.WriteLine("Calculons X fois X transposé");


            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < lignes; j++)
                {
                    int somme = 0;
                    for (int k = 0; k < colonnes; k++)
                    {
                        somme = somme + matrice[i, k] * matriceT[k, j];
                    }
                    B[i, j] = somme;
                }
            }

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < lignes; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Calculons les valeurs propres");

            for(double lambda = -20;  lambda <= 20; lambda += 0.01)
            {
                double[,] lamb = new double[3, 3];
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        lamb[i,j] = A[i,j] - (i == j ? lambda : 0);
                    }
                }

                double det = Determinant(lamb);
                if (Math.Abs(det) < 1e-5)
                    Console.WriteLine($"Valeurs propres approx : {lambda:F4}");
            }

        }
    }
}
