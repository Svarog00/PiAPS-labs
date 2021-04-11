using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapWebServ
{
    public class Seat
    { 
        public int Num { get; private set; }
        public bool IsReserved { get; private set; }

        public void SetSeat(int num, bool isReserved)
        {
            Num = num;
            IsReserved = isReserved;
        }

        public void ReserveSeat()
        {
            IsReserved = true;
        }
    }
}