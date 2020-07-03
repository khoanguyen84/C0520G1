using System;
namespace Bai1
{
    class MatrixDemo
    {
        public static void Main()
        {
            Hello.Main();
            int col = 5, row = 6;
            // int[,] matrix = GenerateMatrix(col, row);
            // PrintMatrix(matrix);

            int[][] matrix = GenerateMatrix2(col, row);
            PrintMatrix(matrix);
        }

        public static int[,] GenerateMatrix(int col, int row){
            int[,] matrix  = new int[row,col];
            Random rnd = new Random();
            for(int i=0; i< row; i++){
                for(int j=0; j< col; j++){
                    matrix[i,j] = rnd.Next(10,90);
                }
            }
            return matrix;
        }

        public static void PrintMatrix(int[,] m)
        {
            for(int i=0; i< m.GetLength(0); i++){
                for(int j=0; j< m.GetLength(1); j++){
                    Console.Write($"{m[i,j]} ");
                }        
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(int[][] m)
        {
            for(int i=0; i< m.Length; i++){
                for(int j=0; j< m[i].Length; j++){
                    Console.Write($"{m[i][j]} ");
                }        
                Console.WriteLine();
            }
        }

        public static int[][] GenerateMatrix2(int col, int row){
            int[][] matrix  = new int[row][];
            Random rnd = new Random();
            for(int i=0; i< row; i++){
                int[] arr = new int[col];
                for(int j=0; j< col; j++){
                    arr[j] = rnd.Next(10,90);
                }
                matrix[i]=arr;
            }
            return matrix;
        }
    }
}