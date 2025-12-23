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
                    // Если элемент нечетный - заменяем на 0, иначе оставляем как есть
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
            string path = Path.GetTempFileName();
            string newPath = path.Replace(".tmp", ".csv");
            File.Move(path, newPath);

            using (StreamWriter writer = new StreamWriter(newPath))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                string output = "";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        output += matrix[i, j];
                        if (j < cols - 1)
                        {
                            output += ";";
                        }
                    }
                    if (i < rows - 1)
                    {
                        output += Environment.NewLine;
                    }
                }

                writer.Write(output);
            }

            return newPath;
        }
    }
}