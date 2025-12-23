using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi3.Sprint5.Task2.V19
{
    public class DataService :ISprint5Task2V19
    {
        public int[,] LoadFromDataFile(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] resultMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] % 2 != 0)
                    {
                        resultMatrix[i, j] = 0;
                    }
                    else
                    {
                        resultMatrix[i, j] = matrix[i, j];
                    }
                }
            }

            return resultMatrix;
        }

        public string SaveToFileTextData(int[,] matrix)
        {
            string path = $"{Directory.GetCurrentDirectory()}\\OutPutFileTask2.csv";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    string line = "";
                    for (int j = 0; j < cols; j++)
                    {
                        line += matrix[i, j].ToString();
                        if (j < cols - 1)
                        {
                            line += ";";
                        }
                    }
                    writer.Write(line); // Только Write, без WriteLine

                    if (i < rows - 1)
                    {
                        writer.WriteLine(); // Перенос строки только между строками массива
                    }
                }
            }

            return path;
        }
    }
}