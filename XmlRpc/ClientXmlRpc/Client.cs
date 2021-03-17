using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nwc.XmlRpc;

namespace ClientXmlRpc
{
    class Client
    {
		int[,] matrix;
		ArrayList arrayList;
		int size;
		int min;
		private static string URL = "http://127.0.0.1:5005";

		public Client()
        {
			Console.WriteLine("Server: " + URL);//Show the server's ip

			min = int.MaxValue;
			arrayList = new ArrayList();

			Console.Write("Size: ");//Fill a matrix
			size = Int32.Parse(Console.ReadLine());
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine($"Line {i + 1}: ");
				for (int j = 0; j < size; j++)
				{
					arrayList.Add(Int32.Parse(Console.ReadLine()));
				}
			}
			matrix = OneDArrayToMatrix(arrayList); //Save the matrix
			//Create xmlRpc request
			XmlRpcRequest client = new XmlRpcRequest();
			client.MethodName = "FlowServer.Method";
			client.Params.Add(arrayList);
			//Call method from XmlServer
			try
			{
				arrayList = (ArrayList)client.Invoke(URL);
				Console.Clear();
				ShowMatix();
			}
			catch (XmlRpcException serverException)
			{
				Console.WriteLine("Fault {0}: {1}", serverException.FaultCode, serverException.FaultString);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception " + e);
			}

			Console.ReadLine();
		}

		void ShowMatix()
        {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Изначальная матрица: ");
			Console.Write("\n");
			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.Write("\n");
			}

			Console.WriteLine($"Минимальный элемент: {min}");
			matrix = OneDArrayToMatrix(arrayList);
			Console.WriteLine("Результирующая матрица: ");
			for (int i = matrix.GetLowerBound(0); i <= matrix.GetUpperBound(0); i++)
			{
				for (int j = matrix.GetLowerBound(0); j <= matrix.GetUpperBound(1); j++)
				{
					Console.Write($"{matrix[i, j]} ");
				}
				Console.Write("\n");
			}
		}

		int[,] OneDArrayToMatrix(ArrayList arrayList)
		{
			int[] array = new int[arrayList.Count];
			arrayList.CopyTo(array);

			int[,] matrix = new int[(int)Math.Sqrt(array.Length), (int)Math.Sqrt(array.Length)];

			for (int i = 0; i < (int)Math.Sqrt(array.Length); i++)
			{
				for (int j = 0; j < (int)Math.Sqrt(array.Length); j++)
				{
					matrix[i, j] = array[i * (int)Math.Sqrt(array.Length) + j];
				}
			}

			return matrix;
		}
	}
}
