using System;


class Perpustakaan
{
    public string Nama { get; set; }
    public string Alamat { get; set; }

    public void InformasiPerpustakaan(string nama, string alamat)
    {
        Nama = nama;
        Alamat = alamat;
    }
}


class Book : Perpustakaan
{
    public string ID { get; set; }
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public string TahunTerbit { get; set; }
    public string Status { get; set; }

    public void CekBuku(string id, string judul, string penulis, string tahunTerbit, string status)
    {
        ID = id;
        Judul = judul;
        Penulis = penulis;
        TahunTerbit = tahunTerbit;
        Status = status;
    }
}




class Program
{

    static void InfoPerpus()
    {
        Perpustakaan perpus = new Perpustakaan();
    }

    static void KoleksiBuku()
    {
        Book buku = new Book();

        Console.Write("Masukkan ID buku: ");
        buku.ID = Console.ReadLine();

        Console.Write("Masukkan Judul buku: ");
        buku.Judul = Console.ReadLine();

        Console.Write("Masukkan Penulis buku: ");
        buku.Penulis = Console.ReadLine();

        Console.Write("Masukkan Tahun Tebit buku: ");
        buku.TahunTerbit = Console.ReadLine();

        Console.Write("Masukkan Status buku (Tersedia/Dipinjam): ");
        buku.Status = Console.ReadLine();



    }

    static void Main()
    {
        Console.WriteLine("\n====PERPUSTAKAAN====");
        Console.WriteLine("1. Informasi Perpustakaan");
        Console.WriteLine("2. Koleksi Buku");

        Console.Write("Pilih: ");
        string pilihan = Console.ReadLine();

        switch (pilihan)
        {
            case "1":
                InfoPerpus();
                Console.WriteLine("Perpustakaan TegalBoto");
                Console.WriteLine("Jl. Tegal BOto no. 1000");
                break;
            case "2":
                KoleksiBuku();
                break;




        }
    }
}