using System;

namespace ManajemenKaryawan
{
    //Parent Class
    class Karyawan
    {
        private string nama;
        private string id;
        private string jenis;
        private double gajiPokok;

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Jenis
        {
            get { return jenis; }
            set { jenis = value; }
        }

        public double GajiPokok
        {
            get { return gajiPokok; }
            set { gajiPokok = value; }
        }

        public virtual double HitungGaji()
        {
            return gajiPokok;
        }
    }

    // Karyawan Tetap (Child Class)
    class KaryawanTetap : Karyawan
    {
        private const double BonusTetap = 500000;
        public override double HitungGaji()
        {
            return GajiPokok + BonusTetap;
        }
    }

    // Karyawan Kontrak (Child Class)
    class KaryawanKontrak : Karyawan
    {
        private const double PotonganKontrak = 200000;
        public override double HitungGaji()
        {
            return GajiPokok - PotonganKontrak;
        }
    }

    // Karyawan Magang (Child Class)
    class KaryawanMagang : Karyawan
    {
        public override double HitungGaji()
        {
            return GajiPokok;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Sistem Manajemen Karyawan ===");
            Console.WriteLine("Jenis Karyawan (tetap / kontrak / magang)");
            Console.Write("Masukkan jenis karyawan\t: ");
            string jenis = Console.ReadLine().ToLower();
            Console.Write("Masukkan nama karyawan\t: ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan ID karyawan\t: ");
            string id = Console.ReadLine();
            Console.Write("Masukkan gaji pokok\t: ");
            double gajiPokok = Convert.ToDouble(Console.ReadLine());

            Karyawan karyawan;

            switch (jenis.ToLower())
            {
                case "tetap":
                    karyawan = new KaryawanTetap();
                    break;
                case "kontrak":
                    karyawan = new KaryawanKontrak();
                    break;
                case "magang":
                    karyawan = new KaryawanMagang();
                    break;
                default:
                    Console.WriteLine("Jenis karyawan tidak valid.");
                    return;
            }

            karyawan.Nama = nama;
            karyawan.ID = id;
            karyawan.Jenis = jenis; 
            karyawan.GajiPokok = gajiPokok;

            Console.WriteLine("\n=== Data Karyawan ===");
            Console.WriteLine("Nama\t\t: " + karyawan.Nama);
            Console.WriteLine("ID\t\t: " + karyawan.ID);
            Console.WriteLine("Jenis Karyawan\t: " + karyawan.Jenis);
            Console.WriteLine("Gaji Pokok\t: " + karyawan.GajiPokok);
            Console.WriteLine("Gaji Akhir\t: " + karyawan.HitungGaji());
        }
    }
}




