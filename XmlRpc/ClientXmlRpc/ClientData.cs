using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientXmlRpc
{
	class ClientData
	{
		public int[,] matrix;
		public int min;

		public ClientData(int[,] matrix)
		{
			this.matrix = matrix;
			min = int.MaxValue;
		}

		public void ShowData()
		{
			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.Write("\n");
			}

			Console.WriteLine($"Минимальный элемент: {min}");

			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.Write("\n");
			}
		}
	}
}
