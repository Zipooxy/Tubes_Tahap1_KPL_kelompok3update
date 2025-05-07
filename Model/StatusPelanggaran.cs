using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_Tahap1_KPL_kelompok3.Model
{
    public class StatusPelanggaran

    {
        public static string BelumDitindak { get; internal set; }
        public static StatusPelanggaran DILAPORKAN { get; internal set; }
        public static StatusPelanggaran DIBERI_SANKSI { get; internal set; }
        public static StatusPelanggaran DISETUJUI { get; internal set; }
        public static StatusPelanggaran SELESAI { get; internal set; }
        public string NamaSiswa { get; set; }
        public string JenisPelanggaran { get; set; }
        public int Poin { get; set; }
    }
}
