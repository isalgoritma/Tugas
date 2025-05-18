using System;
using System.Collections.Generic;

// Interface
public interface Peminjaman
{
    void Pinjam();
    void Kembali();
    bool StatusPeminjaman { get; }
}

// Abstract class
public abstract class Buku
{
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }
    protected Buku(string judul, string penulis, int tahunTerbit)
    {
        Judul = judul;
        Penulis = penulis;
        TahunTerbit = tahunTerbit;
    }

    public abstract void Info();
}


public class BukuFiksi : Buku, Peminjaman
{
    public bool StatusPeminjaman { get; set; }

    public BukuFiksi(string judul, string penulis, int tahunTerbit)
        : base(judul, penulis, tahunTerbit)
    {
        StatusPeminjaman = false;
    }

    public override void Info()
    {
        Console.WriteLine($"[BukuFiksi] Judul: {Judul}, Penulis: {Penulis}, Tahun: {TahunTerbit} | Status: {(StatusPeminjaman ? "Dipinjam" : "Tersedia")}");
    }

    public void Pinjam()
    {
        StatusPeminjaman = true;
    }

    public void Kembali()
    {
        StatusPeminjaman = false;
    }
}

public class BukuNonFiksi : Buku, Peminjaman
{
    public bool StatusPeminjaman { get; private set; }

    public BukuNonFiksi(string judul, string penulis, int tahunTerbit)
        : base(judul, penulis, tahunTerbit)
    {
        StatusPeminjaman = false;
    }

    public override void Info()
    {
        Console.WriteLine($"[Buku Non-Fiksi] Judul: {Judul}, Penulis: {Penulis}, Tahun: {TahunTerbit} | Status: {(StatusPeminjaman ? "Dipinjam" : "Tersedia")}");
    }

    public void Pinjam()
    {
        StatusPeminjaman = true;
    }

    public void Kembali()
    {
        StatusPeminjaman = false;
    }
}

public class Majalah : Buku
{
    public Majalah(string judul, string penulis, int tahunTerbit)
        : base(judul, penulis, tahunTerbit) { }

    public override void Info()
    {
        Console.WriteLine($"[Majalah] Judul: {Judul}, Edisi: {TahunTerbit},  Penulis: {Penulis}");
    }
}

public class Perpustakaan
{
    public List<Buku> DaftarBuku { get; private set; } = new List<Buku>();
    public List<Peminjaman> PeminjamanBuku { get; private set; } = new List<Peminjaman>();

    public void TambahBuku(Buku buku)
    {
        DaftarBuku.Add(buku);
    }

    public void TampilkanSemuaBuku()
    {
        foreach (var buku in DaftarBuku)
        {
            buku.Info();
        }
    }

    public void UbahDataBuku()
    {
        TampilkanSemuaBuku();
        Console.Write("Masukkan judul buku yang ingin diubah: ");
        string judulCari = Console.ReadLine();
        var bukuUbah = DaftarBuku.Find(b => b.Judul.ToLower() == judulCari.ToLower());
        if (bukuUbah != null)
        {
            Console.Write("Masukkan judul baru (kosongkan jika tidak diubah): ");
            string judulBaru = Console.ReadLine();
            Console.Write("Masukkan penulis baru (kosongkan jika tidak diubah): ");
            string penulisBaru = Console.ReadLine();
            Console.Write("Masukkan tahun terbit baru (kosongkan jika tidak diubah): ");
            string tahunBaruStr = Console.ReadLine();

            if (!string.IsNullOrEmpty(judulBaru)) bukuUbah.Judul = judulBaru;
            if (!string.IsNullOrEmpty(penulisBaru)) bukuUbah.Penulis = penulisBaru;
            if (int.TryParse(tahunBaruStr, out int tahunBaru)) bukuUbah.TahunTerbit = tahunBaru;

            Console.WriteLine("Data buku berhasil diubah.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    public void PinjamBuku(int index)
    {
        if (index < 0 || index >= DaftarBuku.Count)
        {
            Console.WriteLine("Indeks tidak valid.");
            return;
        }

        var buku = DaftarBuku[index] as Peminjaman;
        if (buku != null)
        {
            if (buku.StatusPeminjaman)
            {
                Console.WriteLine("Buku sudah dipinjam.");
                return;
            }
            if (PeminjamanBuku.Count >= 3)
            {
                Console.WriteLine("Maksimal 3 buku yang boleh dipinjam.");
                return;
            }
            buku.Pinjam();
            PeminjamanBuku.Add(buku);
            Console.WriteLine("Buku berhasil dipinjam.");
            }
        else
        {
            Console.WriteLine("Buku ini tidak bisa dipinjam.");
        }

    }


    public void KembalikanBuku(int index)
    {
        if (index < 0 || index >= PeminjamanBuku.Count)
        {
            Console.WriteLine("Indeks tidak valid.");
            return;
        }

        var buku = PeminjamanBuku[index];
        buku.Kembali();
        PeminjamanBuku.RemoveAt(index);
        Console.WriteLine("Buku berhasil dikembalikan.");
    }

    public void LihatBukuDipinjam()
    {
        Console.WriteLine("\nDaftar Buku yang Dipinjam:");
        if (PeminjamanBuku.Count == 0)
        {
            Console.WriteLine("Tidak ada buku yang dipinjam.");
        }
        else
        {
            int i = 0;
            foreach (var buku in PeminjamanBuku)
            {
                Console.Write($"{i + 1}. ");
                (buku as Buku).Info();
                i++;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n=== Sistem Manajemen Perpustakaan ===");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Lihat Semua Buku");
            Console.WriteLine("3. Ubah Data Buku");
            Console.WriteLine("4. Pinjam Buku");
            Console.WriteLine("5. Kembalikan Buku");
            Console.WriteLine("6. Lihat Buku Dipinjam");
            Console.WriteLine("7. Keluar");
            Console.Write("\nPilih: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("Jenis Buku (1=Fiksi, 2=Non-Fiksi, 3=Majalah): ");
                    string jenis = Console.ReadLine();
                    Console.Write("Judul: ");
                    string judul = Console.ReadLine();
                    Console.Write("Penulis: ");
                    string penulis = Console.ReadLine();
                    Console.Write("Tahun Terbit: ");
                    int tahun = int.Parse(Console.ReadLine());

                    if (jenis == "1")
                        perpustakaan.TambahBuku(new BukuFiksi(judul, penulis, tahun));
                    else if (jenis == "2")
                        perpustakaan.TambahBuku(new BukuNonFiksi(judul, penulis, tahun));
                    else if (jenis == "3")
                        perpustakaan.TambahBuku(new Majalah(judul, penulis, tahun));
                    else
                        Console.WriteLine("Jenis buku tidak valid.");
                    break;

                case "2":
                    perpustakaan.TampilkanSemuaBuku();
                    break;

                case "3":
                    perpustakaan.UbahDataBuku();
                    break;

                case "4":
                    perpustakaan.TampilkanSemuaBuku();
                    Console.Write("Masukkan indeks buku yang ingin dipinjam (0-n): ");
                    int idxPinjam = int.Parse(Console.ReadLine());
                    perpustakaan.PinjamBuku(idxPinjam);
                    break;

                case "5":
                    perpustakaan.LihatBukuDipinjam();
                    Console.Write("Masukkan indeks buku yang ingin dikembalikan (1-n): ");
                    int idxKembali = int.Parse(Console.ReadLine()) - 1;
                    perpustakaan.KembalikanBuku(idxKembali);
                    break;

                case "6":
                    perpustakaan.LihatBukuDipinjam();
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        }
    }
}
