public class Proker {
    private String namaProgram;
    private String bidang;
    private String status; // "Belum Mulai", "Sedang Berjalan", "Selesai"

    public Proker(String namaProgram, String bidang, String status) {
        this.namaProgram = namaProgram;
        this.bidang = bidang;
        this.status = status;
    }

    public String getNamaProgram() { return namaProgram; }
    public String getBidang() { return bidang; }
    public String getStatus() { return status; }
    
    public void setStatus(String status) { this.status = status; }
}
