namespace KKN_Nagrak_RT04
{
    public class Proker
    {
        public string NamaProgram { get; set; }
        public string Bidang { get; set; }
        public string Status { get; set; } // "Belum Mulai", "Progres", "Selesai"

        public Proker(string namaProgram, string bidang, string status)
        {
            NamaProgram = namaProgram;
            Bidang = bidang;
            Status = status;
        }
    }
}
