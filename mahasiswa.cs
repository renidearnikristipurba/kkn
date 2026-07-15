public class Mahasiswa {
    private String nama;
    private String jabatan;
    private String prodi;

    public Mahasiswa(String nama, String jabatan, String prodi) {
        this.nama = nama;
        this.jabatan = jabatan;
        this.prodi = prodi;
    }

    public String getNama() { return nama; }
    public String getJabatan() { return jabatan; }
    public String getProdi() { return prodi; }
}
