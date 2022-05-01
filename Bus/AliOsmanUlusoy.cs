﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAlmak.Bus
{
    internal class AliOsmanUlusoy : Ulasim
    {
        public AliOsmanUlusoy(Ulasim u)
        {
            Print.WriteLine("\tWelcome to Ali Osman Ulusoy Online System!", ConsoleColor.Blue);
            Print.WriteLine("Ulusoy firmasının varış noktası < Ankara >, < Antalya >, < Adana > ve < Mersin >", ConsoleColor.Blue);

            if (u.Destination != null)
            {
                RestProgram(u);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        private static void RestProgram(Ulasim u)
        {
            if (u.Destination.ToLower() == "ankara")
            {
                u.Istanbul_Ankara = "Bus";
                Print.WriteLine(u.Istanbul_Ankara, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            else if (u.Destination.ToLower() == "antalya")
            {
                u.Istanbul_Antalya = "Bus";
                Print.WriteLine(u.Istanbul_Antalya, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            else if (u.Destination.ToLower() == "adana")
            {
                u.Istanbul_Adana = "Bus";
                Print.WriteLine(u.Istanbul_Adana, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            else if (u.Destination.ToLower() == "mersin")
            {
                u.Istanbul_Mersin = "Bus";
                Print.WriteLine(u.Istanbul_Mersin, ConsoleColor.Green);

                u.SetNumberOfPeople();
                u.SetSeatPosition();
                u.SetSeatNumber();
                u.SetTicketFee();

            }
            Print.WriteLine($"Kişisel Bilet Fiyat {u.TicketFeePerPerson:C2}", ConsoleColor.DarkBlue);
        }
    }
}
