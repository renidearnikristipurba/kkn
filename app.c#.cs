using System;
using System.Collections.Generic;

namespace KKN_Nagrak_App
{
    // 1. Model Data untuk Program Kerja
    public class ProgramKerja
    {
        public string NamaProker { get; set; }
        public string Bidang { get; set; }
        public string TargetSasaran { get; set; }
        public string Status { get; set; } // "Belum Mulai", "Sedang Berjalan", "Selesai"

        public ProgramKerja(string nama, string bidang, string target, string status = "Belum Mulai")
        {
            NamaProker = nama;
            Bidang = bidang;
            TargetSasaran = target;
            Status = status;
        }
    }

    // 2. Model Data untuk Anggota Kelompok KKN
    public class AnggotaTim
    {
        public string Nama { get; set; }
        public string Jabatan { get; set; }
        public string Jurusan { get; set; }

        public AnggotaTim(string nama, string jabatan, string jurusan)
        {
            Nama = nama;
            Jabatan = jabatan;
            Jurusan = jurusan;
        }
    }

    class Program
    {
        // Database Simulasi di Memory
        static List<ProgramKerja> listProker = new List<ProgramKerja>();
        static List<AnggotaTim> listTim = new List<AnggotaTim>();

        static void Main(string[] args)
        {
            // Mengisi data awal (seeding data)
            InisialisasiDataAwal();

            bool berjalan = true;
            while (berjalan)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=========================================================");
                Console.WriteLine("    SISTEM INFORMASI KKN DUSUN NAGRAK RT 004B RW 001    ");
                Console.WriteLine("=========================================================");
                Console.ResetColor();
                Console.WriteLine("1. Lihat Profil Wilayah & Posko KKN");
                Console.WriteLine("2. Lihat Daftar Anggota Tim KKN");
                Console.WriteLine("3. Lihat & Monitoring Program Kerja (Proker)");
                Console.WriteLine("4. Tambah Program Kerja Baru");
                Console.WriteLine("5. Keluar Aplikasi");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("Pilih opsi menu (1-5): ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        TampilkanProfilDusun();
                        break;
                    case "2":
                        TampilkanTim();
                        break;
                    case "3":
                        TampilkanProker();
                        break;
                    case "4":
                        TambahProker();
                        break;
                    case "5":
                        berjalan = false;
                        Console.WriteLine("\nTerima kasih! Tetap semangat mengabdi di Dusun Nagrak.");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPilihan tidak valid! Tekan Enter untuk mencoba lagi.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void InisialisasiDataAwal()
        {
            // Data Anggota Tim
            listTim.Add(new AnggotaTim("Ahmad Fauzi", "Ketua Kelompok", "S1 Teknik Sipil"));
            listTim.Add(new AnggotaTim("Siti Rahma", "Sekretaris", "S1 Administrasi Publik"));
            listTim.Add(new AnggotaTim("Rian Hidayat", "Bendahara", "S1 Akuntansi"));
            listTim.Add(new AnggotaTim("Dewi Lestari", "Humas & Dokumentasi", "S1 Ilmu Komunikasi"));

            // Data Program Kerja Awal
            listProker.Add(new ProgramKerja("Bimbel & Literasi Anak", "Pendidikan", "Anak-anak RT 004B", "Selesai"));
            listProker.Add(new ProgramKerja("Penyuluhan PHBS & Posyandu", "Kesehatan", "Ibu & Balita RW 001", "Sedang Berjalan"));
            listProker.Add(new ProgramKerja("Digitalisasi Pemasaran UMKM", "Ekonomi", "Pelaku Usaha Nagrak", "Belum Mulai"));
        }

        static void TampilkanProfilDusun()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================================");
            Console.WriteLine("          PROFIL WILAYAH SASARAN KKN 2026               ");
            Console.WriteLine("=========================================================");
            Console.ResetColor();
            Console.WriteLine("Lokasi        : Dusun Nagrak, RT 004B RW 001");
            Console.WriteLine("Karakteristik : Wilayah subur dengan tingkat gotong royong tinggi.");
            Console.WriteLine("                Mayoritas warga bergerak di sektor pertanian");
            Console.WriteLine("                dan industri kreatif rumahan (UMKM).");
            Console.WriteLine("---------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Posko Utama   : Rumah Bapak Ketua RT 004B, Dusun Nagrak");
            Console.ResetColor();
            Console.WriteLine("\nTekan Enter untuk kembali ke menu utama...");
            Console.ReadLine();
        }

        static void TampilkanTim()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================================================");
            Console.WriteLine("                     DAFTAR ANGGOTA TIM KKN                              ");
            Console.WriteLine("=========================================================================");
            Console.ResetColor();
            Console.WriteLine(string.Format("{0,-20} | {0,-20} | {0,-25}", "Nama Lengkap", "Jabatan Tim", "Program Studi"));
            Console.WriteLine("-------------------------------------------------------------------------");
            
            foreach (var anggota in listTim)
            {
                Console.WriteLine(string.Format("{0,-20} | {0,-20} | {0,-25}", anggota.Nama, anggota.Jabatan, anggota.Jurusan));
            }

            Console.WriteLine("\nTekan Enter untuk kembali ke menu utama...");
            Console.ReadLine();
        }

        static void TampilkanProker()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("                     MONITORING PROGRAM KERJA (PROKER)                                   ");
            Console.WriteLine("=========================================================================================");
            Console.ResetColor();
            Console.WriteLine(string.Format("{0,-30} | {1,-12} | {2,-20} | {3,-15}", "Nama Program Kerja", "Bidang", "Target Sasaran", "Status"));
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (var proker in listProker)
            {
                // Warnai status agar visualnya menarik
                if (proker.Status == "Selesai") Console.ForegroundColor = ConsoleColor.Green;
                else if (proker.Status == "Sedang Berjalan") Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(string.Format("{0,-30} | {1,-12} | {2,-20} | {3,-15}", proker.NamaProker, proker.Bidang, proker.TargetSasaran, proker.Status));
                Console.ResetColor();
            }

            Console.WriteLine("\nTekan Enter untuk kembali ke menu utama...");
            Console.ReadLine();
        }

        static void TambahProker()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================================");
            Console.WriteLine("               INPUT PROGRAM KERJA BARU                  ");
            Console.WriteLine("=========================================================");
            Console.ResetColor();

            Console.Write("Nama Program Kerja : ");
            string nama = Console.ReadLine();

            Console.Write("Bidang (Pendidikan/Kesehatan/Ekonomi/Lingkungan): ");
            string bidang = Console.ReadLine();

            Console.Write("Target Sasaran (Misal: Pemuda RT 004B): ");
            string target = Console.ReadLine();

            Console.WriteLine("Pilih Status:");
            Console.WriteLine("1. Belum Mulai");
            Console.WriteLine("2. Sedang Berjalan");
            Console.WriteLine("3. Selesai");
            Console.Write("Pilihan status (1-3): ");
            string opsiStatus = Console.ReadLine();
            
            string status = "Belum Mulai";
            if (opsiStatus == "2") status = "Sedang Berjalan";
            else if (opsiStatus == "3") status = "Selesai";

            // Validasi sederhana jika nama kosong
            if (!string.IsNullOrEmpty(nama))
            {
                listProker.Add(new ProgramKerja(nama, bidang, target, status));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[Sukses] Program kerja baru berhasil didaftarkan ke sistem!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[Gagal] Nama program kerja tidak boleh kosong.");
            }
            
            Console.ResetColor();
            Console.WriteLine("\nTekan Enter untuk kembali...");
            Console.ReadLine();
        }
    }
}
