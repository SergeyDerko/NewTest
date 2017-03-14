using System.Collections.Generic;

namespace WebClientMVC.Models
{
    public class Expression11
    {
        public double a;
        public double b;

        public Expression11()
        {

        }

        public double Sum()
        {
            return a + b;
        }

        public double Sub()
        {
            return a - b;
        }

        public double Mult()
        {
            return a * b;
        }

        public double Div()
        {
            if (b != 0 && b != null)
            {
                return a / b;
            }
            else return 0.00000001;
        }

        public List<string> MultiplicationTable()
        {
            var str = new List<string>();
            for (int first = 2; first < 10; first++)
            {
                for (int second = 1; second < 11; second++)
                {
                    int resalt = first * second;
                    str.Add($"{first} x {second} = {resalt}");
                }
            }
            return str;
        }
    }
}