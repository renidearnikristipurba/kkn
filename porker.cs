using System;
using System.Collections.Generic;

namespace KKN_Nagrak_RT04
{
    class Program
    {
        static List<Mahasiswa> daftarTim = new List<Mahasiswa>();
        static List<Proker> daftarProker = new List<Proker>();

        static void Main(string[] args)
        {
            // Inisialisasi Data Awal
            InisialisasiData();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("====================================================");
                Console.WriteLine("    SISTEM KKN DUSUN NAGRAK RT 004B RW 001 C#       ");
                Console.WriteLine("====================================================");
                Console.ResetColor();
                Console.WriteLine("1. Lihat Profil Wilayah Dusun Nagrak");
                Console.WriteLine("2. Lihat Anggota Tim KKN");
                Console.WriteLine("3. Lihat & Tambah Program Kerja (Proker)");
                Console.WriteLine("4. Keluar Aplikasi");
                Console.Write("\nPilih menu (1-4): ");

                string pilihan = Console.ReadLine();
                switch (pilihan)
                {
                    case "1": TampilkanProfil(); break;
                    case "2": TampilkanTim(); break;
                    case "3": MenuProker(); break;
                    case "4": return;
                    default:
                        Console.WriteLine("Pilihan tidak valid! Tekan Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void InisialisasiData()
        {
            // Data Mahasiswa
            daftarTim.Add(new Mahasiswa("Afwanda Rizqi", "Ketua Kelompok", "S1 Teknik Informatika"));
            daftarTim.Add(new Mahasiswa("Reni Dearni kristi Purba", "Sekretaris", "S1 Teknik Informatika"));
          

            // Data Proker Awal
            daftarProker.Add(new Proker("Bimbingan Belajar Anak", "Pendidikan", "Selesai"));
            daftarProker.Add(new Proker("Sosialisasi PHBS & Posyandu", "Kesehatan", "Progres"));
        }

        static void TampilkanProfil()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== PROFIL WILAYAH KKN ===");
            Console.ResetColor();
            Console.WriteLine("Lokasi        : Dusun Nagrak, RT 004B RW 001");
            Console.WriteLine("Karakteristik : Gotong royong tinggi, mayoritas bertani dan UMKM lokal.");
            Console.WriteLine("Fokus Utama   : Pengembangan Literasi Digital dan Pendampingan Kesehatan.");
            Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
            Console.ReadLine();
        }

        static void TampilkanTim()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== ANGGOTA TIM KKN DUSUN NAGRAK ===");
            Console.ResetColor();
            foreach (var mhs in daftarTim)
            {
                Console.WriteLine($"- {mhs.Nama} ({mhs.Jabatan}) -> Prodi: {mhs.Prodi}");
            }
            Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
            Console.ReadLine();
        }

        static void MenuProker()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== DAFTAR PROGRAM KERJA (PROKER) ===");
            Console.ResetColor();
            
            for (int i = 0; i < daftarProker.Count; i++)
            {
                Console.WriteLine($"{i + 1}. [{daftarProker[i].Status}] {daftarProker[i].NamaProgram} ({daftarProker[i].Bidang})");
            }

            Console.WriteLine("\nApakah Anda ingin menambahkan proker baru? (y/n)");
            string jawab = Console.ReadLine();
            if (jawab?.ToLower() == "y")
            {
                Console.Write("Nama Program Kerja baru: ");
                string nama = Console.ReadLine();
                Console.Write("Bidang (Pendidikan/Kesehatan/Ekonomi/Lingkungan): ");
                string bidang = Console.ReadLine();

                daftarProker.Add(new Proker(nama, bidang, "Belum Mulai"));
                Console.WriteLine("Proker berhasil disimpan! Tekan Enter...");
                Console.ReadLine();
            }
        }
    }
}
     
