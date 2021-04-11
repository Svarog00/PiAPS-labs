using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace SoapWebServ
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private static List<Race> races = new List<Race>();
        private static bool isInitialize = false;

        public WebService()
        {
            if(!isInitialize)
            {
                InitializeRaces();
                isInitialize = true;
            }    
        }

        [WebMethod]
        public string ShowRaces(string source, string destinition)
        {
            StringBuilder buidler = new StringBuilder();
            foreach (Race race in races)
            {
                if(race.Source == source && race.Destinition == destinition)
                {
                    buidler.Append($"Race ID: {race.Id}\nSource:{race.Source}\nDestinition:{race.Destinition}\nTime:{race.data}\nSeats amount:{race.SeatsAmount}\nGone:{race.isGone}\n\n");
                }
            }
            return buidler.ToString();
        }
        [WebMethod]
        public string CheckTickets(string source, string destinition, DateTime time)
        {
            StringBuilder buidler = new StringBuilder();
            foreach(Race race in races)
            {
                if(race.Source == source && race.Destinition == destinition && race.data == time)
                {
                    buidler.Append("Race ID: " + race.Id + '\n');
                    for(int i = 0; i < race.seats.Length; i++)
                    {
                        buidler.Append("Seat #" + race.seats[i].Num + " - " + race.seats[i].IsReserved + '\n');
                    }
                    buidler.Append('\n');
                }
            }
            return buidler.ToString();
        }

        [WebMethod]
        public string BuyTicket(string source, string destinition, DateTime time, int seat)
        {
            foreach (Race race in races)
            {
                if (race.Source == source && race.Destinition == destinition && race.data == time)
                {
                    if(seat > race.seats.Length)
                    {
                        return "So big digit";
                    }
                    if(race.SeatsAmount == 0)
                    {
                        return "Not free seats, sorry";
                    }
                    if (race.ReserveSeat(seat))
                    {
                        return "Succesfully!!";
                    }
                    else
                    {
                        return "This seat is reserved!";
                    }
                }
            }
            return "Not Found";
        }

        private void InitializeRaces()
        {
            races.Add(new Race(1, "Orel", "Znamenka", new DateTime(2021, 04, 03, 12, 40, 0), 24, false));
            races.Add(new Race(2, "Orel", "Maloarkhangelsk", new DateTime(2021, 04, 03, 11, 50, 0), 20, false));
            races.Add(new Race(3, "Orel", "Maloarkhangelsk", new DateTime(2021, 04, 03, 13, 00, 0), 24, false));
            races.Add(new Race(4, "Orel", "Maloarkhangelsk", new DateTime(2021, 04, 03, 6, 30, 0), 24, false));
        }
    }
}
