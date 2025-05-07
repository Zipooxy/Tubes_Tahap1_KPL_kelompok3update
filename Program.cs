using System;
using System.Collections.Generic;
using Tubes_Tahap1_KPL_kelompok3;
using Tubes_Tahap1_KPL_kelompok3.Model;
using Tubes_Tahap1_KPL_kelompok3.Service;
using Tubes_Tahap1_KPL_kelompok3.Automata;
using Tubes_Tahap1_KPL_kelompok3.table_driven;

namespace Tubes_Tahap1_KPL_kelompok3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inisialisasi layanan
            var siswaService = new SiswaService();
            var pelanggaranService = new PelanggaranService();
            var notifikasiService = new NotifikasiService();

            // Menambahkan siswa
            var siswa1 = new Siswa { Nama = "Budi", Kelas = "10A", NomorInduk = "001" };
            var siswa2 = new Siswa { Nama = "Siti", Kelas = "10B", NomorInduk = "002" };
            siswaService.TambahSiswa(siswa1);
            siswaService.TambahSiswa(siswa2);

            // Menampilkan semua siswa
            Console.WriteLine("Daftar Siswa:");
            foreach (var siswa in siswaService.GetSemuaSiswa())
            {
                Console.WriteLine($"Nama: {siswa.Nama}, Kelas: {siswa.Kelas}, Nomor Induk: {siswa.NomorInduk}");
            }

            // Menambahkan pelanggaran
            var pelanggaran1 = new Pelanggaran
            {
                NamaSiswa = siswa1.Nama,
                JenisPelanggaran = "Terlambat Masuk",
                Poin = TabelPelanggaran.GetPoin("Terlambat Masuk"),
                Tanggal = DateTime.Now,
                Status = StatusPelanggaran.BelumDitindak
            };

            pelanggaranService.TambahPelanggaran(siswa1.Nama, pelanggaran1.JenisPelanggaran, pelanggaran1.Poin);

            // Mengubah status pelanggaran
            var trigger = Trigger.SETUJUI;
            pelanggaranService.UbahStatusPelanggaran(pelanggaran1, trigger);

            // Mengirim notifikasi
            notifikasiService.KirimNotifikasi($"Pelanggaran {pelanggaran1.JenisPelanggaran} telah disetujui untuk {siswa1.Nama}.", new Pengguna { Username = "Admin" });

            // Menampilkan semua pelanggaran
            Console.WriteLine("\nDaftar Pelanggaran:");
            foreach (var pelanggaran in pelanggaranService.GetSemuaPelanggaran())
            {
                Console.WriteLine($"Siswa: {pelanggaran.NamaSiswa}, Jenis: {pelanggaran.JenisPelanggaran}, Poin: {pelanggaran.Poin}, Tanggal: {pelanggaran.Tanggal.ToShortDateString()}, Status: {pelanggaran.Status}");
            }

            Console.ReadLine();
        }
    }
}
