using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAlmak.Airplane
{
    internal class Pegasus : Ulasim
    {

        public Pegasus(Ulasim u)
        {
            Print.WriteLine("\tWelcome to Pegasus Online System!", ConsoleColor.Blue);
            Print.WriteLine("Pegasus firmasının varış noktası < Ankara >, < Antalya >, < Adana > ve < Mersin >", ConsoleColor.Blue);
            if (u.Destination != null)
            {
                RestProgram(u);
            }

        }

        /// <summary>
        /// bazı ana sorulardan sonra program akışı buradan itibarendir. ama yine de temel sınıftan yöntemleri çağırıyor.
        /// </summary>
        /// <param name="u"></param>
        private static void RestProgram(Ulasim u)
        {
            if (u.Destination.ToLower() == "ankara")
            {
                u.Istanbul_Ankara = "Plane";
                Print.WriteLine(u.Istanbul_Ankara, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            else if (u.Destination.ToLower() == "antalya")
            {
                u.Istanbul_Antalya = "Plane";
                Print.WriteLine(u.Istanbul_Antalya, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            else if (u.Destination.ToLower() == "adana")
            {
                u.Istanbul_Adana = "Plane";
                Print.WriteLine(u.Istanbul_Adana, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            else if (u.Destination.ToLower() == "mersin")
            {
                u.Istanbul_Mersin = "Plane";
                Print.WriteLine(u.Istanbul_Mersin, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            Print.WriteLine($"Kişisel Bilet Fiyat: {u.TicketFeePerPerson:C2}", ConsoleColor.DarkBlue);
        }

    }
}
