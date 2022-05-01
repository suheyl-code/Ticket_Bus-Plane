using BiletAlmak.Bus;
using BiletAlmak.Airplane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAlmak
{
    internal class Ulasim
    {
        public DateTime Date { get; set; }

        private string _destination;
        public string Destination
        {
            get { return _destination; }
            set
            {
                if (value.ToLower().Contains("adana"))
                    _destination = "Adana";
                else if (value.ToLower().Contains("ankara"))
                    _destination = "Ankara";
                else if (value.ToLower().Contains("antalya"))
                    _destination = "Antalya";
                else if (value.ToLower().Contains("mersin"))
                    _destination = "Mersin";
                else
                    _destination = string.Empty;
            }
        }

        private string _transportationModel;
        public string TransportationModel
        {
            get { return _transportationModel; }
            set
            {
                    _transportationModel = int.TryParse(value, out int num) ?
                        value : throw new InvalidCastException("Sadece Sayı Olmalıdır!");
            }
        }

        private int _numberOfSeats;
        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set
            {
                switch (this.TransportationModel)
                {
                    case "1":
                        if (value > 30)
                        {
                            Print.WriteLine("30'dan fazla sandaliye rezervasyonu yapılamaz!", ConsoleColor.Red);
                            Environment.Exit(0);
                        }
                        else if (value <= 0)
                        {
                            Print.WriteLine("Sıfır veya olumsuz numara  girilmaz!", ConsoleColor.Red);
                            Environment.Exit(-1);
                        }
                        else
                        {
                            _numberOfSeats = value;
                        }
                        break;
                    case "2":
                        if (value > 230 && SeatPosition == 'c')
                        {
                            Print.WriteLine("30'dan fazla sandaliye rezervasyonu yapılamaz!", ConsoleColor.Red);
                            Environment.Exit(0);
                        }
                        else if (value > 180 && SeatPosition == 'b')
                        {
                            Print.WriteLine("30'dan fazla sandaliye rezervasyonu yapılamaz!", ConsoleColor.Red);
                            Environment.Exit(0);
                        }
                        else if (value > 130 && SeatPosition == 'a')
                        {
                            Print.WriteLine("30'dan fazla sandaliye rezervasyonu yapılamaz!", ConsoleColor.Red);
                            Environment.Exit(0);
                        }
                        else if (value <= 0)
                        {
                            Print.WriteLine("Sıfır veya olumsuz numara  girilmaz!", ConsoleColor.Red);
                            Environment.Exit(-1);
                        }
                        else
                        {
                            _numberOfSeats = value;
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        public double TicketFeePerPerson { get; set; }

        public double SumTicketFee { get; set; }

        public List<int> SeatNumber { get; set; } = new List<int>();

        private string _company;
        public string Company
        {
            get { return _company; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Contains("turkish"))
                        _company = "TurkishAirlines";
                    else if (value.Contains("anadolu"))
                        _company = "AnadoluJet";
                    else if (value.Contains("pega"))
                        _company = "Pegasus";
                    else if (value.Contains("onur"))
                        _company = "OnurAir";
                    else if (value.Contains("metro"))
                        _company = "MetroTurizm";
                    else if (value.Contains("ulusoy"))
                    {
                        _company = "AliOsmanUlusoy";
                    }
                    else
                        _company = "Bilinmeyen Firma!";
                }
                else
                    _company = string.Empty;
            }
        }

        private char _seatPosition;
        public char SeatPosition
        {
            get { return _seatPosition; }
            set
            {
                if (!value.Equals('a') && !value.Equals('b') && !value.Equals('c'))
                {
                    Print.WriteLine("Yanlış seçim! 'ÖN' Koltuk Seçildi.", ConsoleColor.Red);
                    _seatPosition = 'a';
                }
                else
                    _seatPosition = value;
            }
        }

        private string _istanbul_Ankara;
        public string Istanbul_Ankara
        {
            get { return _istanbul_Ankara; }
            set
            {
                if (value.Equals("Bus"))
                {
                    _istanbul_Ankara = "İstanbul ile Ankara arası kara yolculuğu mesafesi 450 km dir.\nBu süre 6 saate yakın sürmektedir.";
                }
                else
                {
                    _istanbul_Ankara = "İstanbul ile Ankara Uçuş süresi yaklaşık 1 saat 15 dakıka dir.";
                }
            }
        }

        private string _istanbul_Antalya;
        public string Istanbul_Antalya
        {
            get { return _istanbul_Antalya; }
            set
            {
                if (value.Equals("Bus"))
                {
                    _istanbul_Antalya = "İstanbul ile Antalya arası yaklaşık olarak toplam 698 Kilometre mesafededir.\nİstanbul Antalya arası yolculuk süresi otobüslerimiz ile yaklaşık 8 saat 14 dakika sürecektir.";
                }
                else
                {
                    _istanbul_Antalya = "İstanbul ile Antalya Uçuş süresi yaklaşık 1 saat 25 dakıka dir.";
                }
            }
        }

        private string _istanbul_Adana;
        public string Istanbul_Adana
        {
            get { return _istanbul_Adana; }
            set
            {
                if (value.Equals("Bus"))
                {
                    _istanbul_Adana = "İstanbul ile Adana arası yaklaşık olarak toplam 939 Kilometre mesafededir.\nİstanbul Adana arası yolculuk süresi otobüslerimiz ile 13 saat 34 dakika sürecektir.";
                }
                else
                {
                    _istanbul_Adana = "İstanbul ile Adana Uçuş süresi yaklaşık 1 saat 55 dakıka dir.";
                }
            }
        }

        private string _istanbul_Mersin;
        public string Istanbul_Mersin
        {
            get { return _istanbul_Mersin; }
            set
            {
                if (value.Equals("Bus"))
                {
                    _istanbul_Mersin = "İstanbul ile Mersin arası yaklaşık olarak toplam 932 Kilometre mesafededir.\nİstanbul Mersin arası yolculuk süresi otobüslerimiz ile 13 saat 44 dakika sürecektir.";
                }
                else
                {
                    _istanbul_Mersin = "İstanbul ile Mersin Uçuş süresi yaklaşık 1 saat 55 dakıka dir.";
                }
            }
        }

        public Ulasim()
        {
            DateTime dt = DateTime.Now;
            this.Date = dt;

        }

        /// <summary>
        /// programın başlangiç noktası.
        /// </summary>
        public void Run()
        {
            Console.Write("GİDİLECEK YER (Adana/Ankara/Antalya/Mersin): ");
            this.Destination = Console.ReadLine();
            if (string.IsNullOrEmpty(this.Destination))
            {
                Print.WriteLine("yanlış şehir adı veya şehirler listemizde mevcut değil!", ConsoleColor.Red);
                Environment.Exit(-1);
            }

            Console.Write("ULAŞIM YOLU SEÇİNİZ\n\t1. OTOBÜS\n\t2. UÇAK\n(1/2): ");
            this.TransportationModel = Console.ReadLine();

            if (this.TransportationModel == "1")
            {
                this.SetBusCompanies();
            }
            else if(this.TransportationModel == "2")
            {
                this.SetPlaneCompanies();
            }
            else
            {
                Print.WriteLine("Yanliş Numara!", ConsoleColor.Red);
                Environment.Exit(-1);
            }

            switch (this.TransportationModel)
            {
                case "1":   // Otobüs
                    {
                        switch (this.Destination)
                        {
                            case "Ankara":
                                if (this.Company == "MetroTurizm")
                                    _ = new MetroTurizm(this);
                                else if (this.Company == "AliOsmanUlusoy")
                                    _ = new AliOsmanUlusoy(this);
                                break;
                            case "Antalya":
                                if (this.Company == "MetroTurizm")
                                    _ = new MetroTurizm(this);
                                else if (this.Company == "AliOsmanUlusoy")
                                    _ = new AliOsmanUlusoy(this);
                                break;
                            case "Adana":
                                if (this.Company == "MetroTurizm")
                                    _ = new MetroTurizm(this);
                                else if (this.Company == "AliOsmanUlusoy")
                                    _ = new AliOsmanUlusoy(this);
                                break;
                            case "Mersin":
                                if (this.Company == "MetroTurizm")
                                    _ = new MetroTurizm(this);
                                else if (this.Company == "AliOsmanUlusoy")
                                    _ = new AliOsmanUlusoy(this);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "2":   // Uçak
                    switch (this.Destination)
                    {
                        case "Ankara":
                            if (this.Company == "TurkishAirlines")
                                _ = new TurkishAirlines(this);
                            else if (this.Company == "AnadoluJet")
                                _ = new AnadoluJet(this);
                            else if (this.Company == "Pegasus")
                                _ = new Pegasus(this);
                            else if (this.Company == "OnurAir")
                                _ = new OnurAir(this);
                            break;
                        case "Antalya":
                            if (this.Company == "TurkishAirlines")
                                _ = new TurkishAirlines(this);
                            else if (this.Company == "AnadoluJet")
                                _ = new AnadoluJet(this);
                            else if (this.Company == "Pegasus")
                                _ = new Pegasus(this);
                            else if (this.Company == "OnurAir")
                                _ = new OnurAir(this);
                            break;
                        case "Adana":
                            if (this.Company == "TurkishAirlines")
                                _ = new TurkishAirlines(this);
                            else if (this.Company == "AnadoluJet")
                                _ = new AnadoluJet(this);
                            else if (this.Company == "Pegasus")
                                _ = new Pegasus(this);
                            else if (this.Company == "OnurAir")
                                _ = new OnurAir(this);
                            break;
                        case "Mersin":
                            if (this.Company == "TurkishAirlines")
                                _ = new TurkishAirlines(this);
                            else if (this.Company == "AnadoluJet")
                                _ = new AnadoluJet(this);
                            else if (this.Company == "Pegasus")
                                _ = new Pegasus(this);
                            else if (this.Company == "OnurAir")
                                _ = new OnurAir(this);
                            break;
                        default:
                            break;
                    }
                    break;
            }
            this.Reservation();
        }

        private void SetPlaneCompanies()
        {
            Console.WriteLine("FİRMA SEÇİNİZ: ");
            string[] planeCompanies = { "Turkish Airlines", "Pegasus", "AnadoluJet", "OnurAir" };
            foreach (var item in planeCompanies)
            {
                Console.WriteLine("\t" + item);
            }
            Console.Write("HANGI? ");
            this.Company = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(this.Company))
            {
                Print.WriteLine("Hata!", ConsoleColor.Red);
                Environment.Exit(-1);
            }
            else if (this.Company == "Bilinmeyen Firma!")
            {
                Print.WriteLine("Firmayi Bulamadik!", ConsoleColor.Red);
                Environment.Exit(-1);
            }
        }

        private void SetBusCompanies()
        {
            Console.WriteLine("FİRMA SEÇİNİZ: ");
            string[] busCompanies = { "Ali Osman Ulusoy", "Metro Turizm" };
            foreach (var item in busCompanies)
            {
                Console.WriteLine("\t" + item);
            }
            Console.Write("HANGI? ");
            this.Company = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(this.Company))
            {
                Print.WriteLine("Hata!", ConsoleColor.Red);
                Environment.Exit(-1);
            }
            else if(this.Company == "Bilinmeyen Firma!")
            {
                Print.WriteLine("Firmayi Bulamadik!", ConsoleColor.Red);
                Environment.Exit(-1);
            }

        }

        internal void SetSeatPosition()
        {
            Console.WriteLine("KOLTUK SEÇİMİ:");
            Console.WriteLine("\ta- ÖN");
            Console.WriteLine("\tb- ORTA");
            Console.WriteLine("\tc- ARKA");
            Console.Write("HANGI (a/b/c): ");
            try
            {
                this.SeatPosition = Convert.ToChar(Console.ReadLine());
            }
            catch (FormatException)
            {
                Print.WriteLine("Alfabe Seçmelısınız!", ConsoleColor.Red);
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>int Listesi</returns>
        internal List<int> SetSeatNumber()
        {
            if (this.SeatPosition == 'a')
            {
                switch (this.TransportationModel)
                {
                    case "1":   // Otobüs
                        for (int i = 0; i < this.NumberOfSeats; i++)
                        {
                            this.SeatNumber.Add(i + 1);
                        }
                        break;

                    case "2": // Uçak
                        this.NumberOfSeats += 100;
                        for (int i = 100; i < this.NumberOfSeats; i++)
                        {
                            this.SeatNumber.Add(i + 1);
                        }
                        break;

                }
            }
            else if (this.SeatPosition == 'b')
            {
                switch (this.TransportationModel)
                {
                    case "1":   // Otobüs
                        NumberOfSeats += 7;
                        for (int i = 7; i < this.NumberOfSeats; i++)
                        {
                            this.SeatNumber.Add(i + 1);
                        }
                        break;

                    case "2": // Uçak
                        this.NumberOfSeats += 150;
                        for (int i = 150; i < this.NumberOfSeats; i++)
                        {
                            this.SeatNumber.Add(i + 1);
                        }
                        break;
                }
            }
            else if (this.SeatPosition == 'c')
            {
                switch (this.TransportationModel)
                {
                    case "1":   // Otobüs
                        NumberOfSeats += 15;
                        for (int i = 15; i < this.NumberOfSeats; i++)
                        {
                            this.SeatNumber.Add(i + 1);
                        }
                        break;

                    case "2": // Uçak
                        this.NumberOfSeats += 200;
                        for (int i = 200; i < this.NumberOfSeats; i++)
                        {
                            this.SeatNumber.Add(i + 1);
                        }
                        break;
                }
            }
            return SeatNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetNumberOfPeople()
        {
            Console.Write("KİŞİ SAYISI (1-30 arası): ");
            try
            {
                this.NumberOfSeats = Convert.ToInt32(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Print.WriteLine("Olumsuz sayı girilmaz!", ConsoleColor.Red);
                Environment.Exit(-1);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetTicketFee()
        {
            switch (this.Destination)
            {
                case "Ankara":
                    if (this.TransportationModel == "1")    // Otobüs
                    {
                        switch (this.Company)
                        {
                            case "AliOsmanUlusoy":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 53.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 50.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 51.0d;
                                }
                                break;
                            case "MetroTurizm":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 57.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 50.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 55.0d;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (this.Company)
                        {
                            case "TurkishAirlines":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 403.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 400.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 401.0d;
                                }
                                break;
                            case "AnadoluJet":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 381.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 378.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 380.0d;
                                }
                                break;
                            case "Pegasus":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 351.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 348.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 350.0d;
                                }
                                break;
                            case "OnurAir":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 366.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 363.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 365.0d;
                                }
                                break;
                        }
                    }
                    break;
                case "Antalya":
                    if (this.TransportationModel == "1")    // Otobüs
                    {
                        switch (this.Company)
                        {
                            case "AliOsmanUlusoy":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 71.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 68.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 70.0d;
                                }
                                break;
                            case "MetroTurizm":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 76.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 72.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 75.0d;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (this.Company)
                        {
                            case "TurkishAirlines":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 552.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 548.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 550.0d;
                                }
                                break;
                            case "AnadoluJet":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 522.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 518.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 520.0d;
                                }
                                break;
                            case "Pegasus":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 492.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 488.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 490.0d;
                                }
                                break;
                            case "OnurAir":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 502.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 498.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 500.0d;
                                }
                                break;
                        }
                    }
                    break;
                case "Adana":
                    if (this.TransportationModel == "1")    // Otobüs
                    {
                        switch (this.Company)
                        {
                            case "AliOsmanUlusoy":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 91.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 88.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 90.0d;
                                }
                                break;
                            case "MetroTurizm":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 96.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 93.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 95.0d;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (this.Company)
                        {
                            case "TurkishAirlines":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 651.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 648.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 650.0d;
                                }
                                break;
                            case "AnadoluJet":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 621.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 618.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 620.0d;
                                }
                                break;
                            case "Pegasus":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 592.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 588.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 590.0d;
                                }
                                break;
                            case "OnurAir":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 601.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 598.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 600.0d;
                                }
                                break;
                        }
                    }
                    break;
                case "Mersin":
                    if (this.TransportationModel == "1")    // Otobüs
                    {
                        switch (this.Company)
                        {
                            case "AliOsmanUlusoy":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 93.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 89.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 92.0d;
                                }
                                break;
                            case "MetroTurizm":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 7;
                                    this.TicketFeePerPerson = 98.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 15;
                                    this.TicketFeePerPerson = 95.0d;
                                }
                                else
                                {
                                    this.TicketFeePerPerson = 97.0d;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (this.Company)
                        {
                            case "TurkishAirlines":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 647.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 643.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 645.0d;
                                }
                                break;
                            case "AnadoluJet":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 616.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 614.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 615.0d;
                                }
                                break;
                            case "Pegasus":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 587.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 584.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 585.0d;
                                }
                                break;
                            case "OnurAir":
                                if (this.SeatPosition == 'b')
                                {
                                    this.NumberOfSeats -= 150;
                                    this.TicketFeePerPerson = 597.0d;
                                }
                                else if (this.SeatPosition == 'c')
                                {
                                    this.NumberOfSeats -= 200;
                                    this.TicketFeePerPerson = 593.0d;
                                }
                                else
                                {
                                    this.NumberOfSeats -= 100;
                                    this.TicketFeePerPerson = 595.0d;
                                }
                                break;
                        }
                    }
                    break;
            }
            this.SumTicketFee = this.TicketFeePerPerson * this.NumberOfSeats;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void Reservation()
        {
            foreach (var item in SeatNumber)
            {
                Print.WriteLine($"Sandaliye No: {item} Rezerve oldu.", ConsoleColor.Cyan);

            }
            Print.WriteLine($"*** Toplam Fiyat: {this.SumTicketFee:C2} ***", ConsoleColor.Cyan);
            Print.WriteLine($"Odeme için < {Date.AddDays(3)} > zamanınız var.", ConsoleColor.Magenta);
        }
    }
}