using System;
using Tubes_Tahap1_KPL_kelompok3.Model;
namespace Tubes_Tahap1_KPL_kelompok3
{
    public class NotifikasiService
    {
        public void KirimNotifikasi(string tujuan, string pesan)
        {
            Console.WriteLine($"\nNotifikasi untuk {tujuan}: {pesan}");
        }

        public void KirimNotifikasiOrangTua(string namaSiswa, string pesan)
        {
            Console.WriteLine($"\nNotifikasi ke orang tua {namaSiswa}: {pesan}");
        }

        internal void KirimNotifikasi(string v, Pengguna pengguna)
        {
            throw new NotImplementedException();
        }
    }
}
