using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    class SoapClient
    {
        SoapWebService.WebServiceSoapClient client = new SoapWebService.WebServiceSoapClient();
        
        public string ShowRaces(string source, string destinition)
        {
            return client.ShowRaces(source, destinition);
            
        }

        public string CheckTickets(string source, string destinition, DateTime time)
        {
            return client.CheckTickets(source, destinition, time);
        }

        public string BuyTicket(string source, string destinition, DateTime time, int seat)
        {
            return client.BuyTicket(source, destinition, time, seat);
        }
    }
}
