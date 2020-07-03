using System;

namespace Bai2
{
    class MatrixDemo
    {
        public static void Main(){
            int[][] matrix = GenerateMatrix2(8,10);
            PrintMatrix2(matrix);
        }

        public static int[,] GenerateMatrix1(int row, int col){
            int[,] matrix = new int[row, col];
            Random rnd = new Random();
            for(int i =0; i< row; i++){
                for(int j=0; j<col; j++){
                    matrix[i,j] = rnd.Next(40, 80);
                }
            }
            return matrix;
        }

        public static void PrintMatrix1(int[,] matrix){
            for(int i =0; i< matrix.GetLength(0); i++){
                for(int j=0; j< matrix.GetLength(1); j++){
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        public static int[][] GenerateMatrix2(int row, int col){
            int[][] matrix = new int[row][];
            Random rnd = new Random();
            for(int i =0; i< row; i++){
                int[] arr = new int[col];
                for(int j=0; j<col; j++){
                    arr[j] = rnd.Next(40, 80);
                }
                matrix[i] = arr;
            }
            return matrix;
        }
        public static void PrintMatrix2(int[][] matrix){
            for(int i =0; i< matrix.Length; i++){
                for(int j=0; j< matrix[i].Length; j++){
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}