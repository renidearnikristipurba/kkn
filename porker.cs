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
