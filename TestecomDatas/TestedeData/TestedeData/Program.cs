using System;

namespace TestedeData
{
    class MainClass
    {
        public DateTime DataIncial { get; set; }
        public DateTime DataFinal { get; set; }


        public static void Main(string[] args)
        {

            DateTime DataInicial = new DateTime(2021, 05, 05, 00, 00, 00 );
            DateTime DataFinal = new DateTime(2021, 07, 06, 00, 00, 00);

            TimeSpan dias = DataFinal.Subtract(DataInicial);

            Console.WriteLine(dias.TotalDays);


            DataInicial = new DateTime(2021, 05, 05, 00, 00, 00);
             DataFinal = new DateTime(2022, 04, 06, 00, 00, 00);

             dias = DataFinal.Subtract(DataInicial);

            Console.WriteLine(dias.TotalDays);


        }
    }
}
