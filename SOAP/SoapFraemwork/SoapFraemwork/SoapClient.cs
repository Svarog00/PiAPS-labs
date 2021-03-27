using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoapFraemwork
{
    class SoapClient
    {
        Calculator.CalculatorSoapClient client = new Calculator.CalculatorSoapClient();


        public int Add(int a, int b)
        {
            return client.Add(a, b);
        }

        public int Subtract(int a, int b)
        {
            return client.Subtract(a, b);
        }

        public int Multiply(int a, int b)
        {
            return client.Multiply(a, b);
        }

        public int Divide(int a, int b)
        {
            if(b == 0)
            {
                return 0;
            }
            return client.Divide(a, b);
        }
    }
}
