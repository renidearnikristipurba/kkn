import streamlit as st
import pandas as pd

# Konfigurasi Halaman Utama
st.set_page_config(
    page_title="KKN Dusun Nagrak RT 004B",
    page_icon="🏡",
    layout="wide",
    initial_sidebar_state="expanded"
)

# --- DATABASE SIMULASI (Bisa disesuaikan dengan data riil) ---
if 'proker_data' not in st.session_state:
    st.session_state.proker_data = pd.DataFrame([
        {"Program Kerja": "Bimbel & Literasi Anak", "Bidang": "Pendidikan", "Target": "Anak-anak RT 004B", "Status": "Selesai"},
        {"Program Kerja": "Penyuluhan PHBS & Posyandu", "Bidang": "Kesehatan", "Target": "Ibu & Balita RW 001", "Status": "Sedang Berjalan"},
        {"Program Kerja": "Digitalisasi UMKM Kerajinan", "Bidang": "Ekonomi", "Target": "Pelaku Usaha Nagrak", "Status": "Belum Mulai"},
        {"Program Kerja": "Kerja Bakti & Plonisasi Jalan", "Bidang": "Lingkungan", "Target": "Fasilitas Umum RT 004B", "Status": "Selesai"}
    ])

# --- SIDEBAR NAVIGASI ---
st.sidebar.image("https://images.unsplash.com/photo-1517486808906-6ca8b3f04846?auto=format&fit=crop&w=300&q=80", caption="KKN Dusun Nagrak 2026")
st.sidebar.title("Navigasi Menu")
menu = st.sidebar.radio("Pilih Halaman:", ["Beranda & Profil", "Manajemen Proker", "Tim KKN & Kontak"])

# --- HALAMAN 1: BERANDA & PROFIL ---
if menu == "Beranda & Profil":
    st.markdown("<h1 style='text-align: center; color: #059669;'>🏡 Portal KKN Dusun Nagrak</h1>", unsafe_allow_html=True)
    st.markdown("<h3 style='text-align: center; text-transform: uppercase; color: #6B7280;'>RT 004B RW 001 - Desa Nagrak</h3>", unsafe_allow_html=True)
    st.write("---")
    
    col1, col2 = st.columns([3, 2])
    
    with col1:
        st.subheader("✨ Pengantar Pengabdian")
        st.info(
            "Kuliah Kerja Nyata (KKN) di Dusun Nagrak RT 004B RW 001 berfokus pada kolaborasi aktif "
            "bersama warga setempat guna membangun lingkungan yang sehat, cerdas, kreatif, dan mandiri secara ekonomi. "
            "Program dirancang secara partisipatif untuk menyelesaikan isu-isu krusial di tingkat rukun tetangga."
        )
        
        st.subheader("📍 Profil Wilayah Sasaran")
        st.write(
            "Dusun Nagrak RT 004B RW 001 memiliki karakteristik demografi yang hangat dengan tingkat gotong royong tinggi. "
            "Mayoritas warga bergerak di bidang pertanian lokal, wiraswasta skala rumah tangga (UMKM), serta pekerja komuter. "
            "Posko KKN berpusat di dekat kediaman Ketua RT 004B demi kemudahan koordinasi harian."
        )
        
    with col2:
        st.subheader("📊 Statistik Ringkas Wilayah")
        st.metric(label="Total Kepala Keluarga (Estimasi)", value="45 KK")
        st.metric(label="Fokus Utama Kegiatan", value="Kesehatan & Ekonomi Digital")
        st.metric(label="Durasi Pengabdian", value="30 Hari")

# --- HALAMAN 2: MANAJEMEN PROGRAM KERJA ---
elif menu == "Manajemen Proker":
    st.title("📋 Monitoring Program Kerja KKN")
    st.write("Pantau dan perbarui status pelaksanaan program kerja di RT 004B secara berkala.")
    
    # Menampilkan Status Proker saat ini
    st.subheader("Data Proker Aktif")
    st.dataframe(st.session_state.proker_data, use_container_width=True)
    
    st.write("---")
    
    # Form Tambah Proker Baru / Update Proker
    col1, col2 = st.columns(2)
    
    with col1:
        st.subheader("➕ Tambah Program Kerja Baru")
        with st.form("form_tambah"):
            nama_proker = st.text_input("Nama Program Kerja")
            bidang_proker = st.selectbox("Bidang", ["Pendidikan", "Kesehatan", "Ekonomi", "Lingkungan", "Infrastruktur"])
            target_proker = st.text_input("Target Sasaran (contoh: Pemuda RT 004B)")
            status_proker = st.selectbox("Status Awal", ["Belum Mulai", "Sedang Berjalan", "Selesai"])
            
            submit_btn = st.form_submit_button("Simpan ke Sistem")
            if submit_btn and nama_proker:
                new_row = {"Program Kerja": nama_proker, "Bidang": bidang_proker, "Target": target_proker, "Status": status_proker}
                st.session_state.proker_data = pd.concat([st.session_state.proker_data, pd.DataFrame([new_row])], ignore_index=True)
                st.success(f"Proker '{nama_proker}' berhasil ditambahkan!")
                st.rerun()

    with col2:
        st.subheader("📈 Analisis Progress")
        status_counts = st.session_state.proker_data["Status"].value_counts()
        st.bar_chart(status_counts)

# --- HALAMAN 3: TIM KKN & KONTAK ---
elif menu == "Tim KKN & Kontak":
    st.title("👥 Struktur Kelompok & Informasi Posko")
    st.write("Daftar mahasiswa yang bertugas melaksanakan program KKN di Dusun Nagrak:")
    
    # Daftar Anggota Tim
    tim = [
        {"Nama": "Afwanda Rizqi", "Jabatan": "Ketua Kelompok", "Program Studi": "S1 Teknik Informatika"},
        {"Nama": "Reni Dearni", "Jabatan": "Anggota", "Program Studi": "S1 Teknik Informatika"},
    ]
    
    cols = st.columns(4)
    for index, anggota in enumerate(tim):
        with cols[index]:
            st.markdown(f"""
            <div style="background-color: #f3f4f6; padding: 20px; border-radius: 10px; text-align: center; border: 1px solid #e5e7eb;">
                <h4 style="margin: 0; color: #1f2937;">{anggota['Nama']}</h4>
                <p style="margin: 5px 0; color: #059669; font-weight: bold; font-size: 14px;">{anggota['Jabatan']}</p>
                <p style="margin: 0; color: #9ca3af; font-size: 12px;">{anggota['Program Studi']}</p>
            </div>
            """, unsafe_allow_html=True)
            
    st.write("---")
    
    # Kontak Informasi
    st.subheader("📍 Lokasi Sekretariat / Posko KKN")
    col_posko1, col_posko2 = st.columns(2)
    with col_posko1:
        st.markdown("""
        * **Alamat Fisik:** Rumah Bapak Ketua RT 004B / RW 001, Dusun Nagrak, Desa Nagrak
        * **Jam Operasional Posko:** 08.00 - 21.00 WIB
        * **Email Kelompok:** kkn.nagrak004b@universitas.ac.id
        """)
    with col_posko2:
        st.warning("⚠️ Untuk koordinasi program kerja mendesak, harap hubungi Humas kelompok H-1 sebelum kegiatan dilaksanakan.")
