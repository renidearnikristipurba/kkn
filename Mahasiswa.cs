namespace KKN_Nagrak_RT04
{
    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Jabatan { get; set; }
        public string Prodi { get; set; }

        public Mahasiswa(string nama, string jabatan, string prodi)
        {
            Nama = nama;
            Jabatan = jabatan;
            Prodi = prodi;
        }
    }
}
