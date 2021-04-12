using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapWebServ
{
    public class Race
    {
        public int Id { get; private set; }
        public string Source { get; private set; }
        public string Destinition { get; private set; }
        public DateTime data;
        public Seat[] seats;
        public int SeatsAmount { get; private set;}
        public bool isGone;

        public Race()
        {}

        public Race(int id, string source, string destinition, DateTime time, int maxSeats , bool status)
        {
            Id = id;
            Source = source;
            Destinition = destinition;
            data = time;
            SeatsAmount = maxSeats;
            seats = new Seat[maxSeats];
            for(int i = 0; i < maxSeats; i++)
            {
                seats[i] = new Seat();
                seats[i].SetSeat(i + 1, false);
            }
            isGone = status;
        }

        public bool ReserveSeat(int num)
        {
            if(!seats[num - 1].IsReserved)
            {
                  --SeatsAmount;
                  seats[num - 1].ReserveSeat();
                  return true;
            }
            else
            {
                 return false;
            }
        }
    }
}