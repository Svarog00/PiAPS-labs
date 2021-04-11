using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapWebServiceSer
{
	class Race
	{
		public struct SeatPlace
		{
			public int Num { get; set; }
			public bool IsReserved { get; set; }

			public SeatPlace(int num, bool isReserved)
            {
				Num = num;
				IsReserved = isReserved;
            }
		}

		private int _id;
		private string _source;
		private string _destination;
		public SeatPlace[] mas;
		public int TicketsAmount 
		{
			get;
			private set;
		}
		
		public Race()
		{
			_id = -1;
			_source = "none";
			_destination = "none";
			//mas = new SeatPlace[24];
			TicketsAmount = 0;
		}
		public Race(int id, string source, string destinition, int ticketsAmount, int maxSeat)
		{
			_id = id;
			_source = source;
			_destination = destinition;
			TicketsAmount = ticketsAmount;
		}
	}
}
