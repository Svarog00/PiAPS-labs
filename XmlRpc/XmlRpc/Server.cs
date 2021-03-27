using System;
using System.Collections;
using Nwc.XmlRpc;

namespace XmlRpc
{
    class Server
    {
        int port = 5005;
        (int, int) indexes = (0, 0);
		string serverName;

        public Server()
        {
			serverName = "FlowServer";
            XmlRpcServer xmlRpcServer = new XmlRpcServer(port);
            xmlRpcServer.Add(serverName, this);
            xmlRpcServer.Start();
			Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Server {serverName} started");
        }
		//Метод, который вызывается клиентом для обработки матрицы
        public ArrayList Method(ArrayList array, int min)
        {
			int[,] matrix = OneDArrayToMatrix(array);
			//Выводим матрицу
			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.Write("\n");
			}

			//Ищем минимальный элемент в диагоналях матрицы
			for (int i = 0; i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= matrix.GetUpperBound(1); j++)
				{
					if (j - i >= 0)
					{
						if (matrix[j, j - i] < min)
						{
							min = matrix[j, j - i];
							indexes.Item1 = j;
							indexes.Item2 = j - i;
						}
						if (matrix[j - i, j] < min)
						{
							min = matrix[j - i, j];
							indexes.Item1 = j - i;
							indexes.Item2 = j;
						}
					}
				}
			}
			Console.WriteLine(min);
			Console.WriteLine(indexes);

			int step = 0;
			//Замена диагонали, в которой находится минимальный элемент, на нули
			if (indexes.Item1 == indexes.Item2)
			{
				for (int i = 0; i <= matrix.GetUpperBound(0); i++)
				{
					indexes.Item1 = 0;
					indexes.Item2 = 0;
					matrix[i, i] = 0;
				}
			}
			else if (indexes.Item1 > indexes.Item2)
			{
				step = indexes.Item1 - indexes.Item2;
				indexes.Item1 = step;
				indexes.Item2 = 0;
				for (int i = step; i <= matrix.GetUpperBound(0); i++)
				{
					matrix[i, i - step] = 0;
				}
			}
			else if (indexes.Item1 < indexes.Item2)
			{
				step = indexes.Item2 - indexes.Item1;
				indexes.Item1 = 0;
				indexes.Item2 = step;
				for (int i = step; i <= matrix.GetUpperBound(0); i++)
				{
					matrix[i - step, i] = 0;
				}
			}
			//Возведение в квадрат элементов, которые находятся ниже матрицы
			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++, indexes.Item1++, indexes.Item2++)
			{
				for (int j = matrix.GetLowerBound(1); j <= matrix.GetUpperBound(1); j++)
				{
					if (i >= indexes.Item1 && j >= indexes.Item2)
					{
						continue;
					}
					else
					{
						matrix[i, j] = (int)Math.Pow(matrix[i, j], 2);
					}
				}
			}

			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.Write("\n");
			}
			array = MatrixToOneDArray(matrix);
			array.Add(min);
			return array;
		}
		//Преобразование входной матрицы в одномерный массив
		int[,] OneDArrayToMatrix(ArrayList arrayList)
        {
			int[] array = new int[arrayList.Count];
			arrayList.CopyTo(array);

			int[,] matrix = new int[(int)Math.Sqrt(array.Length), (int)Math.Sqrt(array.Length)];

			for(int i = 0; i < (int)Math.Sqrt(array.Length); i++)
            {
				for(int j = 0; j < (int)Math.Sqrt(array.Length); j++)
                {
					matrix[i, j] = array[i * (int)Math.Sqrt(array.Length) + j];
				}
            }

			return matrix;
        }
		//Функция преобрзования матрицы в одномерный массив для отправки клиенту
		ArrayList MatrixToOneDArray(int[,] matrix)
        {
			ArrayList arrayList = new ArrayList();

			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					arrayList.Add(matrix[i, j]);
				}
			}
			return arrayList;
        }
	}
}

